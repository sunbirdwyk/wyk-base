namespace wyk.api
{
    public class TypeDescription
    {
        public const string PREFIX = "T:";
        public string name = "";
        public string summary = "";

        public TypeDescription() { }
        public TypeDescription(string name,string summary)
        {
            this.name = name;
            this.summary = summary;
        }
    }
}