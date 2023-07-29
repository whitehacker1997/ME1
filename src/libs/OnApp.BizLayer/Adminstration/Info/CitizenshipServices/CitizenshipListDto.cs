using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.CitizenshipServices
{
    public class CitizenshipListDto :
        ILinkToEntity<Citizenship>
    {

        public int Id { get; set; }
        public string? WbCode { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int StateId { get; set; }
        public string StateName { get; set; } = null!;
    }
}
