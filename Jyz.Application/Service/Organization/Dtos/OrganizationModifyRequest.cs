using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class OrganizationModifyRequest : OrganizationAddRequest
    {
        public Guid Id { get; set; }
    }
}
