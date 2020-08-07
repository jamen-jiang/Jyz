using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class UserQuery
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedOnStart { get; set; }
        public DateTime? CreatedOnEnd { get; set; }
    }
}
