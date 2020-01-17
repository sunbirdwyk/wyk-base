using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using wyk.basic;
using wyk.pdf;

namespace wyk.db.tool.Util
{
    /// <summary>
    /// 说明文档操作类, 用于导出表设计的说明文档
    /// </summary>
    public class DBSpecUtil
    {
        public static string exportPDF(string file_path, string db_path)
        {
            PDFUnit pdf = null;
            try
            {
                pdf = PDFUnit.create(file_path);
                //标题
                PdfPCell cell = PdfPCellUnit.instance("表结构说明", 20, true, UIPadding.instanceByPt(10));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdf.main_table.AddCell(cell);
                //版本号
                DBInitDataConfig config = new DBInitDataConfig();
                config.loadFrom(db_path);
                cell = PdfPCellUnit.instance("当前版本号:" + config.CurrentDBVersion, 10);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdf.main_table.AddCell(cell);
                //各个表结构说明
                List<DBTable> tables = new List<DBTable>();
                try
                {
                    string[] table_paths = Directory.GetFiles(db_path, "*.table");
                    foreach (string table_p in table_paths)
                    {
                        DBTable tb = DBTable.fromXmlFile(table_p);
                        if (tb.table_name != "")
                        {
                            tables.Add(tb);
                        }
                    }
                }
                catch { }
                int index = 1;
                Font fName = PDFFontUtil.instance(14, true);
                Font fDesc = PDFFontUtil.instance(10);
                Font fHeader = PDFFontUtil.instance(9, true);
                Font fContent = PDFFontUtil.instance(9);
                System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(150, 150, 150);
                foreach (DBTable dbt in tables)
                {
                    cell = PdfPCellUnit.instance(index + ". " + dbt.table_name, fName);
                    pdf.main_table.AddCell(cell);
                    if (dbt.table_description != "")
                    {
                        cell = PdfPCellUnit.instance(dbt.table_description, fDesc);
                        pdf.main_table.AddCell(cell);
                    }
                    PdfPTable subtable = new PdfPTable(new float[] { 25f, 15f, 5f, 5f, 50f });
                    subtable.WidthPercentage = 100;
                    //表描述header
                    cell = PdfPCellUnit.instance("字段名", fHeader);
                    cell.setBorder(borderColor);
                    subtable.AddCell(cell);
                    cell = PdfPCellUnit.instance("字段类型", fHeader);
                    cell.setBorder(borderColor);
                    subtable.AddCell(cell);
                    cell = PdfPCellUnit.instance("主", fHeader);
                    cell.setBorder(borderColor);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    subtable.AddCell(cell);
                    cell = PdfPCellUnit.instance("空", fHeader);
                    cell.setBorder(borderColor);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    subtable.AddCell(cell);
                    cell = PdfPCellUnit.instance("说明", fHeader);
                    cell.setBorder(borderColor);
                    subtable.AddCell(cell);
                    //将子表插入文档(每行插入一次)
                    cell = new PdfPCell(subtable);
                    cell.setPadding(0);
                    pdf.main_table.AddCell(cell);

                    //列描述
                    Image img_checked = Image.GetInstance(global::wyk.db.tool.Properties.Resources.checkbox_checked, BaseColor.White);
                    img_checked.ScaleAbsolute(12, 12);
                    Image img_unchecked = Image.GetInstance(global::wyk.db.tool.Properties.Resources.checkbox_unchecked, BaseColor.White);
                    img_unchecked.ScaleAbsolute(12, 12);
                    foreach (DBColumn dbc in dbt.columns)
                    {
                        subtable = new PdfPTable(new float[] { 25f, 15f, 5f, 5f, 50f });
                        subtable.WidthPercentage = 100;
                        cell = PdfPCellUnit.instance(dbc.name, fContent);
                        cell.setBorder(borderColor);
                        subtable.AddCell(cell);
                        cell = PdfPCellUnit.instance(dbc.dataTypeForDB(DBType.SqlServer), fContent);
                        cell.setBorder(borderColor);
                        subtable.AddCell(cell);
                        cell = PdfPCellUnit.instance(dbc.is_primary ? img_checked : img_unchecked);
                        cell.setBorder(borderColor);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        subtable.AddCell(cell);
                        cell = PdfPCellUnit.instance(dbc.allow_null ? img_checked : img_unchecked);
                        cell.setBorder(borderColor);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        subtable.AddCell(cell);
                        cell = PdfPCellUnit.instance(dbc.data_description, fContent);
                        cell.setBorder(borderColor);
                        subtable.AddCell(cell);
                        //将子表插入文档(每行插入一次)
                        cell = new PdfPCell(subtable);
                        cell.setPadding(0);
                        pdf.main_table.AddCell(cell);
                    }
                    //插入个空行分隔
                    cell = PdfPCellUnit.instance();
                    pdf.main_table.AddCell(cell);
                    index++;
                }

                pdf.close();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
            finally
            {
                try { pdf.close(); } catch { }
            }
        }
    }
}
