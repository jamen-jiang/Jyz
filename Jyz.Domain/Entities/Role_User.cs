using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain
{
    public partial class Role_User : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
