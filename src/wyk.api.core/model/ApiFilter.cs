using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace wyk.api
{
    /// <summary>
    /// 处理接口返回结果, 并转换为本体系标准格式
    /// </summary>
    public class ApiFilterBase : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            try
            {
                if (!(context.Result is ObjectResult))
                {
                    if (context.Result is EmptyResult)
                    {
                        context.Result = new ObjectResult(new { code = 404, message = "未找到资源" });
                    }
                    else if (context.Result is ContentResult)
                    {
                        context.Result = new ObjectResult(new { code = 0, message = "", data = JsonConvert.SerializeObject((context.Result as ContentResult).Content) });
                    }
                    else if (context.Result is StatusCodeResult)
                    {
                        context.Result = new ObjectResult(new { code = (context.Result as StatusCodeResult).StatusCode, message = "" });
                    }
                }
                else
                {
                    var res = context.Result as ObjectResult;
                    if (res.Value is ApiResult)
                        context.Result = (res.Value as ApiResult).objectResult();
                }
            }
            catch { }
        }
    }
}