namespace wyk.api
{
    public class PropertyDescription
    {
        public const string PREFIX = "P:";
        public string name = "";
        public string summary = "";

        public PropertyDescription() { }
        public PropertyDescription(string name, string summary)
        {
            this.name = name;
            this.summary = summary;
        }
    }
}