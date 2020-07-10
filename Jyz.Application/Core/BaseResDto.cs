using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Core
{
    public class BaseResDto
    {
        public bool IsEnable { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
