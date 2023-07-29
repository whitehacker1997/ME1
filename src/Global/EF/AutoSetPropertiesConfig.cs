namespace Global.EF
{
    public class AutoSetPropertiesConfig
    {
        public bool Enabled { get; set; } = true;
        public AutoSetPropertyConfig StateId { get; set; } = new AutoSetPropertyConfig("StateId");
        public AutoSetPropertyConfig CreatedAt { get; set; } = new AutoSetPropertyConfig("CreatedAt");
        public AutoSetPropertyConfig ModifiedAt { get; set; } = new AutoSetPropertyConfig("ModifiedAt");
        public AutoSetPropertyConfig CreatedBy { get; set; } = new AutoSetPropertyConfig("CreatedBy");
        public AutoSetPropertyConfig ModifiedBy { get; set; } = new AutoSetPropertyConfig("ModifiedBy");
    }
}
