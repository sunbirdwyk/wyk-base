using System;
using System.Drawing;
using wyk.basic;

namespace wyk.idcard
{
    /// <summary>
    /// 身份证信息
    /// </summary>
    public class IDCardInfo
    {
        public bool read_from_machine = false;

        public string id_card_number = "";
        public string name = "";
        public string gender = "";
        public DateTime birthday = DateTimeUtil.defaultTime();
        public string nation = "";
        public string address = "";
        public DateTime start_date = DateTimeUtil.defaultTime();
        public DateTime end_date = DateTimeUtil.defaultTime();
        public string department = "";
        public string reserve_contents = "";
        public Image photo = null;

        public string area_province = "";
        public string area_city = "";
        public string area_district = "";

        public IDCardInfo() { }
        public IDCardInfo(string IDCardNumber)
        {
            setInfoForIDCardNumber(IDCardNumber);
        }

        public int Age
        {
            get => DateTimeUtil.ageByBirthday(birthday);
            set => birthday = DateTimeUtil.birthdayByAge(value);
        }

        public string Birthday
        {
            get
            {
                if (birthday == new DateTime(1900, 1, 1))
                    return "";
                else
                    return birthday.ToString("yyyy-MM-dd");
            }
            set
            {
                try
                {
                    birthday = Convert.ToDateTime(value);
                }
                catch
                {
                    birthday = DateTimeUtil.defaultTime();
                }
            }
        }

        public string StartDate
        {
            get
            {
                if (start_date.isDefault())
                    return "";
                else
                    return start_date.ToString("yyyy-MM-dd");
            }
            set
            {
                try
                {
                    start_date = Convert.ToDateTime(value);
                }
                catch
                {
                    start_date = DateTimeUtil.defaultTime();
                }
            }
        }

        public string EndDate
        {
            get
            {
                if (end_date.isDefault())
                    return "";
                else
                    return end_date.ToString("yyyy-MM-dd");
            }
            set
            {
                try
                {
                    end_date = Convert.ToDateTime(value);
                }
                catch
                {
                    end_date = DateTimeUtil.defaultTime();
                }
            }
        }

        /// <summary>
        /// 判定是否为有效身份证号码
        /// </summary>
        /// <param name="id_card_number">身份证号</param>
        /// <returns>是否为有效身份证号</returns>
        public static bool isValidNumber(string id_card_number)
        {
            return id_card_number.isIDCardNumber();
        }

        /// <summary>
        /// 根据号码获取号码中所包含的信息(区域,出生年月,性别)(注:其中区域信息可能与身份证持有人真实地址不同)
        /// </summary>
        /// <param name="id_card_number">身份证号</param>
        public void setInfoForIDCardNumber(string id_card_number)
        {
            this.id_card_number = id_card_number;
            char[] chars = id_card_number.Trim().ToCharArray();
            string code = chars[0].ToString() + chars[1] + chars[2] + chars[3] + chars[4] + chars[5];
            string date;
            Province province = null;
            City city = null;
            District district = null;
            AreaUtil.areaByCode(code, out province, out city, out district);
            area_province = province.name;
            area_city = city.name;
            area_district = district.name;
            switch (chars.Length)
            {
                case 15:
                    date = "19" + chars[6] + chars[7] + "-" + chars[8] + chars[9] + "-" + chars[10] + chars[11];
                    Birthday = date;
                    try
                    {
                        int i = Convert.ToInt32(chars[14]);
                        if (i % 2 == 0)
                            gender = "女";
                        else
                            gender = "男";
                    }
                    catch { }
                    break;
                case 18:
                    date = chars[6].ToString() + chars[7] + chars[8] + chars[9] + "-" + chars[10] + chars[11] + "-" + chars[12] + chars[13];
                    Birthday = date;
                    try
                    {
                        int i = Convert.ToInt32(chars[16]);
                        if (i % 2 == 0)
                            gender = "女";
                        else
                            gender = "男";
                    }
                    catch { }
                    break;
                default:
                    area_province = "";
                    area_city = "";
                    area_district = "";
                    birthday = DateTimeUtil.defaultTime();
                    gender = "";
                    break;
            }
        }
    }
}