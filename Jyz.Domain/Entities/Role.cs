using Jyz.Domain.Core;
using System;
using System.Collections.Generic;

namespace Jyz.Domain
{
    public partial class Role : Entity<Guid>
    {
        public string Name { get; set; }
        public string RoleCode { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public virtual List<Role_User> Role_User { get; set; }
    }
}
