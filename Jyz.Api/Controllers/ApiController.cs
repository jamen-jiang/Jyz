using Microsoft.AspNetCore.Mvc;

namespace Jyz.Api.Controllers
{
    public class ApiController : BaseController
    {
        /// <summary>
        /// api入口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProcessRequest()
        {
            return Ok("hello");
            // 获取Json参数
            //byte[] byts = new byte[Request.Body.Length];
            //Request.Body.Read(byts, 0, byts.Length);
            //string reqParams = System.Text.Encoding.UTF8.GetString(byts);
            // 获取返回值
            //ApiResponse response = Main.Process(reqParams);
            //ApiResponse response = null;
            //return Ok(response);
            //result.Response = response;
            //return result;
        }
    }
}
