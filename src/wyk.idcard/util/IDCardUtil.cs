using System;
using System.Collections.Generic;
using System.Reflection;
using wyk.basic;
using wyk.idcard.unit;

namespace wyk.idcard
{
    public class IDCardUtil
    {
        static List<IDCardReaderAttribute> _attributes;
        static List<Type> _types;
        static ReaderUnit unit = null;

        /// <summary>
        /// wyk.idcard.unit下所有的读卡器类
        /// </summary>
        static List<Type> types
        {
            get
            {
                if (_types == null)
                {
                    _types = new List<Type>();
                    Type[] list = Assembly.GetAssembly(typeof(ReaderUnit)).GetTypes();
                    foreach (Type t in list)
                    {
                        _types.Add(t);
                    }
                }
                return _types;
            }
        }

        /// <summary>
        /// wyk.idcard.unit下所有的读卡器操作类属性集
        /// </summary>
        static List<IDCardReaderAttribute> attributes
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new List<IDCardReaderAttribute>();
                    for (int i = 0; i < types.Count; i++)
                    {
                        try
                        {
                            var attr = types[i].getAttribute<IDCardReaderAttribute>();
                            if (attr == null)
                            {
                                types.RemoveAt(i);
                                i--;
                                continue;
                            }
                            _attributes.Add(attr);
                        }
                        catch { types.RemoveAt(i); i--; }
                    }
                }
                return _attributes;
            }
        }

        /// <summary>
        /// 所有支持的身份证读卡器名称列表
        /// </summary>
        /// <returns></returns>
        public static string[] allSupportedNameList()
        {
            string[] names = new string[attributes.Count];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = attributes[i].name();
            }
            return names;
        }

        /// <summary>
        /// 根据厂商和型号获取Attribute
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <param name="model">型号</param>
        /// <returns></returns>
        static IDCardReaderAttribute attribute(string manufacturer, string model)
        {
            var manu = manufacturer.enumFromDisplay<IDCardManufacturer>();
            model = model.Trim();
            foreach (IDCardReaderAttribute attr in attributes)
            {
                if (attr.manufacturer == manu && attr.model == model)
                    return attr;
            }
            return null;
        }

        /// <summary>
        /// 根据厂商和型号获取Attribute
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <param name="model">型号</param>
        /// <returns></returns>
        static IDCardReaderAttribute attribute(IDCardManufacturer manufacturer, string model)
        {
            model = model.Trim();
            foreach (IDCardReaderAttribute attr in attributes)
            {
                if (attr.manufacturer == manufacturer && attr.model == model)
                    return attr;
            }
            return null;
        }

        /// <summary>
        /// 根据厂商获取Attribute
        /// 简易获取模式, 获取厂商的第一个支持型号
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <returns></returns>
        static IDCardReaderAttribute attribute(string manufacturer)
        {
            return attribute(manufacturer.enumFromDisplay<IDCardManufacturer>());
        }

        /// <summary>
        /// 根据厂商获取Attribute
        /// 简易获取模式, 获取厂商的第一个支持型号
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <returns></returns>
        static IDCardReaderAttribute attribute(IDCardManufacturer manufacturer)
        {
            foreach (IDCardReaderAttribute attr in attributes)
            {
                if (attr.manufacturer == manufacturer)
                    return attr;
            }
            return null;
        }

        /// <summary>
        /// 根据显示名称获取Attribute
        /// </summary>
        /// <param name="name">显示名称</param>
        /// <returns></returns>
        static IDCardReaderAttribute attributeByName(string name)
        {
            name = name.Trim();
            foreach (IDCardReaderAttribute attr in attributes)
            {
                if (attr.name() == name)
                    return attr;
            }
            return null;
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <param name="model">型号</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public static void setReaderWithPort(string manufacturer, string model, string port)
        {
            setReaderWithPort(attribute(manufacturer, model),port);
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <param name="model">型号</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public static void setReaderWithPort(IDCardManufacturer manufacturer, string model, string port)
        {
            setReaderWithPort(attribute(manufacturer, model), port);
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="name">显示名称</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public static void setReaderWithPort(string name, string port)
        {
            setReaderWithPort(attributeByName(name), port);
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="attribute">读卡器配置特性</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public static void setReaderWithPort(IDCardReaderAttribute attribute, string port)
        {
            if (attribute != null)
            {
                for (int i = 0; i < types.Count; i++)
                {
                    var attr = types[i].getAttribute<IDCardReaderAttribute>();
                    if (attr != null && attribute.manufacturer == attr.manufacturer && attribute.model == attr.model)
                    {
                        try
                        {
                            unit = Activator.CreateInstance(types[i]) as ReaderUnit;
                            unit.port_number = port;
                            return;
                        }
                        catch { }
                    }
                }
            }
            unit = null;
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <param name="model">型号</param>
        /// <returns></returns>
        public static void setReader(string manufacturer, string model)
        {
            setReader(attribute(manufacturer, model));
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <param name="model">型号</param>
        /// <returns></returns>
        public static void setReader(IDCardManufacturer manufacturer, string model)
        {
            setReader(attribute(manufacturer, model));
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="manufacturer">厂商</param>
        /// <returns></returns>
        public static void setReader(IDCardManufacturer manufacturer)
        {
            setReader(attribute(manufacturer));
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="name">显示名称</param>
        /// <returns></returns>
        public static void setReader(string name)
        {
            setReader(attributeByName(name));
        }

        /// <summary>
        /// 设置身份证读卡器操作单元
        /// </summary>
        /// <param name="attribute">读卡器配置特性</param>
        /// <returns></returns>
        public static void setReader(IDCardReaderAttribute attribute)
        {
            setReaderWithPort(attribute, "1001");
        }

        /// <summary>
        /// 读取身份证信息,默认不获取头像图片
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        public static IDCardInfo readIDCard(out string msg)
        {
            return readIDCard(false, out msg);
        }

        /// <summary>
        /// 读取身份证信息
        /// </summary>
        /// <param name="get_photo">是否获取头像图片</param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        public static IDCardInfo readIDCard(bool get_photo, out string msg)
        {
            if (unit == null)
            {
                msg = "无法获取身份证读取控制单元, 请确认已经设置了正确的读卡器配置";
                return null;
            }
            return unit.readIDCard(get_photo, out msg);
        }
    }
}