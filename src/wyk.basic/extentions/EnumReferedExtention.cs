using System;

namespace wyk.basic
{
    public static class EnumReferedExtention
    {
        public static string display(this Enum en)
        {
            return EnumUtil.getDisplay(en);
        }

        public static string name(this Enum en)
        {
            return en.ToString();
        }

        public static int value(this Enum en)
        {
            try
            {
                return Convert.ToInt32(en);
            }
            catch { }
            return 0;
        }

        public static ValuePair valuepair(this Enum en)
        {
            try
            {
                return new ValuePair(en.display(), en.name());
            }
            catch { }
            return null;
        }
    }
}
