using System.Drawing;
using System.Windows.Forms;

namespace wyk.ui
{
    public class ExFontSelector : ComboBox
    {
        public ExFontSelector()
        {
            Font = new Font("微软雅黑", 9, FontStyle.Regular);
            Width = 150;
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += ExFontSelector_DrawItem;
            foreach(var ff in FontFamily.Families)
            {
                Items.Add(ff.Name);
            }
        }

        private void ExFontSelector_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string ff = Items[e.Index].ToString();
            e.Graphics.DrawString(ff, new Font(ff, Font.Size, Font.Style), new SolidBrush(ForeColor), e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}
