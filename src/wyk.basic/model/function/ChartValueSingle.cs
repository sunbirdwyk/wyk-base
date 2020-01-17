using System;

namespace wyk.basic
{
    public class ChartValueSingle : ChartValue
    {
        [ChartSeries(0, "值")]
        public double value = 0;

        public ChartValueSingle() { }
        public ChartValueSingle(double record_time, double value) : base(record_time, value)
        {
        }

        public ChartValueSingle(DateTime record_time, double value) : base(record_time, value)
        {
        }
    }
}
