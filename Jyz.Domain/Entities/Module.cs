using Jyz.Domain.Core;
using System;
using System.Collections.Generic;

namespace Jyz.Domain
{
    public partial class Module : Entity<Guid>
    {
        public Guid? PId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string VueUri { get; set; }
        public string Remark { get; set; }
        public virtual List<Operate> Operates { get; set; }
    }
}
