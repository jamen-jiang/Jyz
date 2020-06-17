using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain
{
    public partial class Role : BaseEntity
    {
        public string Name { get; set; }
        public string RoleCode { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public virtual List<Role_User> Role_User { get; set; }
    }
}
