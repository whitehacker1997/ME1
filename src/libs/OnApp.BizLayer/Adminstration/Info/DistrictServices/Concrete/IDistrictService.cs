using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.DistrictServices
{
    public interface IDistrictService : 
        IStatusGeneric
    {
        PagedResult<DistrictListDto> GetDistrictList(SortFilterPageOptions options);
        SelectList<int> GetDistrictAsSelectList();
        DistrictDto GetDistrict();
        DistrictDto GetDistrictById(int districtId);
        HaveId<int> CreateDistrict(CreateDistrictDlDto dto);
        void UpdateDistrict(UpdateDistrictDlDto dto);
        void DeleteDistrict(int districtId);
    }
}
