using System;

namespace Jyz.Domain
{
    public partial class Role_Department : Entity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid DepartmentId { get; set; }

        public Role Role { get; set; }
        public Department Department { get; set; }
    }
}
