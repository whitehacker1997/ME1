using OnApp.DataLayer.Repository;
using GenericServices;
using Global.Models;

namespace OnApp.BizLayer.RoleServices
{
    public class RoleListDto : 
        ILinkToEntity<Role>,
        IHaveIdProp<int>
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string OrderCode { get; set; } = null!;
        public bool IsDefault { get; set; }
        public bool IsHr { get; set; }
        public string State { get; set; } = null!;
    }

}
