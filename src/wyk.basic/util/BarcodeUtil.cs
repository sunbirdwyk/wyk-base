using System.Collections;
using System.Drawing;

namespace wyk.basic.barcode
{
    /// <summary>
    /// 使用常规方式生成条码(仅支持Code39, 如需其他条码格式, 请使用WYK.PDF.dll)
    /// </summary>
    public class BarcodeUtil
    {
        /// <summary>
        /// 获取Code39条码(12位编码)
        /// </summary>
        /// <param name="code">条码内容</param>
        /// <param name="width">单位宽度(px)</param>
        /// <param name="height">高度(px)</param>
        /// <param name="errorMessage">错误信息</param>
        /// <returns>条码图片Bitmap</returns>
        public static Bitmap getCode39_12Digit(string code, int width, int height, ref string errorMessage)
        {
            Hashtable ht = new Hashtable();
            #region 39码 12位
            ht.Add('A', "110101001011");
            ht.Add('B', "101101001011");
            ht.Add('C', "110110100101");
            ht.Add('D', "101011001011");
            ht.Add('E', "110101100101");
            ht.Add('F', "101101100101");
            ht.Add('G', "101010011011");
            ht.Add('H', "110101001101");
            ht.Add('I', "101101001101");
            ht.Add('J', "101011001101");
            ht.Add('K', "110101010011");
            ht.Add('L', "101101010011");
            ht.Add('M', "110110101001");
            ht.Add('N', "101011010011");
            ht.Add('O', "110101101001");
            ht.Add('P', "101101101001");
            ht.Add('Q', "101010110011");
            ht.Add('R', "110101011001");
            ht.Add('S', "101101011001");
            ht.Add('T', "101011011001");
            ht.Add('U', "110010101011");
            ht.Add('V', "100110101011");
            ht.Add('W', "110011010101");
            ht.Add('X', "100101101011");
            ht.Add('Y', "110010110101");
            ht.Add('Z', "100110110101");
            ht.Add('0', "101001101101");
            ht.Add('1', "110100101011");
            ht.Add('2', "101100101011");
            ht.Add('3', "110110010101");
            ht.Add('4', "101001101011");
            ht.Add('5', "110100110101");
            ht.Add('6', "101100110101");
            ht.Add('7', "101001011011");
            ht.Add('8', "110100101101");
            ht.Add('9', "101100101101");
            ht.Add('+', "100101001001");
            ht.Add('-', "100101011011");
            ht.Add('*', "100101101101");
            ht.Add('/', "100100101001");
            ht.Add('%', "101001001001");
            ht.Add('$', "100100100101");
            ht.Add('.', "110010101101");
            ht.Add(' ', "100110101101");
            #endregion

            code = "*" + code.ToUpper() + "*";

            string result_bin = "";//二进制串

            try
            {
                foreach (char ch in code)
                {
                    result_bin += ht[ch].ToString();
                    result_bin += "0";//间隔，与一个单位的线条宽度相等
                }
            }
            catch { errorMessage = "存在不允许的字符！"; return null; }

            Bitmap bm = new Bitmap(width * result_bin.Length, height);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(Brushes.White, 0, 0, bm.Width, bm.Height);
            int start_x = 0;
            foreach (char c in result_bin)
            {
                if (c != '0')
                {
                    g.FillRectangle(Brushes.Black, start_x, 0, width, bm.Height);
                }
                start_x += width;
            }
            g.Dispose();
            return bm;
        }

        /// <summary>
        /// 获取Code39条码(9位编码)
        /// </summary>
        /// <param name="code">条码内容</param>
        /// <param name="width">单位宽度(px)</param>
        /// <param name="height">高度(px)</param>
        /// <param name="errorMessage">错误信息</param>
        /// <returns>条码图片Bitmap</returns>
        public static Bitmap getCode39_9Digit(string code, int width, int height, ref string errorMessage)
        {
            Hashtable ht = new Hashtable();
            #region 39码 9位
            ht.Add('0', "000110100");
            ht.Add('1', "100100001");
            ht.Add('2', "001100001");
            ht.Add('3', "101100000");
            ht.Add('4', "000110001");
            ht.Add('5', "100110000");
            ht.Add('6', "001110000");
            ht.Add('7', "000100101");
            ht.Add('8', "100100100");
            ht.Add('9', "001100100");
            ht.Add('A', "100001001");
            ht.Add('B', "001001001");
            ht.Add('C', "101001000");
            ht.Add('D', "000011001");
            ht.Add('E', "100011000");
            ht.Add('F', "001011000");
            ht.Add('G', "000001101");
            ht.Add('H', "100001100");
            ht.Add('I', "001001100");
            ht.Add('J', "000011100");
            ht.Add('K', "100000011");
            ht.Add('L', "001000011");
            ht.Add('M', "101000010");
            ht.Add('N', "000010011");
            ht.Add('O', "100010010");
            ht.Add('P', "001010010");
            ht.Add('Q', "000000111");
            ht.Add('R', "100000110");
            ht.Add('S', "001000110");
            ht.Add('T', "000010110");
            ht.Add('U', "110000001");
            ht.Add('V', "011000001");
            ht.Add('W', "111000000");
            ht.Add('X', "010010001");
            ht.Add('Y', "110010000");
            ht.Add('Z', "011010000");
            ht.Add('-', "010000101");
            ht.Add('.', "110000100");
            ht.Add(' ', "011000100");
            ht.Add('*', "010010100");
            ht.Add('$', "010101000");
            ht.Add('/', "010100010");
            ht.Add('+', "010001010");
            ht.Add('%', "000101010");
            #endregion

            code = "*" + code.ToUpper() + "*";

            string result_bin = "";//二进制串

            try
            {
                foreach (char ch in code)
                {
                    result_bin += ht[ch].ToString();
                    result_bin += "0";//间隔，与一个单位的线条宽度相等
                }
            }
            catch { errorMessage = "存在不允许的字符！"; return null; }

            Bitmap bm = new Bitmap(width * result_bin.Length, height);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(Brushes.White, 0, 0, bm.Width, bm.Height);
            int start_x = 0;
            foreach (char c in result_bin)
            {
                if (c != '0')
                {
                    g.FillRectangle(Brushes.Black, start_x, 0, width, bm.Height);
                }
                start_x += width;
            }
            g.Dispose();
            return bm;
        }
    }
}