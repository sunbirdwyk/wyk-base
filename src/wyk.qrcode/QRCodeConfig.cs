using System.Drawing;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using wyk.basic;

namespace wyk.qrcode
{
    /// <summary>
    /// 二维码设置
    /// </summary>
    public class QRCodeConfig
    {
        public Encoding encoding = null;
        public QRCodeEncoder.ENCODE_MODE encode_mode = QRCodeEncoder.ENCODE_MODE.BYTE;
        public int code_scale = 4;
        public int code_version = 7;
        public QRCodeEncoder.ERROR_CORRECTION error_correction = QRCodeEncoder.ERROR_CORRECTION.M;
        public Color background_color = Color.White;
        public Color fore_color = Color.Black;
        public Image logo = null;
        public int logo_width = 30;
        public int logo_height = 30;

        public QRCodeConfig() { }
        public QRCodeConfig(QRCodeContent content)
        {
            background_color = content.BackColor;
            code_scale = content.scale;
            code_version = content.version;
            EncodeMode = content.encode_mode;
            EncodingString = content.encoding;
            ErrorCorrection = content.checksum;
            fore_color = content.ForeColor;
            logo = content.logo;
            if (logo == null && !content.logo_base64.isNull())
            {
                logo = ImageUtil.fromBase64(content.logo_base64);
            }
            if (logo == null && !content.logo_url.isNull())
            {
                //为了支持旧版, 可以将url中放入base64结构的内容
                if (content.logo_url.StartsWith("[base64]"))
                    logo = ImageUtil.fromBase64(content.logo_url.Substring(8));
                else
                    logo = ImageUtil.fromUrl(content.logo_url);
            }
            logo_height = content.logo_height;
            logo_width = content.logo_width;
        }
        
        public string EncodingString
        {
            get
            {
                if (encoding == null)
                    return "";
                else
                    return encoding.WebName;
            }
            set
            {
                if (value == "")
                {
                    encoding = null;
                    return;
                }
                try
                {
                    encoding = Encoding.GetEncoding(value);
                }
                catch { encoding = null; }
            }
        }

        public string EncodeMode
        {
            get => getEncodeModeString(encode_mode);
            set => encode_mode = getEncodeMode(value);
        }

        public string ErrorCorrection
        {
            get => getErrorCorrectionString(error_correction);
            set => error_correction = getErrorCorrection(value);
        }

        public string BackgroundColor
        {
            get => background_color.hexString(false);
            set => background_color = value.color();
        }

        public string ForeColor
        {
            get => fore_color.hexString(false);
            set => fore_color = value.color();
        }

        public string LogoString
        {
            get
            {
                if (logo == null)
                    return "";
                return SerializeUtil.serialize(logo);
            }
            set
            {
                try
                {
                    logo = (Image)SerializeUtil.deserialize(value);
                }
                catch { logo = null; }
            }
        }

        public static string getEncodeModeString(QRCodeEncoder.ENCODE_MODE encode_mode)
        {
            switch (encode_mode)
            {
                case QRCodeEncoder.ENCODE_MODE.BYTE:
                default:
                    return "BYTE";
                case QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC:
                    return "ALPHA_NUMERIC";
                case QRCodeEncoder.ENCODE_MODE.NUMERIC:
                    return "NUMERIC";
            }
        }

        public static QRCodeEncoder.ENCODE_MODE getEncodeMode(string encode_mode_string)
        {
            switch (encode_mode_string.Trim().ToUpper())
            {
                case "BYTE":
                default:
                    return QRCodeEncoder.ENCODE_MODE.BYTE;
                case "ALPHA_NUMERIC":
                    return QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                case "NUMERIC":
                    return QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }
        }

        public static string getErrorCorrectionString(QRCodeEncoder.ERROR_CORRECTION error_correction)
        {
            switch (error_correction)
            {
                case QRCodeEncoder.ERROR_CORRECTION.M:
                default:
                    return "M";
                case QRCodeEncoder.ERROR_CORRECTION.H:
                    return "H";
                case QRCodeEncoder.ERROR_CORRECTION.L:
                    return "L";
                case QRCodeEncoder.ERROR_CORRECTION.Q:
                    return "Q";
            }
        }

        public static QRCodeEncoder.ERROR_CORRECTION getErrorCorrection(string error_correction_string)
        {
            switch (error_correction_string.Trim().ToUpper())
            {
                case "M":
                default:
                    return QRCodeEncoder.ERROR_CORRECTION.M;
                case "H":
                    return QRCodeEncoder.ERROR_CORRECTION.H;
                case "L":
                    return QRCodeEncoder.ERROR_CORRECTION.L;
                case "Q":
                    return QRCodeEncoder.ERROR_CORRECTION.Q;
            }
        }
    }
}