using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using wyk.basic;

namespace wyk.pdf
{
    public partial class PDFUtil
    {
        /// <summary>
        /// DataTable导出到PDF
        /// </summary>
        /// <param name="data">数据表</param>
        /// <param name="title">标题</param>
        /// <param name="subtitle">副标题</param>
        /// <param name="show_table_header">是否显示表头</param>
        /// <param name="content_header_rows">表头行数</param>
        /// <param name="bold_rows">加粗的行列表(,分隔)</param>
        /// <param name="bold_cols">加粗的列列表(,分隔)</param>
        /// <param name="column_widths">列宽设置列表</param>
        /// <param name="file_path">导出文件路径</param>
        public static void dataTableToPDF(DataTable data, string title, string subtitle, bool show_table_header, int content_header_rows, string bold_rows, string bold_cols, string column_widths, string file_path)
        {
            dataTableToPDF(data, title, subtitle, false, show_table_header, content_header_rows, bold_rows, bold_cols, column_widths, file_path);
        }

        /// <summary>
        /// DataTable导出到PDF
        /// </summary>
        /// <param name="data">数据表</param>
        /// <param name="title">标题</param>
        /// <param name="subtitle">副标题</param>
        /// <param name="show_total_rows">是否显示总行数</param>
        /// <param name="show_table_header">是否显示表头</param>
        /// <param name="content_header_rows">表头行数</param>
        /// <param name="bold_rows">加粗的行列表(,分隔)</param>
        /// <param name="bold_cols">加粗的列列表(,分隔)</param>
        /// <param name="column_widths">列宽设置列表</param>
        /// <param name="file_path">导出文件路径</param>
        public static void dataTableToPDF(DataTable data, string title, string subtitle, bool show_total_rows, bool show_table_header, int content_header_rows, string bold_rows, string bold_cols, string column_widths, string file_path)
        {
            dataTableToPDF(data, title, subtitle, show_total_rows, "", show_table_header, content_header_rows, bold_rows, bold_cols, column_widths, file_path);
        }

