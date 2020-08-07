using Jyz.Domain.Enums;
using System;

namespace Jyz.Domain
{
    public partial class Privilege : Entity<Guid>
    {
        public Privilege()
        { }
        public Privilege(MasterEnum master, Guid masterValue, AccessEnum access, Guid accessValue)
        {
            Master = master.ToString();
            MasterValue = masterValue;
            Access = access.ToString();
            AccessValue = accessValue;
        }
        public string Master { get; set; }
        public Guid MasterValue { get; set; }
        public string Access { get; set; }
        public Guid AccessValue { get; set; }
        public int Operation { get; set; }
    }
}
