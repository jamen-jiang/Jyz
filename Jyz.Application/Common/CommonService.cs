using Jyz.Domain.Enums;
using Jyz.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Jyz.Application
{
    public class CommonService:ICommonService
    {
        /// <summary>
        /// 获取枚举类型下拉框列表
        /// </summary>
        /// <returns></returns>
        public List<ComboBoxResponse> GetComboBoxList(Type type)
        {
            Dictionary<string,string> data = Utils.GetEnumDict(type);
            List<ComboBoxResponse> list = new List<ComboBoxResponse>();
            foreach (var d in data)
            {
                ComboBoxResponse model = new ComboBoxResponse();
                model.Value = d.Key.ToInt();
                model.Name = d.Value;
                list.Add(model);
            }
            return list;
        }
    }
}
