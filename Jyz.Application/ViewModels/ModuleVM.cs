using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.ViewModels
{
    public class ModuleVM
    {
        public List<ModuleNode> ModuleTree { get; set; } = new List<ModuleNode>();
    }
   
    public class ModuleNode
    {
        public Guid Id { get; set; }
        public Guid? PId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string VueUri { get; set; }
        public string Remark { get; set; }
        public List<OperateVM> OperateList { get; set; } = new List<OperateVM>();
        public List<ModuleNode> Children { get; set; } = new List<ModuleNode>();
    }
    public class OperateVM
    {
        public Guid ModuleId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
    }
}
