namespace Global.Models
{
    public class CultureModel
    {
        public CultureModel(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public int Id { get; private set; }
        public string Code { get; internal set; }
        public string Name { get; internal set; }
    }
}
