using Global.Models;

namespace Global.EF
{
    public interface IHaveSingleUniqueForeignKey<TForeignKey> :
        IHaveUniqueForeignKey
    {
        void SetUniqueForeignKey(TForeignKey foreignKey);
    }
}
