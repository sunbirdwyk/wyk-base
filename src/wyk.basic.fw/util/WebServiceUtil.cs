using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Net;
using System.Text;
using System.Web.Services.Description;

namespace wyk.basic
{
    public class WebServiceUtil
    {
        /// <summary>  
        /// 动态调用WebService  
        /// </summary>  
        /// <param name="url">WebService地址</param>  
        /// <param name="classname">类名</param>  
        /// <param name="methodname">方法名(模块名)</param>  
        /// <param name="args">参数列表</param>  
        /// <param name="error">错误信息</param>
        /// <returns></returns>  
        [Obsolete]
        public static object InvokeWebService(string url, string classname, string methodname, object[] args, out string error)
        {
            error = "";
            try
            {
                var @namespace = "ServiceBase.WebService.DynamicWebLoad";
                if (classname == null || classname == "")
                    classname = GetClassName(url);
                //获取服务描述语言(WSDL)  
                var wc = new WebClient();
                var stream = wc.OpenRead(url + "?WSDL");
                var sd = ServiceDescription.Read(stream);
                var sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                var cn = new CodeNamespace(@namespace);
                //生成客户端代理类代码  
                var ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                var csc = new CSharpCodeProvider();
                var icc = csc.CreateCompiler();
                //设定编译器的参数  
                var cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");
                //编译代理类  
                var cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    var sb = new StringBuilder();
                    foreach (var ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(Environment.NewLine);
                    }
                    error = sb.ToString();
                }
                //生成代理实例,并调用方法  
                var assembly = cr.CompiledAssembly;
                var t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                var mi = t.GetMethod(methodname);
                return mi.Invoke(obj, args);
            }
            catch (Exception ex) { error = ex.Message; }
            return null;
        }

        /// <summary>  
        /// 动态调用WebService  
        /// </summary>  
        /// <param name="url">WebService地址</param>  
        /// <param name="classname">类名</param>
        /// <param name="methodname">方法名(模块名)</param>  
        /// <param name="args">参数列表</param>  
        /// <returns></returns>  
        [Obsolete]
        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            return InvokeWebService(url, classname, methodname, args, out string _);
        }

        /// <summary>  
        /// 动态调用WebService  
        /// </summary>  
        /// <param name="url">WebService地址</param>  
        /// <param name="methodname">方法名(模块名)</param>  
        /// <param name="args">参数列表</param>  
        /// <param name="error">错误信息</param>
        /// <returns></returns>  
        [Obsolete]
        public static object InvokeWebService(string url, string methodname, object[] args, out string error)
        {
            return InvokeWebService(url, "", methodname, args, out error);
        }

        /// <summary>  
        /// 动态调用WebService  
        /// </summary>  
        /// <param name="url">WebService地址</param>  
        /// <param name="methodname">方法名(模块名)</param>  
        /// <param name="args">参数列表</param>  
        /// <returns></returns>  
        [Obsolete]
        public static object InvokeWebService(string url, string methodname, object[] args)
        {
            return InvokeWebService(url, "", methodname, args);
        }

        private static string GetClassName(string url)
        {
            try
            {
                var parts = url.Split('/');
                return parts[parts.Length - 1].Split('.')[0];
            }
            catch { }
            return "";
        }
    }
}