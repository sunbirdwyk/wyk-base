using System;
using wyk.basic;

namespace wyk.wx
{
    public class WXConfigInfo
    {
        public string appId = "";
        public long timestamp = 0;
        public string nonceStr = "";
        public string signature = "";
        public WXConfigInfo(string app_id)
        {
            appId = app_id;
            nonceStr = WXUtil.getNonceStr();
            timestamp = DateTime.Now.toIntervalSince1970();
        }

        public WXConfigInfo(string app_id, string url, string js_api_ticket)
        {
            appId = app_id;
            nonceStr = WXUtil.getNonceStr();
            timestamp = DateTime.Now.toIntervalSince1970();
            signature = WXUtil.wxConfigSignature(nonceStr, timestamp, url, js_api_ticket);
        }
    }
}