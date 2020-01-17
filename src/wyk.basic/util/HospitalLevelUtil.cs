using System.Collections.Generic;
using System.Reflection;
using wyk.basic.fixed_data;

namespace wyk.basic
{
    public class HospitalLevelUtil
    {
        private static List<HospitalLevel> _all_levels = null;
        public static List<HospitalLevel> all_levels
        {
            get
            {
                if (_all_levels == null)
                {
                    _all_levels = new List<HospitalLevel>();
                    HospitalLevels list = new HospitalLevels();
                    var fields = list.GetType().GetFields();
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType == typeof(HospitalLevel))
                        {
                            var item = fi.GetValue(list) as HospitalLevel;
                            _all_levels.Add(item);
                        }
                    }
                }
                return _all_levels;
            }
        }

        /// <summary>
        /// 获取所有医院等级(包括"全部"选项)
        /// </summary>
        /// <returns></returns>
        public static List<HospitalLevel> allLevelsWithAllItem()
        {
            List<HospitalLevel> list = new List<HospitalLevel>(all_levels.ToArray());
            list.Insert(0, HospitalLevel.allItem());
            return list;
        }

        /// <summary>
        /// 根据名字获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HospitalLevel getByName(string name)
        {
            foreach(HospitalLevel level in all_levels)
            {
                if (level.name == name)
                    return level;
            }
            return null;
        }

        public static HospitalLevel getByValue(int value)
        {
            foreach (HospitalLevel level in all_levels)
            {
                if (level.value == value)
                    return level;
            }
            return null;
        }
    }
}
