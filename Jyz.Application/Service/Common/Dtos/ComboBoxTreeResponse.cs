using Jyz.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class ComboBoxTreeResponse:ITreeNode<ComboBoxTreeResponse>
    {
        public string Id { get; set; }
        public string PId { get; set; }
        public string Name { get; set; }
        public List<ComboBoxTreeResponse> Children { get; set; } = new List<ComboBoxTreeResponse>();
    }
}
