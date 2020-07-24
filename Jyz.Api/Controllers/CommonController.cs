using Jyz.Application;
using Jyz.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    public class CommonController : BaseController
    {
        private readonly ICommonService _commonSvc;
        public CommonController(ICommonService commonSvc)
        {
            _commonSvc = commonSvc;
        }
        /// <summary>
        /// 获取对应的功能列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ComboBoxResponse> GetOperateTypes()
        {
            return _commonSvc.GetComboBoxList(typeof(OperateTypeEnum));
        }
    }
}
