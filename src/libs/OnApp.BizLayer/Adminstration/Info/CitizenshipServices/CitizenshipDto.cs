using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.CitizenshipServices
{
    public class CitizenshipDto :
        UpdateCitizenshipDlDto,
        ILinkToEntity<Citizenship>
    {
        public string StateName { get; set; } = null!;
        //new public List<CitizenshipTranslateDto> Translates { get; set; } = new();
    }
}
