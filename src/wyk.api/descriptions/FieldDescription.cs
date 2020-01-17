namespace wyk.api
{
    public class FieldDescription
    {
        public const string PREFIX= "F:";
        public string name = "";
        public string summary = "";

        public FieldDescription() { }
        public FieldDescription(string name ,string summary)
        {
            this.name = name;
            this.summary = summary;
        }
    }
}