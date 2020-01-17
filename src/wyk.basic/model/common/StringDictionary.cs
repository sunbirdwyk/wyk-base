using System;
using System.Collections.Generic;

namespace wyk.basic
{
    public class StringDictionary : Dictionary<string, string>
    {
        public static StringDictionary create(string key, string value)
        {
            var data = new StringDictionary();
            return data.set(key, value);
        }

        public static StringDictionary create()
        {
            return new StringDictionary();
        }

        public object get(string key)
        {
            try
            {
                return this[key];
            }
            catch { }
            return null;
        }

        public string getString(string key)
        {
            try
            {
                return this[key].ToString();
            }
            catch { }
            return "";
        }

        public int getInt(string key)
        {
            try
            {
                return Convert.ToInt32(this[key]);
            }
            catch { }
            return -1;
        }

        public long getLong(string key)
        {
            try
            {
                return Convert.ToInt64(this[key]);
            }
            catch { }
            return -1;
        }

        public DateTime getDateTime(string key)
        {
            try
            {
                var value = this[key];
                long lv = 0;
                try
                {
                    lv = Convert.ToInt64(value);
                }
                catch { }
                if(lv>0)
                {
                    switch (lv.ToString().Length)
                    {
                        case 13:
                            return DateTimeUtil.fromSince1970UTCInterval(lv / 1000);
                        case 10:
                            return DateTimeUtil.fromSince1970UTCInterval(lv);
                        default:
                            return new DateTime(lv);
                    }
                }
                else
                {
                    return Convert.ToDateTime(value);
                }
            }
            catch { }
            return DateTimeUtil.defaultTime();
        }

        public double getDouble(string key)
        {
            try
            {
                return Convert.ToDouble(this[key]);
            }
            catch { }
            return -1;
        }

        public bool getBoolean(string key)
        {
            try
            {
                var obj = this[key];
                switch (obj.ToString().ToLower())
                {
                    case "true":
                    case "1":
                    case "on":
                        return true;
                    case "false":
                    case "0":
                    case "off":
                        return false;
                    default:
                        try
                        {
                            var val = Convert.ToInt32(obj);
                            if (val > 0)
                                return true;
                        }
                        catch { }
                        break;
                }
            }
            catch { }
            return false;
        }

        public StringDictionary set(string key, string value)
        {
            this[key] = value;
            return this;
        }
    }
}