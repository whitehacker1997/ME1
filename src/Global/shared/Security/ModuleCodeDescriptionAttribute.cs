namespace Global
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ModuleCodeDescriptionAttribute : Attribute
    {
        public ModuleCodeDescriptionAttribute(object moduleSubGroup, string shortName, string fullName)
        {
            ModuleSubGroup = moduleSubGroup;
            ShortName = shortName;
            FullName = fullName;
        }

        public ModuleCodeDescriptionAttribute(object moduleSubGroup, string shortFullName)
            : this (moduleSubGroup, shortFullName, shortFullName)
        { }

        public ModuleCodeDescriptionAttribute(object moduleSubGroup)
            : this(moduleSubGroup, null)
        { }

        public object ModuleSubGroup { get; private set; }
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public string Code { get; set; }
    }
}
