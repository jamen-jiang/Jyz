using System;

namespace Jyz.Domain
{
    public partial class Role_Organization : Entity<Guid>
    {
        public Role_Organization(Guid roleId, Guid organizationId)
        {
            RoleId = roleId;
            OrganizationId = organizationId;
        }
        public Guid RoleId { get; set; }
        public Guid OrganizationId { get; set; }

        public Role Role { get; set; }
        public Organization Organization { get; set; }
    }
}
