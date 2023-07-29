using StatusGeneric;

namespace Global.Storage
{
    public interface IStorageService : IStatusGeneric
    {
        void ResolveMarkedFiles(string document, string documentId);
        void ResolveMarkedFiles(string document, string documentId, bool force);
        void MarkFileForDelete(string document, string documentId, params Guid[] fileIds);
        void MarkFileForMoveToPersistent(string document, string documentId, params Guid[] fileIds);
        StorageFile GetFile(string document, string documentId, Guid fileId);
        StorageFile GetTempFile(string document, Guid fileId);
        IEnumerable<IStorageFileInfo> Save(string document, string documentId, params StorageFile[] files);
        void Delete(string document, string documentId, params Guid[] fileIds);
        void MoveToPersistent(string document, string documentId, params Guid[] tempFileIds);
        void MoveToPersistent(string document, string documentId, bool force, params Guid[] tempFileIds);
        public IStorageFileInfo[] GetTempFileInfos(string document, params Guid[] fileIds);
        IEnumerable<IStorageFileInfo> SaveTemp(string document, params StorageFile[] files);
        void DeleteTemp(string document, params Guid[] tempFileIds);
        MemoryStream GetStaticFile(string fileName);
        void SaveStaticFile(string fileName);
        Stream GetStaticFileDirect(string fileName);
        void ClearErrors();
    }
}
