namespace Global.Storage
{
    public class DeleteOutdatedTempFilesJob : IDeleteOutdatedTempFilesJob
    {
        private readonly FileStorageConfig _config;
        public DeleteOutdatedTempFilesJob(FileStorageConfig config)
        {
            _config = config;
        }
        public void Run()
        {
            if (Directory.Exists(_config.TempPath))
                DeleteOutdatedTempFilesRecursive(new DirectoryInfo(_config.TempPath));
        }
        void DeleteOutdatedTempFilesRecursive(DirectoryInfo dir)
        {
            foreach (var file in dir.GetFiles())
            {
                DateTime createdDate = File.GetCreationTime(file.FullName);
                if ((DateTime.Now - createdDate).TotalHours > _config.KeepTempFiles)
                    File.Delete(file.FullName);
            }
            foreach (var subDir in dir.GetDirectories())
                DeleteOutdatedTempFilesRecursive(subDir);
        }
    }
}
