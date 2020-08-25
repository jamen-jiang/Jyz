using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class PassWordRequest
    {
        public string OldPassWord { get; set; }
        public string NewPassWord { get; set; }
        public string NewPassWordConfirm { get; set; }
    }
}
