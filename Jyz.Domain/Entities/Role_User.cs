using System;

namespace Jyz.Domain
{
    public partial class Role_User : Entity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
