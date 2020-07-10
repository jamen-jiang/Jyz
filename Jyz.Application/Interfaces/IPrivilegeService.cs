using Jyz.Application.Dtos;
using Jyz.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Application.Interfaces
{
    public interface IPrivilegeService
    {
        List<PrivilegeDto> GetPrivilegeByUserId(Guid userId);
         ModuleVM GetModuleList(Guid userId);
    }
}
