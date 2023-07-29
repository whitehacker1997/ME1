using StatusGeneric;

namespace Global.Storage
{
    public interface IStorageFileInfo
    {
        public Guid FileId { get; }
        public string FileName { get; }
        public long FileSize { get; }
    }
    public class StorageFileInfo : IStorageFileInfo
    {
        public StorageFileInfo()
        {

        }
        public StorageFileInfo(Guid fileId,string fileName)
        {
            FileId = fileId;
            FileName = fileName;
        }

        public StorageFileInfo(Guid fileId, string fileName, long fIleSize) : this(fileId, fileName)
        {
            FileSize = fIleSize;
        }

        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }

    }

    public class StorageFile : StorageFileInfo
    {
        private Stream _stream;
        public StorageFile(IStorageFileInfo storageFileInfo, Stream stream)
            : this(storageFileInfo.FileId, storageFileInfo.FileName, stream, storageFileInfo.FileSize)
        {

        }

        public StorageFile(Guid fileId, string fileName, Stream stream, long fileSize = 0, string fileMimeType = "")
            : this(fileId, fileName, stream)
        {
            FileSize = fileSize;
        }

        public StorageFile(Guid fileId, string fileName, Stream stream)
            : this(fileName, stream)
        {
            FileId = fileId;
        }

        public StorageFile(string fileName, Stream stream)
        {
            FileName = fileName;
            _stream = stream;
        }

        public Stream GetStream()
        {
            _stream.Position = 0;
            return _stream;
        }

        public IStatusGeneric Validate()
        {
            var status = new StatusGenericHandler();

            if (FileName.NullOrEmpty() || FileName.IndexOfAny(Path.GetInvalidFileNameChars()) > 0 ||
                !Path.HasExtension(FileName) || Path.GetFileNameWithoutExtension(FileName).NullOrEmpty())
                status.AddError($"Filename ({FileName}) not valid");

            if (GetStream() == null || !GetStream().CanRead)
                status.AddError("Cannot read file");

            return status;
        }

        public string GetUniqueFileName()
        {
            return $"{FileId}{FileName}";
        }
    }
}
