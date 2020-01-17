using System.Configuration;
using wyk.basic;

namespace wyk.im
{
    public class IMManager
    {
        static IMProvider provider = IMProvider.RongCloud;
        public static IMUnit unit = null;

        public static void load()
        {
            try
            {
                var secret = ConfigurationManager.AppSettings["im_secret"];
                var key = ConfigurationManager.AppSettings["im_key"];
                var provider = ConfigurationManager.AppSettings["im_provider"];
                init(provider, key, secret);
            }
            catch { }
        }

        public static void init(IMProvider provider, string key, string secret)
        {
            IMManager.provider = provider;
            if (key.isNull()|| secret.isNull())
            {
                unit = null;
                return;
            }
            switch (provider)
            {
                case IMProvider.RongCloud:
                    unit = new vendor.RongCloud.IMUnit_RongCloud(key, secret);
                    break;
            }
        }

        public static void init(string provider,string key, string secret)
        {
            init(provider.enumFromName<IMProvider>(), key, secret);
        }
    }
}
