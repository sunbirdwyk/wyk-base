using System.Web.Http.Description;

namespace wyk.api.ext
{
    public static class ApiSpecModelBaseExtentions
    {
        public static void setContentWithApi(this ApiSpecModelBase model, ApiDescription api)
        {
            model.id = api.friendlyId();
            model.method = api.HttpMethod.Method.ToUpper();
            model.relative_path = api.RelativePath;
            if (model.relative_path.StartsWith("api/"))
            {
                model.path_prefix = "api/";
                model.relative_path = model.relative_path.Substring(4);
            }
            model.name = model.relative_path.Split('?')[0];
            model.description = api.Documentation;
        }
    }
}
