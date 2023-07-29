using System.ComponentModel.DataAnnotations;

namespace Global.Attributes
{
    public class LocalizedCompareAttribute : CompareAttribute
    {
        public LocalizedCompareAttribute(string otherProperty)
            : base(otherProperty)
        {
            ErrorMessage = "Поля '{0}' и '{1}' не совпадает";
        }
    }
}
