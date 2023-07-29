namespace OnApp.Core
{
    public class StaticFileConst
    {
        public class HtmlTemplate
        {
            private static string FOLDER = "htmltemplates";

            public static readonly string TEST_NAME = Path.Combine(FOLDER, "test.xlsx");
            public static string GetFileName(string culture, string fileName) => Path.Combine(FOLDER, culture, fileName);
        }
        public class UploadedExcelTemplate
        {
            private static string FOLDER = "uploadedexcels";

            public static readonly string TEST_NAME = Path.Combine(FOLDER, "test.xlsx");
            public static string GetFileName(string fileName) => Path.Combine(FOLDER, fileName);
        }
        public class Report
        {
            private static string FOLDER = "exceltemplates";

            public static readonly string TEST_NAME = Path.Combine(FOLDER, "test.xlsx");
            public static string GetFileName(string templateName) => Path.Combine(FOLDER, templateName);

        }
    }
}
