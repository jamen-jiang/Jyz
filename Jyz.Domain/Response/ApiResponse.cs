using Jyz.Domain.Enum;
using Jyz.Utility;

namespace Jyz.Domain.Response
{
    /// <summary>
    /// 返回Model
    /// </summary>
    public class ApiResponse
    {
        public ApiResponse()
        {
            Status = (int)ApiStatusEnum.SUCCESS;
        }
        public ApiResponse(dynamic data)
        {
            Data = data;
            Status = (int)ApiStatusEnum.SUCCESS;
        }

        public ApiResponse(ApiStatusEnum apiStatusEnum, string message = "")
        {
            Status = (int)apiStatusEnum;
            Message = message;
        }

        public ApiResponse(int apiStatus, string message = "")
        {
            Status = apiStatus;
            Message = message;
        }
        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; }
        private string message;
        /// <summary>
        /// 信息
        /// </summary>
        public string Message
        {
            get
            {
                return string.IsNullOrEmpty(message) 
                    ? Utils.GetEnumName<ApiStatusEnum>(Status.ToString()) 
                    : message;
            }
            set
            {
                message = value;
            }
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount{get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public dynamic Data { get; set; }
    }
}
