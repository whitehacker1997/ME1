using System.ComponentModel.DataAnnotations;

namespace Global.Attributes
{
    public class LocalizedEmailAddressAttribute : DataTypeAttribute
    {
        public LocalizedEmailAddressAttribute()
            : base(DataType.EmailAddress)
        {
        }
    }
}
