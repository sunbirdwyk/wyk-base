using wyk.ui;

namespace wyk.db.tool.TableMaintain
{
    public partial class FrmTextShow : ExForm
    {
        
        public FrmTextShow(ExFormBasic parent,string title, string content)
        {
            SuperiorForm = parent;
            InitializeComponent();
            Text = title;
            txtContent.Text = content;
        }
    }
}
