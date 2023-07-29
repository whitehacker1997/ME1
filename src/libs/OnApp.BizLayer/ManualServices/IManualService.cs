using BoUgc.BizLayer.ModuleServices;
using Global.Models;

namespace OnApp.BizLayer.ManualServices
{
    public interface IManualService
    {

        IEnumerable<ModuleGroupSelectListDto> ModuleSelectList();
        SelectList<int> StateSelectList();
        SelectList<int> StatusSelectList();
        SelectList<int> GenderSelectList();
        SelectList<int> DocumentTypeSelectList();
    }
}
