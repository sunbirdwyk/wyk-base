namespace wyk.wx
{
    [WXMsgType(WXEventType.LOCATION)]
    public class WXEvent_ReportLocation : WXMsg
    {
        [WXMsgProperty]
        public double Latitude = 0;//纬度

        [WXMsgProperty]
        public double Longitude = 0;//经度

        [WXMsgProperty]
        public double Presision = 0;//精度

        public WXEvent_ReportLocation() { }
        public WXEvent_ReportLocation(string xml) : base(xml)
        {

        }
    }
}