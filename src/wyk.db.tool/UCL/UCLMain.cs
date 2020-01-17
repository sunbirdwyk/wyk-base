using System.Windows.Forms;
using wyk.basic;

namespace wyk.db.tool.UCL
{
    public class UCLMain : UserControlList
    {
        public override UserControl userControlByName(string sender_name, Control parentForm)
        {
            UserControl uc = null;
            try
            {
                FrmMain frm = (FrmMain)parentForm;
                switch (sender_name)
                {
                    case "tsbQuery":
                        uc = new Query.UCQuery(frm);
                        break;
                    case "tsbSchema":
                        uc = new Schema.UCSchema(frm);
                        break;
                    case "btnTableMaintain":
                        uc = new TableMaintain.UCTableMaintain(frm);
                        break;
                    default:
                        break;
                }
            }
            catch { }
            return uc;
        }
    }
}
