using System;

namespace Jyz.Application
{
    public class RoleResponse: BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RoleCode { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
    }
}
