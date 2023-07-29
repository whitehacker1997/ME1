using Global.Models;

namespace OnApp.BizLayer.UserServices
{
    public class UserSortFilterPageOptions : 
        SelectListSortFilterPageOptions<int>
    {
        public int? ParentOrganizationId { get; set; }
        public int? OrganizationId { get; set; }
    }
}
