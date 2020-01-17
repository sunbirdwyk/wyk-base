using System;

namespace wyk.basic
{
    public class ChartSeriesAttribute : Attribute
    {
        public int index = 0;
        public string name = "";

        public ChartSeriesAttribute(int index, string name)
        {
            this.index = index;
            this.name = name;
        }
    }
}
