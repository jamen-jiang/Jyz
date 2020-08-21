using System;

namespace Jyz.Domain
{
    public partial class Role_User : Entity<Guid>
    {
        public Role_User() { }
        public Role_User(Guid roleId, Guid userId)
        {
            RoleId = roleId;
            UserId = userId;
        }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
