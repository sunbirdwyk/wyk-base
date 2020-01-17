using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace wyk.api
{
    public static class ApiResultExtention
    {
        public static ObjectResult objectResult(this ApiResult result)
        {
            if (result.data == null)
                return new ObjectResult(new { code = result.code, message = result.message });
            else if (result.data.GetType() == typeof(string) || result.data.GetType().BaseType == typeof(int).BaseType)
                return new ObjectResult(new { code = result.code, message = result.message, data = result.data });
            else
                return new ObjectResult(new { code = result.code, message = result.message, data = JsonConvert.SerializeObject(result.data) });
        }
    }
}