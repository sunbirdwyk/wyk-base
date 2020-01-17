using System;
using System.Drawing;

namespace wyk.ui
{
    public partial class ExFormColorSelector : ExForm
    {
        public Color color = Color.Black;
        public ExFormColorSelector(ExFormBasic parent,Color color)
        {
            this.color = color;
            SuperiorForm = parent;
            InitializeComponent();
        }

        private void ExFormColorSelector_Load(object sender, EventArgs e)
        {

        }
    }
}