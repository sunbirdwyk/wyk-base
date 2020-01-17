using System;
using wyk.basic;

namespace wyk.wx
{
    public class WXResQRCode : WXResponseBase
    {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        public string ticket = "";

        /// <summary>
        /// 该二维码有效时间，以秒为单位。 最大不超过2592000（即30天）。
        /// </summary>
        public int expire_seconds = 0;

        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
        /// </summary>
        public string url = "";

        public WXResQRCode(string content_string) : base(content_string)
        {
        }

        public DateTime getExpireTime()
        {
            if (expire_seconds > 0)
                return DateTime.Now.AddSeconds(expire_seconds);
            return DateTimeUtil.defaultTime();
        }
    }
}
