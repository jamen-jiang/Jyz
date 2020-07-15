using Jyz.Application.Interfaces;
using Jyz.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Jyz.Api.Controllers
{
   [Authorize]
    public class ModuleController : BaseController
    {
        private readonly IModuleService _moduleSvc;
        public ModuleController(IModuleService moduleSvc)
        {
            _moduleSvc = moduleSvc;
        }
    }
}
