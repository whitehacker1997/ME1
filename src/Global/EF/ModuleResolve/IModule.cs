namespace Global.EF
{
    public interface IModule<
        TModuleTranslate,
        TModuleSubGroup,
        TModuleSubGroupTranslate>
            where TModuleTranslate : class,
                                     ITranslate
            where TModuleSubGroup : class,
                                    IModuleSubGroup<TModuleSubGroupTranslate>
            where TModuleSubGroupTranslate : class,
                                             ITranslate
    {
        string Code { get; set; }
        string ShortName { get; set; }
        string FullName { get; set; }
        TModuleSubGroup SubGroup { get; set; }
        ICollection<TModuleTranslate> Translates { get; }
    }
}
