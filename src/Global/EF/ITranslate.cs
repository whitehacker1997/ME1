namespace Global.EF
{
    public interface ITranslate
    {
        int LanguageId { get; set; }
        string ColumnName { get; set; }
        string TranslateText { get; set; }
    }
}
