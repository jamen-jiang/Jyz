﻿using AutoMapper;
using Jyz.Domain;
using Jyz.Domain.Enums;
using Jyz.Infrastructure;
using System.Linq;

namespace Jyz.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToDtoMappingProfile()
        {
            CreateMap<User, UserResponse>()
            .ForMember(
            dto => dto.OrganizationIds,
            domain => domain.MapFrom(src => src.Organization_User.Select(s=>s.OrganizationId).ToList())
            );
            CreateMap<Module, ModuleResponse>().ForMember(
               dto => dto.TypeName,
               domain => domain.MapFrom(src => src.Type.GetDescription<ModuleTypeEnum>())
            );
            CreateMap<Module, ModuleOperateResponse>().ForMember(
              dto => dto.TypeName,
              domain => domain.MapFrom(src => src.Type.GetDescription<ModuleTypeEnum>())
           );
            CreateMap<Module, ComboBoxTreeResponse>();

            CreateMap<Operate, OperateResponse>().ForMember(
               dto => dto.TypeName,
               domain => domain.MapFrom(src => src.Type.GetDescription<OperateTypeEnum>())
            ).ForMember(
                dto => dto.ModuleName,
                domain => domain.MapFrom(src => src.Module.Name)
            );
            CreateMap<Role, RoleResponse>();
            CreateMap<LogOperate, LogOperateResponse>();
            CreateMap<LogLogin, LogLoginResponse>();

            CreateMap<Organization, OrganizationResponse>().ForMember(
                dto => dto.TypeName,
                domain => domain.MapFrom(src => src.Type.GetDescription<OrganizationTypeEnum>())
            );
            CreateMap<Organization, ComboBoxTreeResponse>();

            CreateMap<Dictionary, DictionaryResponse>();
        }
    }
}
