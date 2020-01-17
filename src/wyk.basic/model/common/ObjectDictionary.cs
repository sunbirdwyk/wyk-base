using System;
using System.Collections.Generic;

namespace wyk.basic
{
    public class ObjectDictionary : Dictionary<string, object>
    {
        public static ObjectDictionary create(string key, object value)
        {
            var data = new ObjectDictionary();
            return data.set(key, value);
        }

        public static ObjectDictionary create()
        {
            return new ObjectDictionary();
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
                var obj = this[key];
                if(obj.GetType()==typeof(long))
                {
                    var val = (long)obj;
                    switch (obj.ToString().Length)
                    {
                        case 13:
                            return DateTimeUtil.fromSince1970UTCInterval(val / 1000);
                        case 10:
                            return DateTimeUtil.fromSince1970UTCInterval(val);
                        default:
                            return new DateTime(val);
                    }
                }
                else
                {
                    return Convert.ToDateTime(obj);
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

        public float getFloat(string key)
        {
            try
            {
                return (float)Convert.ToDouble(this[key]);
            }
            catch { }
            return -1;
        }

        public bool getBoolean(string key)
        {
            try
            {
                var obj = this[key];
                switch(obj.ToString().ToLower())
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

        public ObjectDictionary set(string key, object value)
        {
            this[key] = value;
            return this;
        }
    }
}
