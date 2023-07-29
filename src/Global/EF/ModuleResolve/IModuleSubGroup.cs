namespace Global.EF
{
    public interface IModuleSubGroup<TTranslate>
        where TTranslate : class,
                           ITranslate
    {
        string Code { get; set; }
        string ShortName { get; set; }
        string FullName { get; set; }
        int GroupId { get; set; }
        ICollection<TTranslate> Translates { get; set; }
    }
}
