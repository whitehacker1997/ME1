using StatusGeneric;

namespace BoUgc.BizLayer.ModuleServices
{
    public interface IModuleService :
        IStatusGeneric
    {
        void Resolve();
    }
}
