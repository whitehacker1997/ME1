using System.ComponentModel.DataAnnotations;

namespace Global.Attributes
{
    public class LocalizedRangeAttribute : RangeAttribute
    {
       

        public LocalizedRangeAttribute(double minimum, double maximum)
            : base(minimum, maximum)
        {
            Init();
        }

        public LocalizedRangeAttribute(int minimum, int maximum)
            : base(minimum, maximum)
        {
            Init();
        }
        
        public LocalizedRangeAttribute(Type type, string minimum, string maximum)
            : base(type, minimum, maximum)
        {
            Init();
        }

        private void Init()
        {
            //ErrorMessage = "";
        }
    }
}
