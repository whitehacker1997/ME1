using System.ComponentModel.DataAnnotations;

namespace Global.Attributes
{
    public class LocalizedStringLengthAttribute : StringLengthAttribute
    {
        public LocalizedStringLengthAttribute(int maximumLength)
            : base(maximumLength)
        {

        }
    }
}
