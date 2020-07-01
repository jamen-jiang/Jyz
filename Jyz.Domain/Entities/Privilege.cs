using Jyz.Domain.Core;
using System;

namespace Jyz.Domain
{
    public partial class Privilege : Entity<Guid>
    {
        public string Master { get; set; }
        public Guid MasterValue { get; set; }
        public string Access { get; set; }
        public Guid AccessValue { get; set; }
        public int Operation { get; set; }
    }
}
