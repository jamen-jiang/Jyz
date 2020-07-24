using System;
using System.Collections.Generic;

namespace Jyz.Domain
{
    public partial class User : Entity<Guid>
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<Role_User> Role_User { get; set; }
    }
}
