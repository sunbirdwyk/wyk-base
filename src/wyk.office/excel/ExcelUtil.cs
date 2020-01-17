using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace wyk.office
{
    public class ExcelUtil
    {
        /// <summary>
        /// DataTable导出到Excel
        /// </summary>
        /// <param name="data">数据表</param>
        /// <param name="show_header">是否显示列名</param>
        /// <param name="path">导出路径</param>
        /// <param name="display_excel">是否显示Excel界面</param>
        /// <param name="bgw">后台运行器(不需要显示过程状态时传入null即可)</param>
        /// <returns>错误信息</returns>
        public static string dataTableToExcel(DataTable data, bool show_header, string path, bool display_excel, BackgroundWorker bgw)
        {
            ExcelUnit excel = new ExcelUnit();
            string msg = "";
            try
            {
                if (File.Exists(path))
                    try
                    {
                        File.Delete(path);
                    }
                    catch { }
                msg = excel.CreateFile(path, display_excel, false);
                int step = 1;
                Excel.Range range;
                if (msg == "")
                {
                    int cols = data.Columns.Count;
                    if (show_header)
                    {
                        range = excel.GetRow(1);
                        excel.SetCellFont(range, "宋体", 14, true);
                        for (int i = 0; i < cols; i++)
                        {
                            excel.SetCellValue(1, i + step, data.Columns[i].ColumnName);
                        }
                        step++;
                    }
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        range = excel.GetRow(i + step);
                        excel.SetCellFont(range, "宋体", 11, false);
                        range.NumberFormat = "@";
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            excel.SetCellValue(i + step, j + 1, data.Rows[i][j].ToString());
                        }
                        if (i % 10 == 0)
                        {
                            if (bgw != null)
                            {
                                bgw.ReportProgress((i + 1) * 100 / data.Rows.Count);
                            }
                        }
                    }
                    try
                    {
                        range = excel.GetRange(1, 1, 1, data.Rows.Count).EntireColumn;
                        excel.SetRangeColumnAutofit(range);
                    }
                    catch { }
                    excel.SaveExcel();
                }
                try
                {
                    excel.CloseApplication();
                }
                catch { }
            }
            catch (Exception ex) { msg = ex.ToString(); }
            try
            {
                excel.CloseApplication();
            }
            catch { }
            return msg;
        }

        ///<summary>
        /// 将Excel文件转换为HTML文件
        ///</summary>
        ///<param name="source_path">Excel文件路径（绝对）</param>
        ///<param name="target_path">生成的Html文件路径（绝对），路径的目录结构必须存在，否则保存失败</param>
        ///<returns>是否执行成功</returns>
        public static bool toHtml(string source_path, string target_path)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            try
            {
                if (File.Exists(target_path))
                    File.Delete(target_path);
                workbook = excelApp.Application.Workbooks.Open(source_path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Worksheets[1];
                object ofmt = Excel.XlFileFormat.xlHtml;
                workbook.SaveAs(target_path, ofmt, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                object osave = false;
                workbook.Close(osave, Type.Missing, Type.Missing);//逐步关闭所有使用的对象
                excelApp.Quit();
                Marshal.ReleaseComObject(worksheet);
                worksheet = null;
                GC.Collect();//垃圾回收
                Marshal.ReleaseComObject(workbook);
                workbook = null;
                GC.Collect();
                Marshal.ReleaseComObject(excelApp.Application.Workbooks);
                GC.Collect();
                Marshal.ReleaseComObject(excelApp);
                excelApp = null;
                GC.Collect();
                Process[] process = Process.GetProcessesByName("EXCEL");//依据时间杀灭进程
                foreach (Process p in process)
                {
                    if (DateTime.Now.Second - p.StartTime.Second > 0 && DateTime.Now.Second - p.StartTime.Second < 5)
                    {
                        p.Kill();
                    }
                }
                //Thread.Sleep(3000);
            }
        }
    }
}
