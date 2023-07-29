using System.ComponentModel.DataAnnotations;

namespace Global.Attributes
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute()
        {
            ErrorMessage = "Поле '{0}' обязательно для заполнение";
        }
    }
}
