using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Domain
{
    public class Organization_User:Entity<Guid>
    {
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }

        public Organization Organization { get; set; }
        public User User { get; set; }
    }
}
