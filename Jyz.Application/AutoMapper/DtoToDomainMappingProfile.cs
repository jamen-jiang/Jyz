using AutoMapper;
using Jyz.Domain;

namespace Jyz.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DtoToDomainMappingProfile()
        {
            CreateMap<OperateRequest, Operate>();
            CreateMap<RoleModel, Role>();
            CreateMap<ModuleRequest, Module>();
            CreateMap<UserAddRequest, User>();
            CreateMap<UserModifyRequest, User>();
            CreateMap<UserInfo, User>();
            CreateMap<LogOperateRequest, LogOperate>();
            CreateMap<LogLoginRequest, LogLogin>();
        }
    }
}
