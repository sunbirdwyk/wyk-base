using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

namespace wyk.pdf
{
    public class PDFUIUtil
    {
        /// <summary>
        /// 设置PdfPCell的HorizontalAlignment(int型)
        /// </summary>
        /// <param name="alignment"></param>
        /// <param name="cell"></param>
        public static void setHorizontalAlignmentToCell(int alignment, ref PdfPCell cell)
        {
            if (alignment < 0)
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
            else if (alignment == 0)
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
            else
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        }

        /// <summary>
        /// 根据字符串型设置的列宽列表获取float数组的列宽列表
        /// </summary>
        /// <param name="column_widths">字符串型列宽列表(,分隔)</param>
        /// <param name="column_count">总列数</param>
        /// <returns></returns>
        public static float[] getColumnWidthsPercentage(string column_widths, int column_count)
        {
            return getColumnWidthsPercentage(column_widths, ',', column_count);
        }

        /// <summary>
        /// 根据字符串型设置的列宽列表获取float数组的列宽列表
        /// </summary>
        /// <param name="column_widths">字符串型列宽列表</param>
        /// <param name="separator">分隔符</param>
        /// <param name="column_count">总列数</param>
        /// <returns></returns>
        public static float[] getColumnWidthsPercentage(string column_widths, char separator, int column_count)
        {
            float[] widths = new float[column_count];
            string[] widthsetting = column_widths.Split(separator);
            float wleft = 100;
            int zerocount = 0;
            for (int j = 0; j < column_count; j++)
            {
                if (wleft == 0)
                {
                    widths[j] = 0;
                    zerocount++;
                    continue;
                }
                double w = 0;
                try
                {
                    w = Convert.ToDouble(widthsetting[j]);
                }
                catch { }
                if (w > wleft)
                {
                    w = wleft;
                    widths[j] = wleft;
                    wleft = 0;
                }
                else
                {
                    widths[j] = (float)w;
                    wleft = wleft - (float)w;
                }
                if (w == 0)
                    zerocount++;
            }
            if (wleft > 0 && zerocount > 0)
            {
                float w = wleft / zerocount;
                for (int i = 0; i < widths.Length; i++)
                {
                    if (widths[i] == 0)
                        widths[i] = w;
                }
            }
            return widths;
        }
    }
}
