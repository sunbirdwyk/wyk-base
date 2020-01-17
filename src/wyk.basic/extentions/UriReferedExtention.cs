using System;

namespace wyk.basic
{
    public static class UriReferedExtention
    {
        public static string query(this Uri uri, string name)
        {
            var prefix =string.Format("{0}=", name);
            string str = uri.Query.TrimStart('?');
            str = str.Split('$')[0];
            var parts = str.Split('&');
            foreach(var part in parts)
            {
                if (part.isNull())
                    continue;
                if (part.StartsWith(prefix))
                    return part.Substring(prefix.Length);
            }
            return "";
        }
    }
}
