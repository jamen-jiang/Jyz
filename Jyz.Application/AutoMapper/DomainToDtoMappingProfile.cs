using AutoMapper;
using Jyz.Application.Dtos;
using Jyz.Domain;

namespace Jyz.Application.AutoMapper
{
    public class DomainToDtoMappingProfile: Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToDtoMappingProfile()
        {
            CreateMap<Module, ModuleResDto>();
            CreateMap<User, UserResDto>();
        }
    }
}
