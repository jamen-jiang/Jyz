using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Infrastructure
{
    public interface ITreeNode<T>
    {
        string PId { get; set; }
        string Id { get; set; }
        List<T> Children { get; set; }
    }
}
