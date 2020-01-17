using System;

namespace wyk.basic
{
    /// <summary>
    /// 取值范围操作类, 一般用于最大值和最小值
    /// </summary>
    public class RangeValuePair
    {
        public const char SeperatorChar = '|';

        public double min_value = double.NaN;
        public double max_value = double.NaN;

        public RangeValuePair() { }
        public RangeValuePair(double min, double max)
        {
            min_value = min;
            max_value = max;
        }       

        /// <summary>
        /// 最小值的字符串值
        /// </summary>
        public string min_string
        {
            get
            {
                if (Double.IsNaN(min_value))
                    return "";
                return min_value.ToString();
            }
            set
            {
                try
                {
                    min_value = Convert.ToDouble(value);
                }
                catch { min_value = double.NaN; }
            }
        }

        /// <summary>
        /// 最大值的字符串值
        /// </summary>
        public string max_string
        {

            get
            {
                if (Double.IsNaN(max_value))
                    return "";
                return max_value.ToString();
            }
            set
            {
                try
                {
                    max_value = Convert.ToDouble(value);
                }
                catch { max_value = double.NaN; }
            }
        }

        public static string valueStatusTextForValue(int value)
        {
            switch (value)
            {
                case 1:
                    return "↑";
                case -1:
                    return "↓";
                case 0:
                    return "√";
                case -2:
                    return "×";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 获取当前值状态
        /// </summary>
        /// <param name="value"></param>
        /// <returns>小于最小值: -1, 大于最大值: 1, 正常 0</returns>
        public int valueStatus(double value)
        {
            if (!Double.IsNaN(min_value) && value < min_value)
                return -1;
            if (!Double.IsNaN(max_value) && value > max_value)
                return 1;
            return 0;
        }

        /// <summary>
        /// 获取当前值状态
        /// </summary>
        /// <param name="value"></param>
        /// <returns>小于最小值: -1, 大于最大值: 1, 正常 0</returns>
        public int valueStatus(int value)
        {
            if (!Double.IsNaN(min_value) && value < min_value)
                return -1;
            if (!Double.IsNaN(max_value) && value > max_value)
                return 1;
            return 0;
        }

        /// <summary>
        /// 获取当前值状态
        /// </summary>
        /// <param name="value_string"></param>
        /// <returns>小于最小值: -1, 大于最大值: 1, 正常 0, 非正常输入值: -2</returns>
        public int valueStatus(string value_string)
        {
            try
            {
                double value = Convert.ToDouble(value_string);
                if (!Double.IsNaN(min_value) && value < min_value)
                    return -1;
                if (!Double.IsNaN(max_value) && value > max_value)
                    return 1;
                return 0;
            }
            catch { return -2; }
        }

        public string valueStatusText(double value)
        {
            return valueStatusTextForValue(valueStatus(value));
        }

        public string valueStatusText(int value)
        {
            return valueStatusTextForValue(valueStatus(value));
        }

        public string valueStatusText(string value_string)
        {
            return valueStatusTextForValue(valueStatus(value_string));
        }

        public string ValueContent
        {
            get => min_string + SeperatorChar + max_string;
            set
            {
                string[] parts = value.Split(SeperatorChar);
                min_string = parts[0];
                try
                {
                    max_string = parts[1];
                }
                catch { max_string = ""; }
            }
        }
    }
}
