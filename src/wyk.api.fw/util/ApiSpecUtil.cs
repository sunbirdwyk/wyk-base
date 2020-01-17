using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using wyk.basic;

namespace wyk.api.ext
{
    public class ApiSpecUtil
    {
        public static ApiSpecModel createModel(ApiDescription api)
        {
            var model = new ApiSpecModel();
            model.setContentWithApi(api);
            model.return_description = api.ResponseDescription.Documentation;
            model.controller_name = api.ActionDescriptor.ControllerDescriptor.ControllerName;
            try
            {
                var action_info = ApiManager.getActionInfo<ApiActionInfoBase>(api.ActionDescriptor);
                model.login_info = action_info.loginInfo();
            }
            catch { }
            try
            {
                var uri_params = GlobalConfiguration.Configuration.GetUriParameters(api);
                foreach (var pd in uri_params)
                {
                    try
                    {
                        var pm = new ApiSpecParameter();
                        pm.name = pd.Name;
                        pm.type = pd.TypeDescription.Name;
                        pm.description = pd.Documentation;
                        model.uri_parameters.Add(pm);
                    }
                    catch { }
                }
            }
            catch { }
            model.request_description = GlobalConfiguration.Configuration.GetRequestDocumentation(api);
            try
            {
                var model_desc = GlobalConfiguration.Configuration.GetRequestModelDescription(api);
                var body_params = parameterDescriptions(model_desc);
                foreach (var pd in body_params)
                {
                    try
                    {
                        var pm = new ApiSpecParameter();
                        pm.name = pd.Name;
                        pm.type = pd.TypeDescription.Name;
                        pm.description = pd.Documentation;
                        model.request_body_parameters.Add(pm);
                    }
                    catch { }
                }
            }
            catch { }
            model.request_sample = GlobalConfiguration.Configuration.GetRequestSampleText(api);
            return model;
        }

        public static ApiSpecController createController(ApiController controller)
        {
            var c = new ApiSpecController();
            c.name = controller.GetType().Name;
            if (c.name.EndsWith("Controller"))
            {
                c.name = c.name.Substring(0, c.name.Length - 10);
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
            foreach (ApiDescription api in GlobalConfiguration.Configuration.Services.GetApiExplorer().ApiDescriptions)
            {
                if (api.ActionDescriptor.ControllerDescriptor.ControllerName == c.name)
                {
                    var item = new ApiSpecModel();
                    item.setContentWithApi(api);
                    c.models.Add(item);
                }
            }
            return c;
        }

        private static IList<ParameterDescription> parameterDescriptions(ModelDescription modelDescription)
        {
            ComplexTypeModelDescription complexTypeModelDescription = modelDescription as ComplexTypeModelDescription;
            if (complexTypeModelDescription != null)
            {
                return complexTypeModelDescription.Properties;
            }

            CollectionModelDescription collectionModelDescription = modelDescription as CollectionModelDescription;
            if (collectionModelDescription != null)
            {
                complexTypeModelDescription = collectionModelDescription.ElementDescription as ComplexTypeModelDescription;
                if (complexTypeModelDescription != null)
                {
                    return complexTypeModelDescription.Properties;
                }
            }

            return null;
        }
    }
}
