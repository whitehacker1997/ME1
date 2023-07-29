using BoUgc.BizLayer.ModuleServices;
using OnApp.BizLayer.ManualServices;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ManualController 
        : GlobalController
    {
        private readonly IManualService manualService;

        public ManualController(IManualService manualService)
        {
            this.manualService = manualService;
        }

        [HttpGet]
        public IEnumerable<ModuleGroupSelectListDto> GetModuleSelectList()
            => manualService.ModuleSelectList();

        [HttpGet]
        public SelectList<int> GetStateSelectList()
            => manualService.StateSelectList();

        [HttpGet]
        public SelectList<int> GetStatusSelectList()
            => manualService.StatusSelectList();

        [HttpGet]
        public SelectList<int> GetGenderSelectList()
            => manualService.GenderSelectList();

        [HttpGet]
        public SelectList<int> GetDocumentTypeSelectList()
            => manualService.DocumentTypeSelectList();
    }
}
