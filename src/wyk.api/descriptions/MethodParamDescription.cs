namespace wyk.api
{
    public class MethodParamDescription
    {
        public string name = "";
        public string description = "";

        public MethodParamDescription() { }
        public MethodParamDescription(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}