namespace Global
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ModuleSubGroupDescriptionAttribute : Attribute
    {
        public ModuleSubGroupDescriptionAttribute(int moduleGroupId, string shortName, string fullName)
        {
            ModuleGroupId = moduleGroupId;
            ShortName = shortName;
            FullName = fullName;
        }

        public ModuleSubGroupDescriptionAttribute(int groupId, string shortFullName)
            : this(groupId, shortFullName, shortFullName)
        {
        }

        public ModuleSubGroupDescriptionAttribute(int groupId)
            : this(groupId, null)
        {
        }

        public int ModuleGroupId { get; private set; }
        public string ShortName { get; private set; }
        public string FullName { get; set; }
        public string Code { get; set; }
    }

}
