using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain
{
    public partial class Menu : BaseEntity
    {
        public Guid ModuleId { get; set; }
        public Guid? PId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string VueUri { get; set; }
        public string Remark { get; set; }
        public Module Module { get; set; }
        public virtual List<Operate> Operates { get; set; }
    }
}
