using Global.Models;

namespace Global.shared.Models
{
    public class LocalizedModel
    {
        public LocalizedModel()
        {

        }
        public CultureModel Culture { get; set; }
        public string ErrorCode { get; internal set; }
        public string Text { get; internal set; }
        public string Description { get; internal set; }
    }
}
