using BoUgc.BizLayer.ModuleServices;
using OnApp.BizLayer.EnumServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global.EF;
using Global.Models;
using Microsoft.EntityFrameworkCore;

namespace OnApp.BizLayer.ManualServices
{
    public class ManualService : 
        IManualService
    {
        private static bool MODULE_CODE_INITIALIZED = false;
        private readonly DbContext context;

        public ManualService(
            DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ModuleGroupSelectListDto> ModuleSelectList()
        {
            if (!MODULE_CODE_INITIALIZED)
            {
                context.ResolveModules<ModuleCode, Module, ModuleTranslate, ModuleSubGroup, ModuleSubGroupTranslate>();
                MODULE_CODE_INITIALIZED = true;
            }

            return context.Set<Module>().AsSelectList();
        }

        public SelectList<int> StateSelectList()
            => context.Set<State>().AsSelectList();

        public SelectList<int> StatusSelectList()
            => context.Set<Status>().AsSelectList();

        public SelectList<int> GenderSelectList()
            => context.Set<Gender>().AsSelectList();
        public SelectList<int> DocumentTypeSelectList()
            => context.Set<DocumentType>().AsSelectList();
    }
}
