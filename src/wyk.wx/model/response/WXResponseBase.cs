using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using wyk.basic;

namespace wyk.wx
{
    /// <summary>
    /// 以json为主体的返回结果
    /// </summary>
    public class WXResponseBase
    {
        public string errcode = "";
        public string errmsg = "";

        private Dictionary<string, object> content = new Dictionary<string, object>();
        public WXResponseBase() { }
        public WXResponseBase(string content_string)
        {
            setContentString(content_string);
        }

        public void setContentString(string content_string)
        {
            content = JsonConvert.DeserializeObject<Dictionary<string,object>>(content_string);
            initProperties();
        }

        public string getValueString(string key)
        {
            try
            {
                return content[key].ToString();
            }
            catch { }
            return "";
        }

        public object getValue(string key)
        {
            try
            {
                return content[key];
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 将字典中的数据装载到各个field中
        /// </summary>
        public void initProperties()
        {
            FieldInfo[] fields = this.GetType().GetFields();
            foreach (FieldInfo fi in fields)
            {
                try
                {
                    this.setValue(fi, content[fi.Name]);
                }
                catch { }
            }
        }

        /// <summary>
        /// 判断结果是否为成功
        /// </summary>
        /// <returns></returns>
        public virtual bool isSuccess()
        {
            int code = 0;
            try
            {
                code = Convert.ToInt32(errcode);
            }
            catch { }
            if (code > 0)
                return false;
            return true;
        }

        public virtual string errorMessage()
        {
            if (isSuccess())
                return "";
            return errmsg + "(Code:" + errcode + ")";
        }
    }
}
