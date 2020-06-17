using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain
{
    
    public partial class Operate : BaseEntity
    {
        public Guid MenuId { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public  Menu Menu { get; set; }
    }
}
