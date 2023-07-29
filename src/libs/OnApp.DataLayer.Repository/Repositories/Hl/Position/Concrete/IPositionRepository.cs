using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IPositionRepository :
        IBaseEntityRepository<int, Position, CreatePositionDlDto, UpdatePositionDlDto>
    {
        Position ByCode(string code);
    }
}
