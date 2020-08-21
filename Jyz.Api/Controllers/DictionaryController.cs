using Jyz.Api.Attributes;
using Jyz.Api.Filter;
using Jyz.Application;
using Jyz.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Privilege,DisableLog]
    public class DictionaryController : ApiControllerBase
    {
        private readonly IDictionaryService _dictionaryScv;
        public DictionaryController(IDictionaryService dictionarySvc)
        {
            _dictionaryScv = dictionarySvc;
        }
        /// <summary>
        /// 获取字典内容列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<DictionaryResponse>> Query()
        {
            return await _dictionaryScv.Query();
        }
        /// <summary>
        /// 获取字典类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<DictionaryResponse> Detail(Guid id)
        {
            return await _dictionaryScv.Detail(id);
        }
        /// <summary>
        /// 添加字典
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(DictionaryAddRequest info)
        {
            await _dictionaryScv.Add(info);
        }
        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Modify(DictionaryModifyRequest info)
        {
            await _dictionaryScv.Modify(info);
        }
    }
}
