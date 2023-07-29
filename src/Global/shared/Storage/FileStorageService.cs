using StatusGeneric;

namespace Global.Storage
{
    public class FileStorageService : StatusGenericHandler, IStorageService
    {
        private readonly FileStorageConfig _config;
        private Dictionary<string, List<Guid>> _markedForDeleteFileIds = new Dictionary<string, List<Guid>>();
        private Dictionary<string, List<Guid>> _markedForMoveToPersistentFileIds = new Dictionary<string, List<Guid>>();

        public FileStorageService(FileStorageConfig config)
        {
            _config = config;
        }

        public virtual void ResolveMarkedFiles(string document, string documentId)
        {
            if (HasErrors)
                return;

            ResolveMarkedFiles(document, documentId, false);
        }

        public virtual void ResolveMarkedFiles(string document, string documentId, bool force)
        {
            if (HasErrors)
                return;

            string key = $"{document}_{documentId}";

            if (_markedForDeleteFileIds.ContainsKey(key))
            {
                Delete(document, documentId, _markedForDeleteFileIds[key].ToArray());
                if (IsValid)
                    _markedForDeleteFileIds[key].Clear();
            }
            if (IsValid && _markedForMoveToPersistentFileIds.ContainsKey(key))
            {
                MoveToPersistent(document, documentId, force, _markedForMoveToPersistentFileIds[key].ToArray());
                if (IsValid)
                    _markedForMoveToPersistentFileIds[key].Clear();
            }
        }

        public virtual void MarkFileForDelete(string document, string documentId, params Guid[] fileIds)
        {
            if (HasErrors)
                return;

            if (document.NullOrEmpty())
                throw new ArgumentException($"{nameof(document)} cannot null or empty", nameof(document));
            if (documentId.NullOrEmpty())
                throw new ArgumentException($"{nameof(documentId)} cannot null or empty", nameof(documentId));

            string key = $"{document}_{documentId}";
            if (!_markedForDeleteFileIds.ContainsKey(key))
                _markedForDeleteFileIds.Add(key, new List<Guid>());
            _markedForDeleteFileIds[key].AddRange(fileIds);
        }

        public virtual void MarkFileForMoveToPersistent(string document, string documentId, params Guid[] tempFileIds)
        {
            if (HasErrors)
                return;

            if (document.NullOrEmpty())
                throw new ArgumentException($"{nameof(document)} cannot null or empty", nameof(document));
            if (documentId.NullOrEmpty())
                throw new ArgumentException($"{nameof(documentId)} cannot null or empty", nameof(documentId));

            string key = $"{document}_{documentId}";
            if (!_markedForMoveToPersistentFileIds.ContainsKey(key))
                _markedForMoveToPersistentFileIds.Add(key, new List<Guid>());
            _markedForMoveToPersistentFileIds[key].AddRange(tempFileIds);
        }

