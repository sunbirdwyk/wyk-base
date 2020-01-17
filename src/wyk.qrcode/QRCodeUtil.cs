using System.Drawing;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using wyk.basic;

namespace wyk.qrcode
{
    public class QRCodeUtil
    {
        public static Image getQRCode(QRCodeContent content)
        {
            return getQRCode(content.content, new QRCodeConfig(content));
        }

        public static Image getQRCode(string content, QRCodeConfig config)
        {
            return getQRCode(content, config.encoding, config.encode_mode, config.code_scale, config.code_version, config.error_correction, config.background_color, config.fore_color, config.logo, config.logo_width, config.logo_height);
        }

        public static Image getQRCode(string content)
        {
            return getQRCode(content, null, QRCodeEncoder.ENCODE_MODE.BYTE, 4, 7, QRCodeEncoder.ERROR_CORRECTION.M, Color.White, Color.Black, null, 0, 0);
        }

        public static Image getQRCode(string content, Encoding encoding)
        {
            return getQRCode(content, encoding, QRCodeEncoder.ENCODE_MODE.BYTE, 4, 7, QRCodeEncoder.ERROR_CORRECTION.M, Color.White, Color.Black, null, 0, 0);
        }

        public static Image getQRCode(string content, Image logo)
        {
            return getQRCode(content, null, QRCodeEncoder.ENCODE_MODE.BYTE, 4, 7, QRCodeEncoder.ERROR_CORRECTION.M, Color.White, Color.Black, logo, 30, 30);
        }

        public static Image getQRCode(string content, Encoding encoding, Image logo)
        {
            return getQRCode(content, encoding, QRCodeEncoder.ENCODE_MODE.BYTE, 4, 7, QRCodeEncoder.ERROR_CORRECTION.M, Color.White, Color.Black, logo, 30, 30);
        }

        public static Image getQRCode(string content, Image logo, int logo_size)
        {
            return getQRCode(content, null, QRCodeEncoder.ENCODE_MODE.BYTE, 4, 7, QRCodeEncoder.ERROR_CORRECTION.M, Color.White, Color.Black, logo, logo_size, logo_size);
        }

        public static Image getQRCode(string content, Image logo, int logo_width, int logo_height)
        {
            return getQRCode(content, null, QRCodeEncoder.ENCODE_MODE.BYTE, 4, 7, QRCodeEncoder.ERROR_CORRECTION.M, Color.White, Color.Black, logo, logo_width, logo_height);
        }

        public static Image getQRCode(string content, Encoding encoding, string encode_mode, int code_scale, int code_version, string error_correction, Color background_color, Color fore_color, Image logo, int logo_width, int logo_height)
        {
            QRCodeEncoder.ENCODE_MODE Mode = QRCodeConfig.getEncodeMode(encode_mode);
            QRCodeEncoder.ERROR_CORRECTION Correction = QRCodeConfig.getErrorCorrection(error_correction);
            return getQRCode(content, encoding, Mode, code_scale, code_version, Correction, background_color, fore_color, logo, logo_width, logo_height);
        }

        public static Image getQRCode(string content, Encoding encoding, QRCodeEncoder.ENCODE_MODE encode_mode, int code_scale, int code_version, QRCodeEncoder.ERROR_CORRECTION correction, Color background_color, Color fore_color, Image logo, int logo_width, int logo_height)
        {
            if (content.isNull())
                content = "(Null)";
            if (fore_color.A == 0)
                fore_color = Color.Black;
            if (background_color.A == 0)
                background_color = Color.White;
            QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = encode_mode;
            encoder.QRCodeScale = code_scale;
            encoder.QRCodeVersion = code_version;
            encoder.QRCodeErrorCorrect = correction;
            encoder.QRCodeBackgroundColor = background_color;
            encoder.QRCodeForegroundColor = fore_color;
            Bitmap code = null;
            if (encoding == null)
                code = encoder.Encode(content);
            else
                code = encoder.Encode(content, encoding);
            if (logo != null)
            {
                try
                {
                    Bitmap logo_s = new Bitmap(logo, logo_width, logo_height);
                    Point point = new Point((code.Width - logo_width) / 2, (code.Height - logo_height) / 2);
                    Graphics g = Graphics.FromImage(code);
                    g.DrawImage(logo_s, point);
                }
                catch { }
            }
            return code;
        }
    }
}