namespace Global.Storage
{
    public class FileStorageConfig
    {
        public string Path { get; set; } = null!;
        public string TempPath { get; set; } = null!;
        public string StaticFilesPath { get; set; } = null!;
        /// <summary>
        /// Keep temp files (in hour)
        /// </summary>
        public int KeepTempFiles { get; set; } = 24;
    }
}
