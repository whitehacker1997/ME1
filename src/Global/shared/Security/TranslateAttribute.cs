using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class TranslateAttribute : Attribute
    {
        public TranslateAttribute(int languageId, string shortName, string fullName)
        {
            LanguageId = languageId;
            ShortName = shortName;
            FullName = fullName;
        }

        public TranslateAttribute(int languageId, string shortFullName)
            : this(languageId, shortFullName, shortFullName)
        {
        }

        public int LanguageId { get; private set; }
        public string ShortName { get; private set; }
        public string FullName { get; private set; }
        public virtual string ShortNameColumnName { get; set; } = "short_name";
        public virtual string FullNameColumnName { get; set; } = "full_name";
    }

}
