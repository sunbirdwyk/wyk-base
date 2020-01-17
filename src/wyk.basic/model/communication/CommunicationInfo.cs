namespace wyk.basic
{
    public class CommunicationInfo : AppConfigBase
    {
        [AppConfigProperty]
        public uint task_id = 0;

        protected override string configFileName()
        {
            return "comm_info.xml";
        }
    }
}