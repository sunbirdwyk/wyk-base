using System;
using wyk.basic;

namespace wyk.idcard
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class IDCardReaderAttribute : Attribute
    {
        /// <summary>
        /// 读卡器厂商
        /// </summary>
        public IDCardManufacturer manufacturer =  IDCardManufacturer.Unknown;

        /// <summary>
        /// 读卡器型号
        /// </summary>
        public string model = "";

        /// <summary>
        /// 读卡器是否使用端口号
        /// </summary>
        public bool use_port = false;

        public IDCardReaderAttribute() { }

        public IDCardReaderAttribute(string manufacturer, string model)
        {
            this.manufacturer = manufacturer.enumFromDisplay<IDCardManufacturer>();
            this.model = model;
            use_port = true;
        }

        public IDCardReaderAttribute(string manufacturer, string model, bool use_port)
        {
            this.manufacturer = manufacturer.enumFromDisplay<IDCardManufacturer>();
            this.model = model;
            this.use_port = use_port;
        }

        public IDCardReaderAttribute(IDCardManufacturer manufacturer, string model)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            use_port = true;
        }

        public IDCardReaderAttribute(IDCardManufacturer manufacturer, string model, bool use_port)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.use_port = use_port;
        }

        /// <summary>
        /// 读卡器显示名
        /// </summary>
        public string name()
        {
            if(manufacturer== IDCardManufacturer.Unknown)
                return "";
            if (!model.isNull())
                return $"{manufacturer.display()}|{ model}";
            else
                return manufacturer.display();
        }
    }
}