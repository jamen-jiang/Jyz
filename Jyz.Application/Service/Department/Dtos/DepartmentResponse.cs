using Jyz.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class DepartmentResponse: BaseResponse,ITreeNode<DepartmentResponse>
    {
        public string Id { get; set; }
        public string PId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public List<DepartmentResponse> Children { get; set; } = new List<DepartmentResponse>();
    }
}
