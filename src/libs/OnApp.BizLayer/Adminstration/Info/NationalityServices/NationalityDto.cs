using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.NationalityServices
{
    public class NationalityDto :
        UpdateNationalityDlDto,
        ILinkToEntity<Nationality>
    {
        public string StateName { get; set; } = null!;
        //new public List<NationalityTranslateDto> Translates { get; set; } = new();
    }
}
