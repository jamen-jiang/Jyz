using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Infrastructure
{
    public interface ITreeNode
    {
        object PId { get; set; }
        object Id { get; set; }
        string Name { get; set; }
    }
    public interface ITreeNode<T>: ITreeNode
    {
        List<T> Children { get; set; }
    }
}
