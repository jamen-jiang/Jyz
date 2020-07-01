using Jyz.Domain;
using System;
using System.Collections.Generic;

namespace Jyz.Application.Jwt
{
    public class Token
    {
        public Token() { }
        public Token(Guid userId, List<Operate> operateList)
        {
            this.UserId = userId;
            this.OperateList = operateList;
        }
        public Guid UserId { get; set; }
        public List<Operate> OperateList { get; set; }
    }
}
