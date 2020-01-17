using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using wyk.api.ext;
using wyk.basic;

namespace wyk.api
{
    public class ApiManager
    {
        protected static Assembly _assembly = null;
        protected static List<ApiSpecController> _controllers;
        protected static List<ApiSpecType> _types;
        protected static Dictionary<string, object> _action_infos = new Dictionary<string, object>();
        protected static Dictionary<string, ApiSpecModel> _models = new Dictionary<string, ApiSpecModel>();

        public static void setAssembly(Assembly assembly)
        {
            _assembly = assembly;
        }

        /// <summary>
        /// 获取当前所支持的所有API Controller
        /// </summary>
        public static List<ApiSpecController> controllers
        {
            get
            {
                if (_controllers == null && _assembly != null)
                {
                    _controllers = new List<ApiSpecController>();
                    var types = _assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        try
                        {
                            if (type.IsSubclassOf(typeof(ApiController)))
                            {
                                var controller = Activator.CreateInstance(type) as ApiController;
                                _controllers.Add(ApiSpecUtil.createController(controller));
                            }
                        }
                        catch { }
                    }
                }
                return _controllers;
            }
        }

        /// <summary>
        /// 获取当前所有可支持的API说明(分组)
        /// </summary>
        public static List<ApiSpecType> types
        {
            get
            {
                if (_types == null)
                {
                    _types = new List<ApiSpecType>();
                    foreach (ApiSpecController controller in controllers)
                    {
                        try
                        {
                            int idx = -1;
                            for (int i = 0; i < _types.Count; i++)
                            {
                                if (_types[i].name.ToString() == controller.type)
                                {
                                    idx = i;
                                    break;
                                }
                            }
                            if (idx < 0)
                            {
                                _types.Add(new ApiSpecType(controller.type));
                                idx = _types.Count - 1;
                            }
                            _types[idx].controllers.Add(controller);
                        }
                        catch { }
                    }
                }
                return _types;
            }
        }

        /// <summary>
        /// 根据分组名称获取组说明信息(包含子项Controller和API Description)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ApiSpecType getApiType(string name)
        {
            foreach (var spec in types)
            {
                if (spec.name == name)
                    return spec;
            }
            return null;
        }

        public static ApiSpecModel getApiModel(string id)
        {
            ApiSpecModel model = null;
            try
            {
                model = _models[id];
            }
            catch { }
            if (model == null)
            {
                try
                {
                    Collection<ApiDescription> apiDescriptions = GlobalConfiguration.Configuration.Services.GetApiExplorer().ApiDescriptions;
                    ApiDescription apiDesc = apiDescriptions.FirstOrDefault(api => String.Equals(api.friendlyId(), id, StringComparison.OrdinalIgnoreCase));
                    if (apiDesc != null)
                    {
                        model = ApiSpecUtil.createModel(apiDesc);
                        _models[id] = model;
                    }
                }
                catch { }
            }
            return model;
        }

        public static T getActionInfo<T>(HttpActionDescriptor action)
        {
            var key = keyForAction(action);
            T info = default(T);
            try
            {
                info = (T)_action_infos[key];
            }
            catch { }
            if (info == null)
            {
                try
                {
                    var method = methodForAction(action);
                    if (method != null)
                    {
                        var attr = method.getAttribute<T>(true);
                        if (attr != null)
                            info = (T)attr;
                    }
                }
                catch { }
                if (info == null)
                    info = (T)Activator.CreateInstance(typeof(T));
                _action_infos[key] = info;
            }
            return info;
        }

        public static string keyForAction(HttpActionDescriptor action)
        {
            var sb = new StringBuilder();
            sb.Append(action.ControllerDescriptor.ControllerType.FullName);
            sb.Append("$");
            sb.Append(action.ActionName);
            sb.Append("$");
            foreach (var param in action.GetParameters())
            {
                sb.Append(param.ParameterName);
                sb.Append(":");
                sb.Append(param.ParameterType.ToString());
                sb.Append("|");
            }
            return sb.ToString();
        }

        public static MethodInfo methodForAction(HttpActionDescriptor action)
        {
            try
            {
                var type = _assembly.GetType(action.ControllerDescriptor.ControllerType.FullName);
                if (type == null)
                    return null;
                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    if (method.Name == action.ActionName)
                    {
                        var mp = method.GetParameters();
                        var ap = action.GetParameters();
                        if (mp.Length != ap.Count)
                            continue;
                        bool matched = true;
                        for (var i = 0; i < mp.Length; i++)
                        {
                            if (mp[i].Name != ap[i].ParameterName)
                            {
                                matched = false;
                                break;
                            }
                            if (mp[i].ParameterType != ap[i].ParameterType)
                            {
                                matched = false;
                                break;
                            }
                        }
                        if (matched)
                        {
                            return method;
                        }
                    }
                }
            }
            catch { }
            return null;
        }
    }
}