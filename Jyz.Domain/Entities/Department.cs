using System;

namespace Jyz.Domain
{
    public class Department: FullEntity<Guid>
    {
        public Guid? PId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
    }
}
