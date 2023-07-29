using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.PositionServices
{
    public class PositionListDto :
        ILinkToEntity<Position>
    {

        public int Id { get; set; }
        public string? Code { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public bool IsDoctor { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; } = null!;
    }
}