        /// <summary>
        /// DataTable导出到PDF
        /// </summary>
        /// <param name="data">数据表</param>
        /// <param name="title">标题</param>
        /// <param name="subtitle">副标题</param>
        /// <param name="show_total_rows">是否显示总行数</param>
        /// <param name="gender_row_header">是否分性别显示总数, 是则填入性别行表头</param>
        /// <param name="show_table_header">是否显示表头</param>
        /// <param name="content_header_rows">表头行数</param>
        /// <param name="bold_rows">加粗的行列表(,分隔)</param>
        /// <param name="bold_cols">加粗的列列表(,分隔)</param>
        /// <param name="column_widths">列宽设置列表</param>
        /// <param name="file_path">导出文件路径</param>
        public static void dataTableToPDF(DataTable data, string title, string subtitle, bool show_total_rows, string gender_row_header, bool show_table_header, int content_header_rows, string bold_rows, string bold_cols, string column_widths, string file_path)
        {
            Document document = new Document();
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(file_path, FileMode.Create));
                document.Open();
                document.SetMargins(36, 36, 36, 36);
                PdfContentByte cb = writer.DirectContentUnder;
                cb.BeginText();
                cb.SetFontAndSize(BaseFont.CreateFont(), 11);
                cb.ShowText("  ");
                cb.EndText();
                if (data.Columns.Count > 0)
                {
                    PdfPTable mainTable = new PdfPTable(data.Columns.Count);
                    mainTable.WidthPercentage = 100;
                    try
                    {
                        if (column_widths != "")
                        {
                            /*
                            string[] widths = column_widths.Split(',');
                            float[] widthList = new float[data.Columns.Count];
                            float left = 100;
                            for (int i = 0; i < widthList.Length; i++)
                            {
                                try
                                {
                                    float w;
                                    if (left == 0)
                                        w = 0;
                                    else
                                        try
                                        {
                                            w = (float)Convert.ToDouble(widths[i]);
                                        }
                                        catch { w = left / (widthList.Length - i); }
                                    left = left - w;
                                    if (left >= 0)
                                        widthList[i] = w;
                                    else
                                    {
                                        widthList[i] = left;
                                        left = 0;
                                    }
                                }
                                catch { }
                            }*/
                            mainTable.SetWidths(PDFUIUtil.getColumnWidthsPercentage(column_widths, data.Columns.Count));
                        }
                    }
                    catch { }
                    if (title != "")
                    {
                        Font font = new Font(PDFFontUtil.baseFontByName("微软雅黑"), 14, Font.BOLD, BaseColor.Black);
                        PdfPCell cell = new PdfPCell(new Paragraph(title, font));
                        cell.Colspan = data.Columns.Count;
                        cell.Border = Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        mainTable.AddCell(cell);
                    }
                    if (subtitle != "")
                    {
                        Font font = new Font(PDFFontUtil.baseFontByName("微软雅黑"), 12, Font.NORMAL, BaseColor.Black);
                        PdfPCell cell = new PdfPCell(new Paragraph(subtitle, font));
                        cell.Colspan = data.Columns.Count;
                        cell.Border = Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        mainTable.AddCell(cell);
                    }
                    Font fontHeader = new Font(PDFFontUtil.baseFontByName("微软雅黑"), 12, Font.BOLD, BaseColor.Black);
                    Font fontTextTitle = new Font(PDFFontUtil.baseFontByName("微软雅黑"), 10, Font.BOLD, BaseColor.Black);
                    Font fontContent = new Font(PDFFontUtil.baseFontByName("微软雅黑"), 10, Font.NORMAL, BaseColor.Black);
                    string[] boldRows = bold_rows.Split(',');
                    string[] boldCols = bold_cols.Split(',');
                    if (show_table_header)
                    {
                        for (int i = 0; i < data.Columns.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Paragraph(data.Columns[i].ColumnName, fontHeader));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            mainTable.AddCell(cell);
                        }
                    }
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            string value = data.Rows[i][j].ToString();
                            if (value == "[合并列]" || value == "[合并行]")
                                continue;
                            PdfPCell cell;
                            if (i < content_header_rows)
                                cell = new PdfPCell(new Paragraph(value, fontHeader));
                            else
                            {
                                if (listContains(boldRows, i) || listContains(boldCols, j))
                                    cell = new PdfPCell(new Paragraph(value, fontTextTitle));
                                else
                                    cell = new PdfPCell(new Paragraph(value, fontContent));
                            }
                            int colSpan = 1;
                            int next = j + 1;
                            while (true)
                            {
                                if (next >= data.Columns.Count)
                                    break;
                                if (data.Rows[i][next].ToString() != "[合并列]")
                                    break;
                                colSpan = colSpan + 1;
                                next = next + 1;
                            }
                            cell.Colspan = colSpan;
                            if (colSpan == 1)
                            {
                                int rowSpan = 1;
                                next = i + 1;
                                while (true)
                                {
                                    if (next >= data.Rows.Count)
                                        break;
                                    if (data.Rows[next][j].ToString() != "[合并行]")
                                        break;
                                    rowSpan = rowSpan + 1;
                                    next = next + 1;
                                }
                                cell.Rowspan = rowSpan;
                            }
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            mainTable.AddCell(cell);
                        }
                    }
                    if (show_total_rows)
                    {
                        int gender_index = -1;
                        for (int i = 0; i < data.Columns.Count; i++)
                        {
                            if (data.Columns[i].ColumnName.Trim() == gender_row_header.Trim())
                            {
                                gender_index = i;
                                break;
                            }
                        }
                        string total_count_string = "";
                        if (gender_index < 0)
                        {
                            total_count_string = "总记录数:" + data.Rows.Count;
                        }
                        else
                        {
                            int male_count = 0;
                            int female_count = 0;
                            for (int i = 0; i < data.Rows.Count; i++)
                            {
                                string gender = data.Rows[i][gender_index].ToString().ToLower();
                                if (gender == "男" || gender == "m" || gender == "male")
                                    male_count++;
                                if (gender == "女" || gender == "f" || gender == "female")
                                    female_count++;
                            }
                            total_count_string = "总记录数:" + data.Rows.Count + "; 其中 男 " + male_count + ", 女 " + female_count;
                        }
                        PdfPCell footer_cell = new PdfPCell(new Paragraph(total_count_string, fontContent));
                        footer_cell.Colspan = data.Columns.Count;
                        footer_cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        mainTable.AddCell(footer_cell);
                    }
                    document.Add(mainTable);
                }
            }
            catch { }//(DocumentException de)
            try
            {
                document.Close();
            }
            catch { }
        }

        /// <summary>
        /// string数组是否包含int的值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool listContains(string[] list, int value)
        {
            for (int i = 0; i < list.Length; i++)
            {
                try
                {
                    if (Convert.ToInt32(list[i]) == value)
                        return true;
                }
                catch { }
            }
            return false;
        }

        /// <summary>
        /// 复制一个pdf文件内容到当前Document
        /// </summary>
        /// <param name="source_pdf_path">源pdf文件路径</param>
        /// <param name="document">当前Document</param>
        /// <param name="writer">当前Writer</param>
        /// <returns></returns>
        public static string copyContent(string source_pdf_path, Document document, PdfWriter writer)
        {
            try
            {
                PdfReader reader = new PdfReader(source_pdf_path);
                int total_pages = reader.NumberOfPages;
                PdfContentByte cb = writer.DirectContent;
                for (int i = 1; i <= total_pages; i++)
                {
                    Rectangle psize = reader.GetPageSize(i);
                    if (i > 1)
                        document.NewPage();
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    cb.AddTemplate(page, 0, 0);
                }
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        /// <summary>
        /// 获取默认安装Reader路径
        /// </summary>
        /// <returns></returns>
        public static string defaultReaderPath()
        {
            RegistryKey rkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\AcroRd32.exe");
            object value = rkey.GetValue("");
            if (value != null && value.ToString() != "")
            {
                return value.ToString();
            }
            return "";
        }

        /// <summary>
        /// 使用 Adobe Reader来打印pdf文件
        /// </summary>
        /// <param name="printer_name"></param>
        /// <param name="file_path"></param>
        /// <param name="reader_path"></param>
        /// <returns></returns>
        public static string print(string printer_name, string file_path, string reader_path)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.Verb = "";
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                if (reader_path.isNull())
                    reader_path = defaultReaderPath();
                startInfo.FileName = reader_path;
                var arg = "/n /t \"" + file_path + "\"";
                if (!printer_name.isNull())
                    arg += " \"" + printer_name + "\"";
                startInfo.Arguments = arg;
                process.StartInfo = startInfo;
                process.Start();
                return "";
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        /// <summary>
        /// 使用 Adobe Reader来打印pdf文件(默认打印机)
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="reader_path"></param>
        /// <returns></returns>
        public static string print(string file_path, string reader_path)
        {
            return print("", file_path, reader_path);
        }

        /// <summary>
        /// 使用 Adobe Reader来打印pdf文件(默认打印机, 默认reader路径)
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public static string print(string file_path)
        {
            return print("", file_path, "");
        }

        //判断网络文件是否存在
        public static bool JudgeFileExist(string url)
        {
            try
            {
                //创建根据网络地址的请求对象
                System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.CreateDefault(new Uri(url));
                httpWebRequest.Method = "HEAD";
                httpWebRequest.Timeout = 1000;
                //返回响应状态是否是成功比较的布尔值
                return (((System.Net.HttpWebResponse)httpWebRequest.GetResponse()).StatusCode == System.Net.HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}