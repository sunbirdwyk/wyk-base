using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// Web请求的参数类, 每个参数值可以设置为一个field, 可以用作header或者body中的json传递或者url中的参数拼接
    /// </summary>
    public class WebRequestParam
    {
        public WebRequestParam() { }
        public WebRequestParam(string json)
        {
            this.json = json;
        }
        public WebRequestParam(byte[] json_byte)
        {
            this.jsonByte = json_byte;
        }

        FieldInfo[] _fields = null;
        protected FieldInfo[] fields
        {
            get
            {
                if (_fields == null)
                {
                    _fields = this.GetType().GetFields();
                }
                return _fields;
            }
        }
        /// <summary>
        /// 获取field_type 为Color的参数值, 默认为16进制字符串, 可在子类中重写实现不同的写法
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public virtual string jsonForColor(Color color)
        {
            string res = "\"" + color.hexString() + "\"";
            return res;
        }

        /// <summary>
        /// 设置field_type 为Color的参数值, 默认为16进制字符串, 与jsonForColor对应, 可在子类中重写实现不同写法, 两个函数
        /// </summary>
        /// <param name="json_value"></param>
        /// <returns></returns>
        public virtual Color colorWithJson(string json_value)
        {
            return json_value.Trim('\"').Trim('\'').color();
        }

        public string json
        {
            get
            {
                string content = "{";
                foreach (FieldInfo fi in fields)
                {
                    string value_content = getJsonValue(fi.FieldType, fi.GetValue(this));
                    if (value_content != "")
                        content += "\"" + fi.Name + "\":" + value_content;
                }
                content = content.TrimEnd(',');
                content += "}";
                return content;
            }
            set
            {
                string content = value.Trim();
                if (content.StartsWith("{") && content.EndsWith("}"))
                {
                    string[] parts = content.Substring(1, content.Length - 2).Split(',');
                    foreach(string part in parts)
                    {
                        try
                        {
                            string[] kv = part.Split(':');
                            string k = kv[0].Trim().Trim('\"').Trim('\'').Trim();
                            string v = kv[1].Trim().Trim('\"').Trim('\'').Trim();
                            foreach (FieldInfo fi in fields)
                            {
                                if (fi.Name == k)
                                {
                                    setJsonValue(fi, this, v);
                                    break;
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        public string getJsonValue(Type type, object value)
        {
            string content = "";
            if(type == typeof(DateTime))
            {
                content += "\"" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss") + "\",";
            }
            else if(type == typeof(Color))
            {
                content += jsonForColor((Color)value) + ",";
            }
            else if (type == typeof(string) || type == typeof(char))
            {
                content += "\"" + value.ToString() + "\",";
            }
            else if (type.BaseType == typeof(ValueType))
            {
                content += value.ToString() + ",";
            }
            else if (type.BaseType == typeof(WebRequestParam))
            {
                WebRequestParam wrp = value as WebRequestParam;
                content += wrp.json + ",";
            }
            else if (type.BaseType == typeof(Array))
            {
                try
                {
                    Type sub_type = Type.GetType(type.FullName.Replace("[]", ""));
                    content += "[";
                    try
                    {
                        object[] arr = value as object[];
                        foreach (object obj in arr)
                        {
                            content += getJsonValue(sub_type, obj);
                        }
                    }
                    catch { }
                    content = content.TrimEnd(',');
                    content += "],";
                }
                catch { }
            }
            return content;
        }

        public void setJsonValue(FieldInfo fieldInfo, object obj, string value)
        {
            if (fieldInfo.FieldType.BaseType == typeof(WebRequestParam))
            {
                fieldInfo.SetValue(obj, new WebRequestParam(value));
            }
            else if(fieldInfo.FieldType == typeof(DateTime))
            {
                DateTime dt;
                try
                {
                    dt = Convert.ToDateTime(value);
                }
                catch { dt = DateTimeUtil.defaultTime(); }
                fieldInfo.SetValue(obj, dt);
            }
            else if(fieldInfo.FieldType == typeof(Color))
            {
                fieldInfo.SetValue(obj, colorWithJson(value));
            }
            else if (fieldInfo.FieldType.BaseType == typeof(Array))
            {
                if (value.StartsWith("[") && value.EndsWith("]"))
                {
                    try
                    {
                        string[] arr = value.Substring(1, value.Length - 2).Split(',');
                        List<object> list = new List<object>();
                        Type sub_type = Type.GetType(fieldInfo.FieldType.FullName.Replace("[]", ""));
                        foreach(string ov in arr)
                        {

                        }
                    }
                    catch { }
                }
            }
            else
                obj.setValue(fieldInfo, value);
        }

        public byte[] jsonByte
        {
            get => Encoding.UTF8.GetBytes(json);
            set => json = Encoding.UTF8.GetString(value);
        }

        public void setToHeaders(WebRequest request)
        {
            foreach (FieldInfo fi in fields)
            {
                if (fi.FieldType == typeof(string))
                {
                    request.Headers[fi.Name] = fi.GetValue(this) as string;
                }
            }
        }

        public void sendParam(WebRequest request)
        {
            Stream writer = request.GetRequestStream();
            byte[] param = jsonByte;
            writer.Write(jsonByte, 0, jsonByte.Length);
            writer.Close();
        }
    }
}