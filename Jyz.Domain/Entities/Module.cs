using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain
{
    public partial class Module : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public virtual List<Menu> Menu { get; set; }
    }
}
