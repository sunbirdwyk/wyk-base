using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace wyk.basic
{
    public class HttpUtil
    {
        /// <summary>
        /// 获取当前response编码
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Encoding getEncoding(HttpWebResponse response)
        {
            var encodingText = response.ContentEncoding;
            if (string.IsNullOrEmpty(encodingText))
                encodingText = "UTF-8";
            return Encoding.GetEncoding(encodingText);
        }

        /// <summary>
        /// 将字典转换为http请求字符串
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static string joinParam(IDictionary<string, string> pm)
        {
            var sb = new StringBuilder();
            using (var e = pm.GetEnumerator())
            {
                if (e.MoveNext())
                {
                    var key = e.Current.Key.urlEncode();
                    var value = e.Current.Value.urlEncode();
                    sb.AppendFormat("{0}={1}", key, value);
                    while (e.MoveNext())
                    {
                        key = e.Current.Key.urlEncode();
                        value = e.Current.Value.urlEncode();
                        sb.AppendFormat("&{0}={1}", key, value);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// post 数据流格式内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <param name="stream"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string postStream(string url, IDictionary<string, string> header = null, Stream stream = null, Encoding encoding = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Post;
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
            if (stream != null)
            {
                request.ContentLength = stream.Length;
                using (var rStream = request.GetRequestStream())
                {
                    stream.CopyTo(rStream);
                }
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var rStream = response.GetResponseStream())
                {
                    if (encoding == null)
                    {
                        encoding = getEncoding(response);
                    }
                    using (var reader = new StreamReader(rStream, encoding))
                        return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// post 字节流格式内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <param name="content_bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string postBytes(string url, IDictionary<string, string> header = null, byte[] content_bytes = null, Encoding encoding = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Post;
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
                    return "连接服务器失败!";
                }
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var rStream = response.GetResponseStream())
                {
                    if (encoding == null)
                    {
                        encoding = getEncoding(response);
                    }
                    using (var reader = new StreamReader(rStream, encoding))
                        return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// post Json(字符串)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <param name="jsonContent"></param>
        /// <returns></returns>
        public static string postJson(string url, IDictionary<string, string> header, string jsonContent)
        {
            byte[] content_bytes = null;
            if (!jsonContent.isNull())
            {
                content_bytes = Encoding.UTF8.GetBytes(jsonContent);
            }
            if (header == null)
                header = new Dictionary<string, string>();
            header["Content-Type"] = "application/x-www-form-urlencoded";
            var result = postBytes(url, header, content_bytes);
            return result;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="statusCode">HTTP请求响应代码</param>
        /// <param name="isSuccess">HTTP是否响应成功</param>
        /// <returns></returns>
        public static string postMessage(string url, string postData, out HttpStatusCode statusCode, out bool isSuccess)
        {
            string result = string.Empty;
            statusCode = HttpStatusCode.NotFound;
            isSuccess = false;

            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置Http的内容标头的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";
            try
            {
                HttpClient HttpClientGlobal;
                var handler = new HttpClientHandler()
                {
                    UseCookies = true,
                    AllowAutoRedirect = true,
                    AutomaticDecompression = DecompressionMethods.GZip,
                    UseProxy = false
                };
                HttpClientGlobal = new HttpClient(handler);
                HttpClientGlobal.DefaultRequestHeaders.Connection.Add("keep-alive");
                HttpClientGlobal.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)");
                HttpClientGlobal.DefaultRequestHeaders.Add("Accept", @"text/html,application/xhtml+xml,application/json,application/xml;q=0.9,image/webp,*/*;q=0.8");
                HttpClientGlobal.DefaultRequestHeaders.AcceptCharset.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-8"));

                //异步Post
                HttpResponseMessage response = HttpClientGlobal.PostAsync(url, httpContent).Result;

                //输出Http响应状态码
                statusCode = response.StatusCode;
                isSuccess = response.IsSuccessStatusCode;
                //确保Http响应成功
                if (isSuccess)
                {
                    //异步读取json
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch { }
            return result;
        }

        #region 广播音乐文件上传

        /// <summary>
        /// POST请求网络资源,返回响应的文本
        /// </summary>
        /// <param name="url">网络资源Url地址</param>
        /// <param name="formContent">表单字典</param>
        /// <param name="filePath">文件字典</param>
        public static string httpWebMultiPartFormDataRequest(string url, Dictionary<string, string> formContent, string fileName, IEnumerable<string> filePath)
        {
            var result = string.Empty;
            try
            {
                using (var httpContent = new MultipartFormDataContent())
                {
                    createMultipartFormContent(httpContent, formContent);
                    createFileContent(httpContent, fileName, filePath);
                    HttpClient HttpClientGlobal;
                    var handler = new HttpClientHandler()
                    {
                        UseCookies = true,
                        AllowAutoRedirect = true,
                        AutomaticDecompression = DecompressionMethods.GZip,
                        UseProxy = false
                    };
                    HttpClientGlobal = new HttpClient(handler);
                    HttpClientGlobal.DefaultRequestHeaders.Connection.Add("keep-alive");
                    HttpClientGlobal.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)");
                    HttpClientGlobal.DefaultRequestHeaders.Add("Accept", @"text/html,application/xhtml+xml,application/json,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    HttpClientGlobal.DefaultRequestHeaders.AcceptCharset.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-8"));

                    var httpResponse = HttpClientGlobal.PostAsync(url, httpContent).Result;
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        result = httpResponse.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch { }
            return result;
        }

        private static void createFileContent(MultipartFormDataContent httpContent, string fileName, IEnumerable<string> filePath)
        {
            var contentType = "application/octet-stream";
            try
            {
                foreach (var path in filePath)
                {
                    var file = new FileInfo(path);

                    var fs = file.Open(FileMode.Open);

                    var fileContent = new StreamContent(fs);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "\"" + fileName + "\"",
                        FileName = string.Format("\"{0}\"", file.Name),
                    };
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                    httpContent.Add(fileContent);
                }
            }
            catch { }
        }

        /// <summary>
        /// 编码文件名传输(中文文件名)
        /// </summary>
        /// <param name="fileStream">上传文件流</param>
        /// <param name="fileName">上传文件名</param>
        /// <returns></returns>
        public static void createMultipartFormContent(MultipartFormDataContent httpContent, Dictionary<string, string> dicParameters)
        {
            foreach (var keyValuePair in dicParameters)
            {
                if (!string.IsNullOrWhiteSpace(keyValuePair.Key))
                {
                    httpContent.Add(new StringContent(keyValuePair.Value ?? string.Empty), String.Format("\"{0}\"", keyValuePair.Key));
                }
            }
        }

        #endregion

        /// <summary>
        /// get 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static string get(string url, IDictionary<string, string> header = null, IDictionary<string, string> pm = null)
        {
            if (pm != null)
            {
                url += "?" + joinParam(pm);
            }
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            if (header != null)
            {
                foreach (var key in header.Keys)
                    request.Headers[key] = header[key];
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var rStream = response.GetResponseStream())
                {
                    var encoding = getEncoding(response);
                    using (var reader = new StreamReader(rStream, encoding))
                        return reader.ReadToEnd();
                }
            }
        }

        public static Image getImage(string url, IDictionary<string, string> pm)
        {
            if (pm != null)
            {
                url += "?" + joinParam(pm);
            }
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.ContentType.ToLower().StartsWith("image/"))
                {
                    Image image = Image.FromStream(response.GetResponseStream());
                    return image;
                }
            }
            return null;
        }
    }
}
