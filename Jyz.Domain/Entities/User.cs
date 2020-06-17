using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain
{
    public partial class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public virtual List<Role_User> Role_User { get; set; }
    }
}
