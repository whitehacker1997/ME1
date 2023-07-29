using System.ComponentModel.DataAnnotations;

namespace Global.Attributes
{
    public class LocalizedMinLengthAttribute : MinLengthAttribute
    {
        public LocalizedMinLengthAttribute(int length)
            : base(length)
        {

        }

    }
}
