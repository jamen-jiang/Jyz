﻿using Jyz.Application.Enums;
using Jyz.Infrastructure.Extensions;

namespace Jyz.Application.Response
{
    /// <summary>
    /// 返回Model
    /// </summary>
    public class ApiResponse
    {
        public ApiResponse()
        {
            Status = (int)ApiStatusEnum.Success;
        }
        public ApiResponse(dynamic data)
        {
            Data = data;
            Status = (int)ApiStatusEnum.Success;
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
                    ? Status.GetDescription<ApiStatusEnum>()
                    : message;
            }
            set
            {
                message = value;
            }
        }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int TotalCount{get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}
