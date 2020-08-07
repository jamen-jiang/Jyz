using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application
{
    public class ComboBoxTreeResponse
    {
        public object Id { get; set; }
        public object PId { get; set; }
        public string Name { get; set; }
        public List<ComboBoxTreeResponse> Children { get; set; } = new List<ComboBoxTreeResponse>();
    }
}
