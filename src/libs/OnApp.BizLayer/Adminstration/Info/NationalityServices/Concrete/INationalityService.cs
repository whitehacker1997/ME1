using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.NationalityServices
{
    public interface INationalityService : 
        IStatusGeneric
    {
        PagedResult<NationalityListDto> GetNationalityList(SortFilterPageOptions options);
        SelectList<int> GetNationalityAsSelectList();
        NationalityDto GetNationality();
        NationalityDto GetNationalityById(int nationalityId);
        HaveId<int> CreateNationality(CreateNationalityDlDto dto);
        void UpdateNationality(UpdateNationalityDlDto dto);
        void DeleteNationality(int nationalityId);
    }
}
