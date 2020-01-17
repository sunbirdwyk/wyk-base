using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wyk.basic;
using wyk.ui.forms.Properties;

namespace wyk.ui
{
    public class ExConnectionStatus : Panel
    {
        public ExConnectionStatus()
        {
            initialize();
        }

        private PictureBox pb = null;
        private Label lbl = null;
        private ConnectionStatus _connection_status = ConnectionStatus.Unknown;

        [Description("当前连接状态")]
        public ConnectionStatus ConnectionStatus
        {
            get => _connection_status;
            set => lbl.Text = value.display();
        }

        private void initialize()
        {
            Height = 20;
            pb = new PictureBox();
            pb.Width = 16;
            pb.Height = 16;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.Location = new Point(0, 2);
            pb.Anchor = AnchorStyles.Left;
            Controls.Add(pb);
            lbl = new Label();
            lbl.AutoSize = false;
            lbl.Font = this.Font;
            lbl.ForeColor = Color.Black;
            lbl.TextChanged += StatusTextChanged;
            lbl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Location = new Point(20, 1);
            lbl.Height = 18;
            Controls.Add(lbl);
            lbl.Text = "未知";
        }

        private void StatusTextChanged(object sender, System.EventArgs e)
        {
            switch (lbl.Text)
            {
                default:
                    lbl.Text = "未知";
                    _connection_status = ConnectionStatus.Unknown;
                    break;
                case "未知":
                    pb.BackgroundImage = Resources.conn_unknown;
                    lbl.ForeColor = Color.FromArgb(93, 93, 93);
                    _connection_status = ConnectionStatus.Unknown;
                    break;
                case "连接中":
                    pb.BackgroundImage = Resources.connecting;
                    lbl.ForeColor = Color.FromArgb(54, 160, 254);
                    _connection_status = ConnectionStatus.Connecting;
                    break;
                case "已连接":
                    pb.BackgroundImage = Resources.connected;
                    lbl.ForeColor = Color.FromArgb(78, 214, 110);
                    _connection_status = ConnectionStatus.Connected;
                    break;
                case "已断开":
                    pb.BackgroundImage = Resources.disconnected;
                    lbl.ForeColor = Color.FromArgb(254, 6, 6);
                    _connection_status = ConnectionStatus.Disconnected;
                    break;
            }
            var width = lbl.PreferredWidth;
            if (width <= 0)
                width = 5;
            lbl.Width = width;
            this.Width = lbl.Left + lbl.Width + 1;
        }
    }
}
