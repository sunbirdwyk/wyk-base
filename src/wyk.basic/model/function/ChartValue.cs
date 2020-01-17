using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace wyk.basic
{
    public class ChartValue
    {
        [JsonIgnore]
        private Dictionary<int, FieldInfo> _value_fields = null;
        [JsonIgnore]
        private Dictionary<int, FieldInfo> value_fields
        {
            get
            {
                if (_value_fields == null)
                {
                    _value_fields = new Dictionary<int, FieldInfo>();
                    var fields = GetType().GetFields();
                    foreach (var fi in fields)
                    {
                        var cs = fi.getAttribute<ChartSeriesAttribute>();
                        if (cs != null)
                            _value_fields[cs.index] = fi;
                    }
                }
                return _value_fields;
            }
        }

        ChartSeriesAttribute[] _series = null;

        /// <summary>
        /// 在不使用Field的情况下, 值都存于此处
        /// </summary>
        List<double> _values = null;

        /// <summary>
        /// 记录时间 (OADate)
        /// </summary>
        public double record_time = 0;

        public ChartValue() { }

        public ChartValue(double record_time, params double[] values)
        {
            this.record_time = record_time;
            _values = new List<double>();
            for (int i = 0; i < values.Length; i++)
            {
                _values.Add(values[i]);
                try
                {
                    this.setValue(value_fields[i], values[i]);
                }
                catch { }
            }
        }

        public ChartValue(DateTime record_time, params double[] values)
        {
            this.record_time = record_time.ToOADate();
            _values = new List<double>();
            for (int i = 0; i < values.Length; i++)
            {
                _values.Add(values[i]);
                try
                {
                    this.setValue(value_fields[i], values[i]);
                }
                catch { }
            }
        }

        public void setValueListToFields()
        {
            for(int i = 0; i < _values.Count; i++)
            {
                try
                {
                    this.setValue(value_fields[i], _values[i]);
                }
                catch { }
            }
        }

        public void setFeildsToValueList()
        {
            if (_values == null)
                _values = new List<double>();
            foreach (var vp in value_fields)
            {
                while (_values.Count <= vp.Key)
                    _values.Add(0);
                try
                {
                    _values[vp.Key] = Convert.ToDouble(this.getValue(vp.Value));
                }
                catch { }
            }
        }

        public DateTime getRecordTime()
        {
            return DateTime.FromOADate(record_time);
        }

        public double getValue(int series)
        {
            if (value_fields != null && value_fields.Count > series)
            {
                try
                {
                    return Convert.ToDouble(this.getValue(value_fields[series]));
                }
                catch { }
            }
            else
            {
                try
                {
                    return _values[series];
                }
                catch { }
            }
            return 0;
        }

        public void setValue(int series, double value)
        {
            try
            {
                this.setValue(value_fields[series], value);
            }
            catch { }
            if (_values == null)
                _values = new List<double>();
            while (_values.Count <= series)
                _values.Add(0);
            _values[series] = value;
        }

        public ChartSeriesAttribute[] getSeries()
        {
            if (_series != null)
                return _series;
            var max = -1;
            foreach (var idx in value_fields.Keys)
            {
                if (idx > max)
                    max = idx;
            }
            if (max < 0)
            {
                _series = new ChartSeriesAttribute[] { };
                return _series;
            }
            _series = new ChartSeriesAttribute[max + 1];
            for (int i = 0; i <= max; i++)
            {
                _series[i] = value_fields[i].getAttribute<ChartSeriesAttribute>();
            }
            return _series;
        }

        public void setSeries(string[] series)
        {
            _series = new ChartSeriesAttribute[series.Length];
            for(int i = 0; i < _series.Length; i++)
            {
                var s = new ChartSeriesAttribute(i, series[i]);
                _series[i] = s;
            }
        }
    }
}
