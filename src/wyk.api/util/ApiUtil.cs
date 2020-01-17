using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using wyk.basic;

namespace wyk.api
{
    public delegate void ApiSuccess(object data);
    public delegate void ApiFailed(string message, int code);

    public class ApiUtil
    {
        public static string _server_url = "";
        public static string device = "";
        public static string token = "";

        public static string server_url
        {
            get => _server_url;
            set
            {
                _server_url = value.Trim().TrimEnd('\\').TrimEnd('/') + "/";
                if (!server_url.ToLower().StartsWith("http"))
                    _server_url = "http://" + server_url;
            }
        }

        /// <summary>
        /// 测试url是否有效
        /// </summary>
        public static ApiResult testUrl(string url, string method, ObjectDictionary data = null)
        {
            try
            {
                var api_url = method;
                if (!api_url.Trim().ToLower().StartsWith("http"))
                    api_url = url + "api/" + api_url;

                if (data != null)
                    api_url += (api_url.IndexOf('?') >= 0 ? "&" : "?") + joinParam(data);

                var request = (HttpWebRequest)WebRequest.Create(api_url);
                request.Method = WebRequestMethods.Http.Get;
                setDefaultRequestHeaders(ref request);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var rStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(rStream, HttpUtil.getEncoding(response)))
                        {
                            try
                            {
                                return JsonConvert.DeserializeObject<ApiResult>(reader.ReadToEnd());
                            }
                            catch { }
                        }
                    }
                }
                return ApiResult.errorDataFormat();
            }
            catch { }
            return ApiResult.errorProcessFailed("调用API时发生错误, 通常为URL无效");
        }

        /// <summary>
        /// 将API方法转换为服务器连接URL
        /// </summary>
        /// <param name="method">API方法</param>
        /// <returns></returns>
        public static string urlWithMethod(string method)
        {
            return urlWithMethod(method, null);
        }

        /// <summary>
        /// 将API方法转换为服务器连接URL(带参数)
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="data">需要放到URL中的参数</param>
        /// <returns></returns>
        public static string urlWithMethod(string method, ObjectDictionary data)
        {
            var url = method;
            if (!url.Trim().ToLower().StartsWith("http"))
                url = server_url + "api/" + url;
            if (data != null)
                url += (url.IndexOf('?') >= 0 ? "&" : "?") + joinParam(data);
            return url;
        }

        /// <summary>
        /// 设置默认Header项(device/token等)
        /// </summary>
        /// <param name="request">web请求</param>
        public static void setDefaultRequestHeaders(ref HttpWebRequest request)
        {
            request.Headers["device"] = device;
            request.Headers["token"] = token;
        }

        /// <summary>
        /// 构造直接返回消息内容
        /// </summary>
        /// <param name="response_content">返回内容</param>
        /// <returns></returns>
        public static HttpResponseMessage responseTextMessage(string response_content)
        {
            return new HttpResponseMessage { Content = new StringContent(response_content, Encoding.GetEncoding("UTF-8"), "text/plain") };
        }

        /// <summary>
        /// 将API数据字典转换为http请求字符串
        /// </summary>
        /// <param name="data">参数字典</param>
        /// <returns></returns>
        public static string joinParam(ObjectDictionary data)
        {
            var sb = new StringBuilder();
            using (var e = data.GetEnumerator())
            {
                if (e.MoveNext())
                {
                    var key = e.Current.Key.urlEncode();
                    var value = e.Current.Value.ToString().urlEncode();
                    sb.AppendFormat("{0}={1}", key, value);
                    while (e.MoveNext())
                    {
                        key = e.Current.Key.urlEncode();
                        value = e.Current.Value.ToString().urlEncode();
                        sb.AppendFormat("&{0}={1}", key, value);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// API get
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="data">放在URL中的参数</param>
        /// <param name="success">成功时的处理</param>
        /// <param name="failed">失败时的处理</param>
        /// <returns></returns>
        public static IAsyncResult get(string method, ObjectDictionary data = null, ApiSuccess success = null, ApiFailed failed = null)
        {
            try
            {
                var url = urlWithMethod(method, data);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Http.Get;
                setDefaultRequestHeaders(ref request);
                return request.BeginGetResponse(new AsyncCallback(APIRequestCallBack), new ApiState(request, success, failed));
            }
            catch { failed?.Invoke("调用API发生错误, 通常为URL无效", 1); }
            return null;
        }

        /// <summary>
        /// API get
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="success">成功时的处理</param>
        /// <param name="failed">失败时的处理</param>
        /// <returns></returns>
        public static IAsyncResult get(string method, ApiSuccess success = null, ApiFailed failed = null)
        {
            return get(method, null, success, failed);
        }

        /// <summary>
        /// API get  同步方法
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="data">放在URL中的参数</param>
        /// <returns></returns>
        public static ApiResult getSync(string method, ObjectDictionary data = null)
        {
            try
            {
                var url = urlWithMethod(method, data);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Http.Get;
                setDefaultRequestHeaders(ref request);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var rStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(rStream, HttpUtil.getEncoding(response)))
                        {
                            try
                            {
                                return JsonConvert.DeserializeObject<ApiResult>(reader.ReadToEnd());
                            }
                            catch { }
                        }
                    }
                }
                return ApiResult.errorDataFormat();
            }
            catch { }
            return ApiResult.errorProcessFailed("调用API时发生错误, 通常为URL无效");
        }

        /// <summary>
        /// API get  同步方法
        /// </summary>
        /// <param name="method">API方法</param>
        /// <returns></returns>
        public static ApiResult getSync(string method)
        {
            return getSync(method, null);
        }

        /// <summary>
        /// post Json(字符串)
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="data">body中的参数</param>
        /// <param name="success">成功时的处理</param>
        /// <param name="failed">失败时的处理</param>
        /// <returns></returns>
        public static IAsyncResult postJson(string method, object data, ApiSuccess success = null, ApiFailed failed = null)
        {
            try
            {
                byte[] content_bytes = null;
                if (data != null)
                {
                    var content = JsonConvert.SerializeObject(data);
                    content_bytes = Encoding.UTF8.GetBytes(content);
                }
                //var header = StringDictionary.create("Content-Type", "application/x-www-form-urlencoded");
                var header = StringDictionary.create("Content-Type", "application/json");
                return postBytes(method, content_bytes, header, success, failed);
            }
            catch { failed?.Invoke("调用API发生错误, 通常为URL无效", 1); }
            return null;
        }

        /// <summary>
        /// post 方法, Json, 同步方法
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="data">body中的参数</param>
        /// <returns></returns>
        public static ApiResult postJsonSync(string method, object data)
        {
            try
            {
                byte[] content_bytes = null;
                if (data != null)
                {
                    var content = JsonConvert.SerializeObject(data);
                    content_bytes = Encoding.UTF8.GetBytes(content);
                }
                //var header = StringDictionary.create("Content-Type", "application/x-www-form-urlencoded");
                var header = StringDictionary.create("Content-Type", "application/json");
                return postBytesSync(method, content_bytes, header);
            }
            catch { }
            return ApiResult.errorProcessFailed("调用API时发生错误, 通常为URL无效");
        }

        /// <summary>
        /// post Json(字符串)(参数为空)
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="success">成功时的处理</param>
        /// <param name="failed">失败时的处理</param>
        /// <returns></returns>
        public static IAsyncResult post(string method, ApiSuccess success = null, ApiFailed failed = null)
        {
            var header = StringDictionary.create("Content-Type", "application/x-www-form-urlencoded");
            return postBytes(method, null, header, success, failed);
        }

        /// <summary>
        /// post 方法, Json, 同步方法(参数为空)
        /// </summary>
        /// <param name="method">API方法</param>
        /// <returns></returns>
        public static ApiResult postSync(string method)
        {
            var header = StringDictionary.create("Content-Type", "application/x-www-form-urlencoded");
            return postBytesSync(method, null, header);
        }

        /// <summary>
        /// post 字节流格式内容
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="content_bytes">需要post的字节流</param>
        /// <param name="header">自定义的header项</param>
        /// <param name="success">成功时的处理</param>
        /// <param name="failed">失败时的处理</param>
        /// <returns></returns>
        public static IAsyncResult postBytes(string method, byte[] content_bytes = null, StringDictionary header = null, ApiSuccess success = null, ApiFailed failed = null)
        {
            try
            {
                var url = urlWithMethod(method);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Http.Post;
                setDefaultRequestHeaders(ref request);
                if (header != null)
                {
                    foreach (var key in header.Keys)
                    {
                        var value = header[key];
                        switch (key)
                        {
                            case "Content-Type":
                                request.ContentType = value;
                                break;
                            case "Content-Length":
                                request.ContentLength = Convert.ToInt64(value);
                                break;
                            default:
                                request.Headers.Set(key, value);
                                break;
                        }
                    }
                }
                if (content_bytes != null)
                {
                    request.ContentLength = content_bytes.Length;
                    Stream writer;
                    try
                    {
                        writer = request.GetRequestStream();
                        writer.Write(content_bytes, 0, content_bytes.Length);
                        writer.Close();
                    }
                    catch (Exception)
                    {
                        writer = null;
                        return null;
                    }
                }
                else
                    request.ContentLength = 0;
                return request.BeginGetResponse(new AsyncCallback(APIRequestCallBack), new ApiState(request, success, failed));
            }
            catch { failed?.Invoke("调用API发生错误, 通常为URL无效", 1); }
            return null;
        }

        /// <summary>
        /// post 字节流格式内容, 同步方法
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="content_bytes">字节流内容</param>
        /// <param name="header">自定义header</param>
        /// <returns></returns>
        public static ApiResult postBytesSync(string method, byte[] content_bytes = null, StringDictionary header = null)
        {
            try
            {
                var url = urlWithMethod(method);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Http.Post;
                setDefaultRequestHeaders(ref request);
                if (header != null)
                {
                    foreach (var key in header.Keys)
                    {
                        var value = header[key];
                        switch (key)
                        {
                            case "Content-Type":
                                request.ContentType = value;
                                break;
                            case "Content-Length":
                                request.ContentLength = Convert.ToInt64(value);
                                break;
                            default:
                                request.Headers.Set(key, value);
                                break;
                        }
                    }
                }
                if (content_bytes != null)
                {
                    request.ContentLength = content_bytes.Length;
                    Stream writer;
                    try
                    {
                        writer = request.GetRequestStream();
                        writer.Write(content_bytes, 0, content_bytes.Length);
                        writer.Close();
                    }
                    catch (Exception)
                    {
                        writer = null;
                        return ApiResult.errorParameter("传输内容不能为空");
                    }
                }
                else
                    request.ContentLength = 0;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var rStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(rStream, HttpUtil.getEncoding(response)))
                        {
                            try
                            {
                                return JsonConvert.DeserializeObject<ApiResult>(reader.ReadToEnd());
                            }
                            catch { }
                        }
                    }
                }
                return ApiResult.errorDataFormat();
            }
            catch { }
            return ApiResult.errorProcessFailed("调用API时发生错误, 通常为URL无效");
        }

        /// <summary>
        /// 上传图片, 须在API中实现相应的Base64方式上传图片的方法
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="image">图片</param>
        /// <param name="size">上传后的大小</param>
        /// <param name="folder">上传至文件夹名</param>
        /// <param name="name">图片文件名</param>
        /// <param name="success">成功时的处理</param>
        /// <param name="failed">失败时的处理</param>
        /// <returns></returns>
        public static IAsyncResult uploadImage(string method, Image image, Size size, string folder, string name, ApiSuccess success = null, ApiFailed failed = null)
        {
            if (image == null)
            {
                failed?.Invoke("传入图片不能为空", ApiErrorCode.ParameterError);
                return null;
            }
            if (size.Width == 0 || size.Height == 0)
                size = image.Size;
            string size_str = size.Width + "," + size.Height;
            var url = string.Format("{0}?size={1}&folder={2}&name={3}", method, size, folder, name);
            return postBytes(url, Encoding.UTF8.GetBytes(image.base64()), null, success, failed);
        }

        /// <summary>
        /// 上传图片, 须在API中实现相应的Base64方式上传图片的方法
        /// 使用默认的API方法(Upload/Image/Base64)
        /// </summary>
        /// <param name="image">图片</param>
        /// <param name="size">上传后的大小</param>
        /// <param name="folder">上传至文件夹名</param>
        /// <param name="name">图片文件名</param>
        /// <param name="success">成功时的处理</param>
        /// <param name="failed">失败时的处理</param>
        /// <returns></returns>
        public static IAsyncResult uploadImage(Image image, Size size, string folder, string name, ApiSuccess success = null, ApiFailed failed = null)
        {
            return uploadImage("Upload/Image/Base64", image, size, folder, name, success, failed);
        }

        /// <summary>
        /// 上传图片, 须在API中实现相应的Base64方式上传图片的方法
        /// </summary>
        /// <param name="method">API方法</param>
        /// <param name="image">图片</param>
        /// <param name="size">上传后的大小</param>
        /// <param name="folder">上传至文件夹名</param>
        /// <param name="name">图片文件名</param>
        /// <returns></returns>
        public static ApiResult uploadImageSync(string method, Image image, Size size, string folder, string name)
        {
            if (image == null)
                return ApiResult.errorParameter("传入图片不能为空");
            if (size.Width == 0 || size.Height == 0)
                size = image.Size;
            string size_str = size.Width + "," + size.Height;
            var url = string.Format("{0}?size={1}&folder={2}&name={3}", method, size_str, folder, name);
            return postBytesSync(url, Encoding.UTF8.GetBytes(image.base64()), null);
        }

        /// <summary>
        /// 上传图片, 须在API中实现相应的Base64方式上传图片的方法
        /// 使用默认的API方法(Upload/Image/Base64)
        /// </summary>
        /// <param name="image">图片</param>
        /// <param name="size">上传后的大小</param>
        /// <param name="folder">上传至文件夹名</param>
        /// <param name="name">图片文件名</param>
        /// <returns></returns>
        public static ApiResult uploadImageSync(Image image, Size size, string folder, string name)
        {
            return uploadImageSync("Upload/Image/Base64", image, size, folder, name);
        }

        public static void APIRequestCallBack(IAsyncResult async_result)
        {
            if (async_result.AsyncState.GetType() != typeof(ApiState))
                return;
            var state = async_result.AsyncState as ApiState;
            try
            {
                var request = state.self as HttpWebRequest;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var rStream = response.GetResponseStream())
                    {
                        var encoding = HttpUtil.getEncoding(response);
                        using (var reader = new StreamReader(rStream, encoding))
                        {
                            string result = reader.ReadToEnd();
                            try
                            {
                                var data = JsonConvert.DeserializeObject<ApiResult>(result);
                                if (data == null)
                                    state.fail("返回数据格式有误", 1);
                                else
                                {
                                    if (data.code > 0)
                                        state.fail(data.message, data.code);
                                    else
                                        state.success(data.data);
                                }
                            }
                            catch { state.fail("返回数据格式有误", 1); }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                state.fail(ex.Message, 1);
            }
        }
    }
}