        public virtual StorageFile GetFile(string document, string documentId, Guid fileId)
        {
            if (HasErrors)
                return null;

            string path = Path.Combine(_config.Path, document, documentId);
            if (!Directory.Exists(path))
            {
                AddError("Файл не найдено");
                return null;
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.GetFiles($"{fileId}*");

            if (files.Length == 0)
                AddError("Файл не найдено");
            else if (files.Length > 1)
                AddError("Файл в папке неоднозначен");
            else
            {
                MemoryStream ms = new MemoryStream();
                using (var fs = files[0].OpenRead())
                {
                    fs.CopyTo(ms);
                }
                return new StorageFile(fileId, files[0].Name, ms, files[0].Length);
            }

            return null;
        }

        public virtual StorageFile GetTempFile(string document, Guid tempFileId)
        {
            if (HasErrors)
                return null;

            var fileInfos = GetTempFileInfos(document, tempFileId);

            if (IsValid && fileInfos.Any())
            {
                string fileName = Path.Combine(_config.TempPath, document, $"{fileInfos[0].FileId}{fileInfos[0].FileName}");
                MemoryStream ms = new MemoryStream();
                using (var fs = File.OpenRead(fileName))
                {
                    fs.CopyTo(ms);
                }
                return new StorageFile(tempFileId, fileInfos[0].FileName, ms, fileInfos[0].FileSize);
            }

            return null;
        }

        public virtual IStorageFileInfo[] GetTempFileInfos(string document, params Guid[] fileIds)
        {
            if (HasErrors)
                return null;

            string path = Path.Combine(_config.TempPath, document);
            if (!Directory.Exists(path))
                return new StorageFileInfo[] { };
            DirectoryInfo dir = new DirectoryInfo(path);
            IStorageFileInfo[] result = new IStorageFileInfo[fileIds.Length];

            for (int i = 0; i < fileIds.Length; i++)
            {
                Guid fileId = fileIds[i];
                var files = dir.GetFiles($"{fileId}*");

                if (files.Length == 0)
                    AddError($"Temp file id: `{fileId}` not found in folder: `{document}`");
                else if (files.Length > 1)
                    AddError($"Temp file id: `{fileId}` ambiguous in folder: `{document}`");
                else
                {
                    string fileName = files[0].Name.Substring(fileId.ToString().Length);
                    result[i] = new StorageFileInfo(fileId, fileName, files[0].Length);
                }

                if (!IsValid)
                    break;
            }

            return result;
        }

        public virtual IEnumerable<IStorageFileInfo> Save(string document, string documentId, params StorageFile[] files)
        {
            return SaveInternal(_config.Path, document, documentId, files);
        }

        public virtual IEnumerable<IStorageFileInfo> SaveTemp(string document, params StorageFile[] files)
        {
            return SaveInternal(_config.TempPath, document, null, files);
        }

        public virtual void Delete(string document, string documentId, params Guid[] fileIds)
        {
            DeleteInternal(_config.Path, document, documentId, fileIds);
        }

        public virtual void DeleteTemp(string document, params Guid[] tempFileIds)
        {
            DeleteInternal(_config.TempPath, document, null, tempFileIds);
        }

        public virtual void MoveToPersistent(string document, string documentId, params Guid[] tempFileIds)
        {
            MoveToPersistent(document, documentId, false, tempFileIds);
        }

        public virtual void MoveToPersistent(string document, string documentId, bool force, params Guid[] tempFileIds)
        {
            if (HasErrors || tempFileIds.Length == 0)
                return;

            string tempPath = Path.Combine(_config.TempPath, document);

            if (!Directory.Exists(tempPath))
                return;

            DirectoryInfo tempDir = new DirectoryInfo(tempPath);
            string path = Path.Combine(_config.Path, document, documentId);
            DirectoryInfo dir = Directory.CreateDirectory(path);
            var filesToMove = new List<Tuple<string, string>>();

            foreach (var tempFileId in tempFileIds)
            {
                var existFiles = dir.GetFiles($"{tempFileId}*");
                var tempFiles = tempDir.GetFiles($"{tempFileId}*");

                if (!force && existFiles.Length > 0)
                    throw new Exception($"Files with id `{tempFileId}` in persistent folder ({Path.Combine(document, documentId)}) already exist");

                if (tempFiles.Length == 0)
                    AddError($"Temp file id: `{tempFileId}` not found in folder: `{document}`");
                else if (tempFiles.Length > 1)
                    AddError($"Temp file id: `{tempFileId}` ambiguous in folder: `{document}`");

                filesToMove.Add(Tuple.Create(tempFiles[0].FullName, Path.Combine(path, $"{tempFileId}{tempFiles[0].Extension}")));
            }

            if (IsValid)
                foreach (var fileToMove in filesToMove)
                    File.Move(fileToMove.Item1, fileToMove.Item2, force);
        }

        public virtual void ClearErrors() => _errors?.Clear();

        protected virtual IEnumerable<IStorageFileInfo> SaveInternal(string basePath, string document, string documentId, params StorageFile[] files)
        {
            if (HasErrors || files.Length == 0)
                return null;

            if (document.NullOrEmpty())
                throw new ArgumentException("Cannot be null or empty", nameof(document));

            foreach (var file in files)
            {
                CombineStatuses(file.Validate());
                if (HasErrors)
                    return null;
            }

            string path = documentId == null ? Path.Combine(basePath, document) : Path.Combine(basePath, document, documentId);
            DirectoryInfo dir = Directory.CreateDirectory(path);

            foreach (var file in files)
            {
                if (file.FileId == Guid.Empty)
                    file.FileId = Guid.NewGuid();

                string fileName = Path.Combine(path, $"{file.FileId}{file.FileName}");

                using (FileStream fs = File.Create(fileName))
                {
                    using (Stream stream = file.GetStream())
                    {
                        stream.CopyTo(fs);
                        file.FileSize = stream.Length;
                    }

                }
            }

            return files.Cast<IStorageFileInfo>();
        }

        protected virtual void DeleteInternal(string basePath, string document, string documentId, params Guid[] fileIds)
        {
            if (HasErrors || fileIds.Length == 0)
                return;

            string path = documentId == null ? Path.Combine(basePath, document) : Path.Combine(basePath, document, documentId);
            DirectoryInfo dir = Directory.CreateDirectory(path);

            foreach (var fileId in fileIds)
            {
                var files = dir.GetFiles($"{fileId}*");

                foreach (var file in files)
                    File.Delete(file.FullName);
            }
        }

        public virtual MemoryStream GetStaticFile(string fileName)
        {
            if (HasErrors)
                return null;

            var fs = GetStaticFileDirect(fileName);

            try
            {
                if (HasErrors)
                    return null;

                MemoryStream ms = new MemoryStream();
                fs.CopyTo(ms);
                ms.Position = 0;

                return ms;
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }

        public virtual Stream GetStaticFileDirect(string fileName)
        {
            if (HasErrors)
                return null;
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException($"{nameof(fileName)} cannot be string null or empty", nameof(fileName));

            string path = Path.Combine(_config.StaticFilesPath, fileName);
            if (!File.Exists(path))
            {
                AddError($"Файл не найдено (Адрес: {path})");
                return null;
            }

            return File.OpenRead(path);
        }

        public void SaveStaticFile(string fileName)
        {
            if (HasErrors)
                return;

            MemoryStream stream = new MemoryStream();
            var path = Path.Combine(_config.StaticFilesPath, fileName);

            if (!File.Exists(path))
                AddError($"Static file `{fileName}` not found");
            else
            {
                using (var fs = File.OpenWrite(fileName))
                {
                    stream.Position = 0;
                    stream.CopyTo(fs);
                }
            }

        }
    }
}
