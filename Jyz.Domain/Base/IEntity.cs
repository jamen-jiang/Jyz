using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Domain
{
    public interface IEntity : IEntity<int>
    {
    }
    public interface IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        TPrimaryKey Id { get; set; }
    }
}
