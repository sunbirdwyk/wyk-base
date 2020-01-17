using System.Reflection;
using wyk.basic;

namespace wyk.idcard
{
    /// <summary>
    /// 身份证读卡器设置信息
    /// 可自行继承并添加新的字段, ContentString会自动获取(仅限Field类型,最好只使用string)
    /// </summary>
    public class IDCardReaderConfig
    {
        //
        public string reader_type = "";

        public string reader_port = "1001";


        public string ContentString
        {
            get
            {
                string res = "";
                FieldInfo[] fields = this.GetType().GetFields();
                foreach(FieldInfo fi in fields)
                {
                    res += fi.Name + ":" + fi.GetValue(this).ToString().Replace(":","{[CL]}").Replace(";","{[SCL]}") + ";";
                }
                return res;
            }
            set
            {
                string[] parts = value.Split(';');
                foreach(string part in parts)
                {
                    if (part.Trim() == "")
                        continue;
                    string[] subs = part.Split(':');
                    try
                    {
                        FieldInfo field = this.GetType().GetField(subs[0]);
                        if (field != null)
                        {
                            string f_value = subs[1].Replace("{[CL]}", ":").Replace("{[SCL]}", ";");
                            this.setValue(field, f_value);
                        }
                    }
                    catch { }
                }
            }
        }
    }
}