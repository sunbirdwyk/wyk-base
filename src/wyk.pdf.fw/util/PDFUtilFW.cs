using AxAcroPDFLib;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using wyk.basic;

namespace wyk.pdf
{
    public class PDFUtilFW
    {
        const string PDF_BODY_NAME = "PDF_BODY";
        /// <summary>
        /// 打印PDF文件
        /// </summary>
        /// <param name="printer_name"></param>
        /// <param name="file_path"></param>
        /// <param name="ax_acropdfunit"></param>
        /// <returns></returns>
        public static string print(string printer_name, string file_path, AxAcroPDF ax_acropdfunit)
        {
            try
            {
                if (!printer_name.isNull())
                {
                    string default_printer = PrintUtil.defaultPrinter();
                    if (default_printer != printer_name)
                    {
                        PrintUtil.setDefaultPrinter(printer_name);
                        while (PrintUtil.defaultPrinter() != printer_name)
                        {
                            Thread.Sleep(50);
                        }
                        Thread.Sleep(1000);
                    }
                }
                ax_acropdfunit.LoadFile(file_path);
                ax_acropdfunit.printAllFit(true);
                return "";
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        /// <summary>
        /// 打印PDF文件
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="ax_acropdfunit"></param>
        /// <returns></returns>
        public static string print(string file_path, AxAcroPDF ax_acropdfunit)
        {
            return print("", file_path, ax_acropdfunit);
        }

        /// <summary>
        /// 在一个Panel中显示pdf文件(Form)
        /// </summary>
        /// <param name="body_panel">显示pdf文件的panel</param>
        /// <param name="pdf_path">pdf文件路径</param>
        /// <param name="ParentFormType">父窗体的类别</param>
        /// <returns>AxAcroPDF 实例, 显示失败返回null</returns>
        public static object show(Panel body_panel, string pdf_path)
        {
            if ((!File.Exists(pdf_path) && !PDFUtil.JudgeFileExist(pdf_path)) || !(pdf_path.Trim().ToLower().EndsWith(".pdf")))
                return null;
            if (body_panel == null)
                return null;
            AxAcroPDF pdf = null;
            foreach (Control c in body_panel.Controls)
            {
                if (c.Name == PDF_BODY_NAME)
                {
                    try
                    {
                        pdf = c as AxAcroPDF;
                        break;
                    }
                    catch { }
                }
            }
            if (pdf == null)
            {
                try
                {
                    pdf = new AxAcroPDF();
                    ((System.ComponentModel.ISupportInitialize)(pdf)).BeginInit();
                    pdf.Dock = DockStyle.Fill;
                    pdf.Enabled = true;
                    pdf.Location = new System.Drawing.Point(0, 0);
                    pdf.Name = PDF_BODY_NAME;
                    pdf.TabIndex = 1;
                    pdf.Parent = body_panel;
                    ((System.ComponentModel.ISupportInitialize)(pdf)).EndInit();
                    pdf.Visible = true;
                    pdf.Height = body_panel.Height;
                    pdf.Width = body_panel.Width;
                }
                catch
                {
                    MessageBox.Show("PDF显示组件初始化错误,请检查是否安装Acrobat Reader 9及以上版本!");
                    return null;
                }
            }
            pdf.src = pdf_path;
            pdf.Invalidate();
            return pdf;
        }
    }
}