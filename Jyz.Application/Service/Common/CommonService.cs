﻿using Jyz.Domain.Enums;
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
        public List<ComboBoxResponse> GetComboBoxList<T>()where T :Enum
        {
            Dictionary<object, string> data = Utils.GetEnumDict<T>();
            List<ComboBoxResponse> list = new List<ComboBoxResponse>();
            foreach (var d in data)
            {
                ComboBoxResponse model = new ComboBoxResponse();
                model.Value = d.Key;
                model.Name = d.Value;
                list.Add(model);
            }
            return list;
        }
    }
}
