using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public class TranslateHelper
    {
        public static IEnumerable<TranslateDescription> GetDescriptions(FieldInfo fieldInfo)
        {
            foreach (var attr in fieldInfo.GetCustomAttributes(typeof(TranslateAttribute), true).Cast<TranslateAttribute>())
            {
                yield return new TranslateDescription
                {
                    LanguageId = attr.LanguageId,
                    FullName = attr.FullName,
                    ShortName = attr.ShortName,
                    ShortNameColumnName = attr.ShortNameColumnName,
                    FullNameColumnName = attr.FullNameColumnName
                };
            }
        }
    }
}
