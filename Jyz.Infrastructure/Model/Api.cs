using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Infrastructure.Model
{
    public class Api
    {
        //控制器
        public string Controller { get; set; }
        //控制名称
        public string ControllerName { get; set; }
        //操作
        public string Action { get; set; }
        //操作名称
        public string ActionName { get; set; }
    }
}
