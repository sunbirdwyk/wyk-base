using System.Collections.Generic;

namespace wyk.api
{
    public class MethodDescription
    {
        public const string PREFIX = "M:";

        public string name = "";
        public string summary = "";
        public List<MethodParamDescription> parameters = new List<MethodParamDescription>();
        public string returns = "";

        public MethodDescription() { }
        public MethodDescription(string name, string summary)
        {
            this.name = name;
            this.summary = summary;
        }

        public MethodParamDescription getParamByName(string name)
        {
            foreach(var mpd in parameters)
            {
                if (mpd.name == name)
                    return mpd;
            }
            return null;
        }
    }
}