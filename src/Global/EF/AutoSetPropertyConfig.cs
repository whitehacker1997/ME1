namespace Global.EF
{
    public class AutoSetPropertyConfig
    {
        public bool Enabled { get; set; } = true;
        public string PropertyName { get; set; }

        public AutoSetPropertyConfig()
        {
        }

        public AutoSetPropertyConfig(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
