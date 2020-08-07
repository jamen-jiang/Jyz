using System;

namespace Jyz.Application
{
    public class UserResponse: BaseResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}
