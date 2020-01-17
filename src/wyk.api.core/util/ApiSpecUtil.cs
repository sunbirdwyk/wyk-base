using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;
using System.Text;
using wyk.basic;

namespace wyk.api
{
    public class ApiSpecUtil
    {
        public static ApiSpecController createController(ControllerBase controller)
        {
            var attr_ch = controller.getAttribute<ApiControllerAttribute>();
            if (attr_ch == null)//没有[ApiController]的标记时, 不认为他是一个Api接口控制器
                return null;
            var c = new ApiSpecController();
            c.name = controller.GetType().Name;
            if (c.name.EndsWith("Controller"))
            {
                c.name = c.name[0..^10];
            }
            var attr = controller.getAttribute<ApiInfoBase>(true);
            if (attr != null)
            {
                c.type = attr.type;
                c.display = attr.description;
            }
            c.models = new List<ApiSpecModel>();
            if (c.name.isNull())
                return c;
            var route_template = "";
            var attr_route = controller.getAttribute<RouteAttribute>();
            if (attr_route != null)
                route_template = attr_route.Template;
            try
            {
                var methods = controller.GetType().GetMethods();
                foreach (var mi in methods)
                {
                    try
                    {
                        var attr_method = mi.getAttribute<HttpMethodAttribute>(true);
                        if (attr_method == null)
                            continue;
                        var model = new ApiSpecModel();
                        foreach (var method in attr_method.HttpMethods)
                        {
                            model.method = method;
                            break;
                        }
                        var method_desc = ApiDescriptionUtil.getDescription(mi);
                        var sb_id = new StringBuilder();
                        //model_id= [Method]-[Name]-[Param1]-[Param2]-...
                        sb_id.Append(model.method);
                        var route = "";
                        attr_route = mi.getAttribute<RouteAttribute>();
                        if (attr_route == null)
                            route = $"{route_template.Replace("[controller]", c.name)}/{attr_method.Template.Trim('/')}".Trim('/');
                        else
                            route = $"{route_template.Replace("[controller]", c.name)}/{attr_route.Template.Trim('/')}".Trim('/');
                        if (route.ToLower().StartsWith("api/"))
                        {
                            model.path_prefix = route.Substring(0, 4);
                            model.name = route.Substring(4);
                        }
                        else
                        {
                            model.path_prefix = "";
                            model.name = route;
                        }
                        var id_name_part = model.name;
                        while (true)
                        {
                            var tag_index = id_name_part.IndexOf('{');
                            if (tag_index >= 0)
                            {
                                var tag_end = id_name_part.IndexOf('}', tag_index);
                                id_name_part = id_name_part.Remove(tag_index, tag_end - tag_index + 1);
                            }
                            else
                                break;
                        }
                        sb_id.AppendFormat("_{0}", id_name_part.Trim('/').Replace("/", "-"));
                        var sb_relative_path_ex = new StringBuilder();
                        try
                        {
                            var pms = mi.GetParameters();
                            if (pms != null && pms.Length > 0)
                            {
                                foreach (var pm in pms)
                                {
                                    var mpd = method_desc.getParamByName(pm.Name);
                                    var attr_body = pm.getAttribute<FromBodyAttribute>();
                                    if (attr_body != null)
                                    {//body参数
                                        if (mpd != null)
                                        {
                                            model.request_description = mpd.description;
                                            model.request_body_parameters = ApiDescriptionUtil.getParametersForType(pm.ParameterType);
                                        }
                                        sb_id.Append($"_{pm.Name}");
                                    }
                                    else
                                    {//uri参数
                                        var api_pm = new ApiSpecParameter();
                                        api_pm.name = pm.Name;
                                        api_pm.type = pm.ParameterType.ToString();
                                        if (mpd != null)
                                            api_pm.description = mpd.description;
                                        model.uri_parameters.Add(api_pm);
                                        sb_id.Append($"_{api_pm.name}");
                                        if (attr_route.Template.IndexOf(string.Format("{{0}}", api_pm.name)) < 0)
                                        {
                                            if (sb_relative_path_ex.Length <= 0)
                                                sb_relative_path_ex.Append("?");
                                            else
                                                sb_relative_path_ex.Append("&");
                                            sb_relative_path_ex.AppendFormat("{0}={{0}}", api_pm.name);
                                        }
                                    }
                                }
                            }
                        }
                        catch { }
                        model.id = sb_id.ToString();
                        model.relative_path = model.name + sb_relative_path_ex.ToString();
                        model.description = ApiDescriptionUtil.getDescription(mi).summary;
                        model.return_description = method_desc.returns;
                        c.models.Add(model);
                    }
                    catch { }
                }
            }
            catch { }
            return c;
        }
    }
}