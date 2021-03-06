using System;
using System.Collections.Generic;

namespace Jyz.Domain
{
    public partial class Role : FullEntity<Guid>
    {
        public string Name { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<Role_User> Role_User { get; set; }
        public virtual ICollection<Role_Organization> Role_Organization { get; set; }
    }
}
