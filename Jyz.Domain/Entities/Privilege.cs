using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jyz.Domain
{
    public partial class Privilege : BaseEntity
    {
        public string Master { get; set; }
        public Guid MasterValue { get; set; }
        public string Access { get; set; }
        public Guid AccessValue { get; set; }
        public int Operation { get; set; }
    }
}
