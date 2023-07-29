namespace Global
{
    public class ModuleSubGroupDescription
    {
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public int ModuleGroupId { get; set; }
        public List<ModuleCodeDescription> ModuleCodes { get; set; } = new List<ModuleCodeDescription>();
        public List<TranslateDescription> Translates { get; set; } = new List<TranslateDescription>();
    }

    public class ModuleCodeDescription
    {
        internal ModuleCodeDescription()
        {

        }

        public string Code { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<TranslateDescription> Translates { get; set; } = new List<TranslateDescription>();
    }

    public class ModuleCodeHelper
    {
        public static Dictionary<string, ModuleSubGroupDescription> GetDescriptions<TModuleCodeEnum>()
            where TModuleCodeEnum : struct
        {
            var dic = new Dictionary<string, ModuleSubGroupDescription>();

            foreach (var moduleCodeField in typeof(TModuleCodeEnum).GetFields().Where(a => a.IsStatic))
            {
                var moduleCodeAttr = moduleCodeField.GetCustomAttributes(typeof(ModuleCodeDescriptionAttribute), false).Cast<ModuleCodeDescriptionAttribute>().FirstOrDefault();

                if (moduleCodeAttr == null)
                    throw new Exception($"{nameof(ModuleCodeDescriptionAttribute)} not found in {typeof(TModuleCodeEnum).Name}.{moduleCodeField.Name}");

                var moduleCodeDescription = new ModuleCodeDescription
                {
                    Code = string.IsNullOrEmpty(moduleCodeAttr.Code) ? moduleCodeField.Name : moduleCodeAttr.Code,
                    ShortName = string.IsNullOrEmpty(moduleCodeAttr.ShortName) ? moduleCodeField.Name : moduleCodeAttr.ShortName,
                    FullName = string.IsNullOrEmpty(moduleCodeAttr.FullName) ? moduleCodeField.Name : moduleCodeAttr.FullName,
                };
                moduleCodeDescription.Translates.AddRange(TranslateHelper.GetDescriptions(moduleCodeField));

                var moduleSubGroupField = moduleCodeAttr.ModuleSubGroup.GetType().GetField(moduleCodeAttr.ModuleSubGroup.ToString());
                if (moduleSubGroupField == null)
                    throw new Exception($"Field not found in {moduleCodeAttr.ModuleSubGroup.GetType().Name}.{moduleCodeAttr.ModuleSubGroup}");

                var moduleSubGroupAttr = moduleSubGroupField.GetCustomAttributes(typeof(ModuleSubGroupDescriptionAttribute), false).Cast<ModuleSubGroupDescriptionAttribute>().FirstOrDefault();
                if (moduleSubGroupAttr == null)
                    throw new Exception($"{nameof(ModuleSubGroupDescriptionAttribute)} not found in {moduleCodeAttr.ModuleSubGroup.GetType().Name}.{moduleCodeAttr.ModuleSubGroup}");


                string moduleSubGroupCode = string.IsNullOrEmpty(moduleSubGroupAttr.Code) ? moduleSubGroupField.Name : moduleSubGroupAttr.Code;
                ModuleSubGroupDescription moduleSubGroupDescription = null;

                if (dic.ContainsKey(moduleSubGroupCode))
                {
                    moduleSubGroupDescription = dic[moduleSubGroupCode];
                }
                else
                {
                    moduleSubGroupDescription = new ModuleSubGroupDescription
                    {
                        Code = moduleSubGroupCode,
                        ShortName = string.IsNullOrEmpty(moduleSubGroupAttr.ShortName) ? moduleSubGroupField.Name : moduleSubGroupAttr.ShortName,
                        FullName = string.IsNullOrEmpty(moduleSubGroupAttr.FullName) ? moduleSubGroupField.Name : moduleSubGroupAttr.FullName,
                        ModuleGroupId = moduleSubGroupAttr.ModuleGroupId,
                    };
                    dic.Add(moduleSubGroupCode, moduleSubGroupDescription);
                }
                moduleSubGroupDescription.Translates.AddRange(TranslateHelper.GetDescriptions(moduleSubGroupField));
                moduleSubGroupDescription.ModuleCodes.Add(moduleCodeDescription);
            }

            return dic;
        }
    }

}
