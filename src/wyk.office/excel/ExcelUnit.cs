using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace wyk.office
{
    public class ExcelUnit
    {
        #region 变量
        Excel.Application application = null;
        Excel.Workbooks workbooks = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;

        int current_worksheet_index = 1;

        string file_path = "";
        #endregion

        #region 属性
        public int CurrentWorkSheetIndex
        {
            get => current_worksheet_index;
            set => current_worksheet_index = value;
        }
        public string FilePath
        {
            get => file_path;
            set => file_path = value;
        }
        public string FileName
        {
            get
            {
                string[] parts = file_path.Split('\\');
                return parts[parts.Length - 1];
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExcelUnit()
        {
            application = null;
            workbooks = null;
            workbook = null;
            worksheet = null;
            current_worksheet_index = 1;
        }

        public string OpenFile(bool IsVisible, bool DisplayAlerts)
        {
            if (application != null)
                CloseApplication();
            if (!File.Exists(file_path))
            {
                return "文件不存在!";
            }
            try
            {
                application = new Excel.Application();
                application.Visible = IsVisible;
                application.DisplayAlerts = DisplayAlerts;
                workbooks = application.Workbooks;
                workbook = ((Excel.Workbook)workbooks.Open(file_path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                current_worksheet_index = 1;
                worksheet = (Excel.Worksheet)workbook.Worksheets[current_worksheet_index];
                return "";
            }
            catch (Exception ex)
            {
                CloseApplication();
                return "没有安装Excel或者没有安装.net Excel可编程性支持!\r\n详细信息：" + ex.Message;
            }
        }

        public string OpenFile(string FilePath)
        {
            file_path = FilterFilePath(FilePath);
            return OpenFile(false, false);
        }

        public string OpenFile(string FilePath, bool IsVisible, bool DisplayAlerts)
        {
            file_path = FilterFilePath(FilePath);
            return OpenFile(IsVisible, DisplayAlerts);
        }

        public string CreateFile(bool IsVisible, bool DisplayAlerts)
        {
            if (application != null)
                CloseApplication();
            try
            {
                application = new Excel.Application();
                application.Visible = IsVisible;
                application.DisplayAlerts = DisplayAlerts;
                workbooks = application.Workbooks;
                workbook = workbooks.Add(Missing.Value);
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                try
                {
                    worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4; // 设置页面大小为A4
                    worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait; // 设置垂直版面
                    worksheet.PageSetup.HeaderMargin = 0.2;                         // 设置页眉边距
                    worksheet.PageSetup.FooterMargin = 0.2;                         // 设置页脚边距
                    worksheet.PageSetup.LeftMargin = application.InchesToPoints(0.5); // 设置左边距
                    worksheet.PageSetup.RightMargin = application.InchesToPoints(0.5);// 设置右边距
                    worksheet.PageSetup.TopMargin = application.InchesToPoints(0.5);  // 设置上边距
                    worksheet.PageSetup.BottomMargin = application.InchesToPoints(0.5);// 设置下边距
                    worksheet.PageSetup.CenterHorizontally = true;                  // 设置水平居中
                }
                catch { }
                current_worksheet_index = 1;
                return "";
            }
            catch (Exception ex)
            {
                CloseApplication();
                return "没有安装Excel或者没有安装.net Excel可编程性支持!\r\n详细信息：" + ex.Message;
            }
        }

        public string CreateFile(string FilePath)
        {
            file_path = FilterFilePath(FilePath);
            return CreateFile(false, false);
        }

        public string CreateFile(string FilePath, bool IsVisible, bool DisplayAlerts)
        {
            file_path = FilterFilePath(FilePath);
            return CreateFile(IsVisible, DisplayAlerts);
        }

        public void CloseApplication()
        {
            try
            {
                workbooks = null;
                workbook = null;
                worksheet = null;
                if (application != null)
                {
                    application.Workbooks.Close();
                    application.Quit();
                    application = null;
                }
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public string SetActiveWorkSheet(int SheetIndex)
        {
            if (SheetIndex <= 0)
            {
                return "索引超出范围！";
            }
            try
            {
                while (workbook.Worksheets.Count <= SheetIndex)
                {
                    workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                worksheet = (Excel.Worksheet)workbook.Worksheets[SheetIndex];
                current_worksheet_index = SheetIndex;
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void Print()
        {
            try
            {
                worksheet.PrintOut(1, 1, 1, false, Missing.Value, false, false, Missing.Value);
            }
            catch { }
        }

        public void PrintPreview()
        {
            try
            {
                worksheet.PrintPreview(true);
            }
            catch { }
        }

        public Excel.Range GetRow(int row)
        {
            try
            {
                return ((Excel.Range)worksheet.Cells[row, 1]).EntireRow;
            }
            catch { }
            return null;
        }

        public Excel.Range GetRow(string cell)
        {
            try
            {
                return worksheet.get_Range(cell).EntireRow;
            }
            catch { }
            return null;
        }

        public Excel.Range GetColumn(int column)
        {
            try
            {
                return ((Excel.Range)worksheet.Cells[1, column]).EntireColumn;
            }
            catch { }
            return null;
        }

        public Excel.Range GetColumn(string cell)
        {
            try
            {
                return worksheet.get_Range(cell).EntireColumn;
            }
            catch { }
            return null;
        }

        public Excel.Range GetRange(int row, int col)
        {
            try
            {
                return ((Excel.Range)worksheet.Cells[row, col]);
            }
            catch { }
            return null;
        }

        public object GetRangeObject(int row, int col)
        {
            try
            {
                return worksheet.Cells[row, col];
            }
            catch { }
            return null;
        }

        public Excel.Range GetRange(string cell)
        {
            try
            {
                return worksheet.get_Range(cell);
            }
            catch { }
            return null;
        }

        public Excel.Range GetRange(int start_row, int start_col, int end_row, int end_col)
        {
            try
            {
                return (Excel.Range)worksheet.get_Range(GetRange(start_row, start_col), GetRange(end_row, end_col));
            }
            catch { }
            return null;
        }

        public Excel.Range GetRange(string start_cell, string end_cell)
        {
            try
            {
                return worksheet.get_Range(start_cell, end_cell);
            }
            catch { }
            return null;
        }

        public void SetRangeMerge(Excel.Range range, bool merge)
        {
            try
            {
                range.MergeCells = merge;
            }
            catch { }
        }

        public void SetRangeMerge(int start_row, int start_col, int end_row, int end_col, bool merge)
        {
            try
            {
                Excel.Range range = GetRange(start_row, start_col, end_row, end_col);
                range.MergeCells = merge;
            }
            catch { }
        }

        public void SetRangeObjMerge(object range_obj, bool merge)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeMerge(range, merge);
            }
            catch { }
        }

        public void SetRangePositionMerge(string start, string end, bool merge)
        {
            Excel.Range range = GetRange(start, end);
            range.MergeCells = merge;
        }

        public void SetRangeColumnAutofit(Excel.Range range)
        {
            try
            {
                range.EntireColumn.AutoFit();
            }
            catch { }
        }

        public void SetColumnAutofit(object range_obj)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeColumnAutofit(range);
            }
            catch { }
        }

        public void SetRangeRowAutofit(Excel.Range range)
        {
            try
            {
                range.EntireRow.AutoFit();
            }
            catch { }
        }

        public void SetRowAutofit(object range_obj)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeRowAutofit(range);
            }
            catch { }
        }

        public string GetCellValue(int row, int col)
        {
            try
            {
                return GetRange(row, col).Text.ToString();
            }
            catch { }
            return "";
        }

        public string GetCellValue(string cell)
        {
            try
            {
                return GetRange(cell).Text.ToString();
            }
            catch { }
            return "";
        }

        public DateTime GetCellValueDate(int row, int col)
        {
            try
            {
                return Convert.ToDateTime(GetRange(row, col).get_Value());
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        public DateTime GetCellValueDate(string cell)
        {
            try
            {
                return Convert.ToDateTime(GetRange(cell).get_Value());
            }
            catch { }
            return new DateTime(1900, 1, 1);
        }

        public DataTable GetAllCellsValue(int column_count, int row_count, BackgroundWorker bgw)
        {
            DataTable result = new DataTable();
            //设置datatable列的名称
            result.Columns.Add(new DataColumn("行号"));
            for (int col = 1; col <= column_count; col++)
            {
                result.Columns.Add(new DataColumn("列" + col));
            }
            int CurRow = 1;
            for (int row = 1; row <= row_count; row++)
            {
                DataRow dr = result.NewRow();
                bool isnull = true;
                for (int col = 1; col <= column_count; col++)
                {
                    dr[col] = ((Excel.Range)worksheet.Cells[row, col]).Text.ToString().Trim();
                    //读到空值null和读到空串""分别处理
                    if (isnull)
                    {
                        if (dr[col].ToString() != "")
                            isnull = false;
                    }
                }
                if (!isnull)
                {
                    dr[0] = CurRow;
                    CurRow++;
                    result.Rows.Add(dr);
                }
                if (bgw != null)
                {
                    bgw.ReportProgress(row * 100 / row_count);
                }
            }
            return (result);
        }

        /// <summary>
        /// 读取所有单元格的数据(矩形区域)，返回一个datatable.假设所有单元格靠工作表左上区域。
        /// </summary>
        public DataTable GetAllCellsValue()
        {
            int column_count = GetTotalColumnCount();
            int row_count = GetTotalRowCount();
            DataTable result = new DataTable();
            //设置datatable列的名称
            for (int col = 1; col <= column_count; col++)
            {
                result.Columns.Add(((Excel.Range)worksheet.Cells[1, col]).Text.ToString());
            }

            for (int row = 2; row <= row_count; row++)
            {
                DataRow dr = result.NewRow();
                for (int columnID = 1; columnID <= column_count; columnID++)
                {
                    dr[columnID - 1] = ((Excel.Range)worksheet.Cells[row, columnID]).Text.ToString();
                    //读到空值null和读到空串""分别处理
                }
                result.Rows.Add(dr);
            }
            return result;
        }

        public int GetTotalRowCount()
        {//当前活动工作表中有效行数(总行数)
            int row = 0;
            try
            {
                while (true)
                {
                    if (((Excel.Range)worksheet.Cells[row + 1, 1]).Text.ToString().Trim() == "" &&
                           ((Excel.Range)worksheet.Cells[row + 2, 1]).Text.ToString().Trim() == "" &&
                           ((Excel.Range)worksheet.Cells[row + 3, 1]).Text.ToString().Trim() == "")
                    {
                        if (((Excel.Range)worksheet.Cells[row + 1, 2]).Text.ToString().Trim() == "" &&
                            ((Excel.Range)worksheet.Cells[row + 2, 2]).Text.ToString().Trim() == "" &&
                            ((Excel.Range)worksheet.Cells[row + 3, 2]).Text.ToString().Trim() == "")
                            break;
                    }

                    row++;
                }
            }
            catch
            {
                return -1;
            }
            return row;
        }
        /// <summary>
        /// 当前活动工作表中有效列数(总列数)
        /// </summary>
        /// <param></param> 
        public int GetTotalColumnCount()
        {
            int col = 0;
            try
            {
                while (true)
                {
                    if (((Excel.Range)worksheet.Cells[1, col + 1]).Text.ToString().Trim() == "" &&
                           ((Excel.Range)worksheet.Cells[1, col + 2]).Text.ToString().Trim() == "" &&
                           ((Excel.Range)worksheet.Cells[1, col + 3]).Text.ToString().Trim() == "")
                        break;
                    col++;
                }
            }
            catch
            {
                return -1;
            }
            return col;
        }

        public void SetCellValue(int row, int col, string value)
        {
            try
            {
                Excel.Range range = GetRange(row, col);
                range.Value2 = value;
            }
            catch { }
        }

        public void SetCellValue(string cell, string value)
        {
            try
            {
                Excel.Range range = GetRange(cell);
                range.Value2 = value;
            }
            catch { }
        }

        public void SetRangeValue(Excel.Range range, string value)
        {
            try
            {
                range.Value2 = value;
            }
            catch { }
        }
        public void SetCellValue(object range_obj, string value)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeValue(range, value);
            }
            catch { }
        }

        public void SetRangeBorder(Excel.Range range, Excel.XlBordersIndex border_type, Excel.XlLineStyle style, Color color, Excel.XlBorderWeight weight)
        {
            try
            {
                range.Borders[border_type].LineStyle = style;
                range.Borders[border_type].Color = ColorTranslator.ToOle(color);
                range.Borders[border_type].LineStyle = weight;
            }
            catch { }
        }
        public void SetCellBorder(object range_obj, Excel.XlBordersIndex border_type, Excel.XlLineStyle style, Color color, Excel.XlBorderWeight weight)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorder(range, border_type, style, color, weight);
            }
            catch { }
        }
        public void SetRangeBorderStyle(Excel.Range range, Excel.XlBordersIndex border_type, bool border)
        {
            try
            {
                range.Borders[border_type].LineStyle = border ? Excel.XlLineStyle.xlContinuous : Excel.XlLineStyle.xlLineStyleNone;
            }
            catch { }
        }
        public void SetCellBorderStyle(object range_obj, Excel.XlBordersIndex border_type, bool border)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderStyle(range, border_type, border);
            }
            catch { }
        }

        public void SetRangeBorderStyle(Excel.Range range, Excel.XlBordersIndex border_type, Excel.XlLineStyle style)
        {
            try
            {
                range.Borders[border_type].LineStyle = style;
            }
            catch { }
        }
        public void SetCellBorderStyle(object range_obj, Excel.XlBordersIndex border_type, Excel.XlLineStyle style)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderStyle(range, border_type, style);
            }
            catch { }
        }

        public void SetRangeBorder(Excel.Range range, bool border)
        {
            try
            {
                Excel.XlLineStyle borderstyle = Excel.XlLineStyle.xlLineStyleNone;
                if (border)
                    borderstyle = Excel.XlLineStyle.xlContinuous;
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = borderstyle;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = borderstyle;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = borderstyle;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = borderstyle;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = borderstyle;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = borderstyle;
            }
            catch { }
        }
        public void SetCellBorder(object range_obj, bool border)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorder(range, border);
            }
            catch { }
        }

        public void SetRangeBorderStyle(Excel.Range range, Excel.XlLineStyle all)
        {
            try
            {
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = all;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = all;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = all;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = all;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = all;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = all;
            }
            catch { }
        }
        public void SetCellBorderStyle(object range_obj, Excel.XlLineStyle all)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderStyle(range, all);
            }
            catch { }
        }

        public void SetRangeBorderStyle(Excel.Range range, bool border_top, bool border_right, bool border_bottom, bool border_left, bool border_inside_horizontal, bool border_inside_vertical)
        {
            try
            {
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = border_left ? Excel.XlLineStyle.xlContinuous : Excel.XlLineStyle.xlLineStyleNone;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = border_top ? Excel.XlLineStyle.xlContinuous : Excel.XlLineStyle.xlLineStyleNone;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = border_right ? Excel.XlLineStyle.xlContinuous : Excel.XlLineStyle.xlLineStyleNone;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = border_bottom ? Excel.XlLineStyle.xlContinuous : Excel.XlLineStyle.xlLineStyleNone;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = border_inside_vertical ? Excel.XlLineStyle.xlContinuous : Excel.XlLineStyle.xlLineStyleNone;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = border_inside_horizontal ? Excel.XlLineStyle.xlContinuous : Excel.XlLineStyle.xlLineStyleNone;
            }
            catch { }
        }
        public void SetCellBorderStyle(object range_obj, bool border_top, bool border_right, bool border_bottom, bool border_left, bool border_inside_horizontal, bool border_inside_vertical)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderStyle(range, border_top, border_right, border_bottom, border_left, border_inside_horizontal, border_inside_vertical);
            }
            catch { }
        }

        public void SetRangeBorderStyle(Excel.Range range, Excel.XlLineStyle top, Excel.XlLineStyle right, Excel.XlLineStyle bottom, Excel.XlLineStyle left, Excel.XlLineStyle inside_horizontal, Excel.XlLineStyle inside_vertical)
        {
            try
            {
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = left;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = top;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = right;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = bottom;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = inside_vertical;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = inside_horizontal;
            }
            catch { }
        }
        public void SetCellBorderStyle(object range_obj, Excel.XlLineStyle top, Excel.XlLineStyle right, Excel.XlLineStyle bottom, Excel.XlLineStyle left, Excel.XlLineStyle inside_horizontal, Excel.XlLineStyle inside_vertical)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderStyle(range, top, right, bottom, left, inside_horizontal, inside_vertical);
            }
            catch { }
        }

        public void SetRangeBorderColor(Excel.Range range, Excel.XlBordersIndex border_type, Color color)
        {
            try
            {
                range.Borders[border_type].Color = ColorTranslator.ToOle(color);
            }
            catch { }
        }
        public void SetCellBorderColor(object range_obj, Excel.XlBordersIndex border_type, Color color)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderColor(range, border_type, color);
            }
            catch { }
        }

        public void SetRangeBorderColor(Excel.Range range, Color color_all)
        {
            try
            {
                int color_index = ColorTranslator.ToOle(color_all);
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = color_index;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = color_index;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = color_index;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = color_index;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].Color = color_index;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Color = color_index;
            }
            catch { }
        }
        public void SetCellBorderColor(object range_obj, Color color_all)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderColor(range, color_all);
            }
            catch { }
        }

        public void SetRangeBorderColor(Excel.Range range, Color color_top, Color color_right, Color color_bottom, Color color_left, Color color_inside_horizontal, Color color_inside_vertical)
        {
            try
            {
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = ColorTranslator.ToOle(color_left);
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = ColorTranslator.ToOle(color_top);
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = ColorTranslator.ToOle(color_right);
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = ColorTranslator.ToOle(color_bottom);
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].Color = ColorTranslator.ToOle(color_inside_vertical);
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Color = ColorTranslator.ToOle(color_inside_horizontal);
            }
            catch { }
        }
        public void SetCellBorderColor(object range_obj, Color color_top, Color color_right, Color color_bottom, Color color_left, Color color_inside_horizontal, Color color_inside_vertical)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderColor(range, color_top, color_right, color_bottom, color_left, color_inside_horizontal, color_inside_vertical);
            }
            catch { }
        }

        public void SetRangeBorderWeight(Excel.Range range, Excel.XlBordersIndex border_type, Excel.XlBorderWeight weight)
        {
            try
            {
                range.Borders[border_type].Weight = weight;
            }
            catch { }
        }
        public void SetCellBorderWeight(object range_obj, Excel.XlBordersIndex border_type, Excel.XlBorderWeight weight)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderWeight(range, border_type, weight);
            }
            catch { }
        }

        public void SetRangeBorderWeight(Excel.Range range, Excel.XlBorderWeight weight_all)
        {
            try
            {
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = weight_all;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = weight_all;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = weight_all;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = weight_all;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = weight_all;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = weight_all;
            }
            catch { }
        }
        public void SetCellBorderWeight(object range_obj, Excel.XlBorderWeight weight_all)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderWeight(range, weight_all);
            }
            catch { }
        }

        public void SetRangeBorderWeight(Excel.Range range, Excel.XlBorderWeight weight_top, Excel.XlBorderWeight weight_right, Excel.XlBorderWeight weight_bottom, Excel.XlBorderWeight weight_left, Excel.XlBorderWeight weight_inside_horizontal, Excel.XlBorderWeight weight_inside_vertical)
        {
            try
            {
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = weight_left;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = weight_top;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = weight_right;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = weight_bottom;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = weight_inside_vertical;
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = weight_inside_horizontal;
            }
            catch { }
        }
        public void SetCellBorderWeight(object range_obj, Excel.XlBorderWeight weight_top, Excel.XlBorderWeight weight_right, Excel.XlBorderWeight weight_bottom, Excel.XlBorderWeight weight_left, Excel.XlBorderWeight weight_inside_horizontal, Excel.XlBorderWeight weight_inside_vertical)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBorderWeight(range, weight_top, weight_right, weight_bottom, weight_left, weight_inside_horizontal, weight_inside_vertical);
            }
            catch { }
        }

        public void SetRangeColumnWidth(Excel.Range range, float size)
        {
            try
            {
                range.ColumnWidth = size;
            }
            catch { }
        }
        public void SetColumnWidth(object range_obj, float size)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeColumnWidth(range, size);
            }
            catch { }
        }

        public void SetRangeRowHeight(Excel.Range range, float size)
        {
            try
            {
                range.RowHeight = size;
            }
            catch { }

        }
        public void SetRowHeight(object range_obj, float size)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeRowHeight(range, size);
            }
            catch { }
        }

        public void SetRangeFont(Excel.Range range, string font_family, int font_size, bool font_bold)
        {
            try
            {
                range.Font.Name = font_family;
                range.Font.Size = font_size;
                range.Font.Bold = font_bold;
            }
            catch { }
        }
        public void SetCellFont(object range_obj, string font_family, int font_size, bool font_bold)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeFont(range, font_family, font_size, font_bold);
            }
            catch { }
        }

        public void SetRangeBackColor(Excel.Range range, Color color)
        {
            try
            {
                range.Interior.Color = ColorTranslator.ToOle(color);
            }
            catch { }
        }
        public void SetCellBackColor(object range_obj, Color color)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeBackColor(range, color);
            }
            catch { }
        }

        public void SetRangeForeColor(Excel.Range range, Color color)
        {
            try
            {
                range.Font.Color = ColorTranslator.ToOle(color);
            }
            catch { }
        }
        public void SetCellForeColor(object range_obj, Color color)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeForeColor(range, color);
            }
            catch { }
        }

        public void SetRangeHorizontalAlignment(Excel.Range range, Excel.XlHAlign alignment)
        {
            try
            {
                range.HorizontalAlignment = alignment;
            }
            catch { }
        }
        public void SetCellHorizontalAlignment(object range_obj, Excel.XlHAlign alignment)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeHorizontalAlignment(range, alignment);
            }
            catch { }
        }

        public void SetRangeVerticalAlignment(Excel.Range range, Excel.XlHAlign alignment)
        {
            try
            {
                range.VerticalAlignment = alignment;
            }
            catch { }
        }
        public void SetCellVerticalAlignment(object range_obj, Excel.XlHAlign alignment)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeVerticalAlignment(range, alignment);
            }
            catch { }
        }

        public void SetRangeNumberFormat(Excel.Range range, string numberFormat)
        {
            try
            {
                range.NumberFormatLocal = numberFormat;
            }
            catch { }
        }
        public void SetCellNumberFormat(object range_obj, string numberFormat)
        {
            try
            {
                Excel.Range range = (Excel.Range)range_obj;
                SetRangeNumberFormat(range, numberFormat);
            }
            catch { }
        }

        public void CopyCells(string SourceStart, string SourceEnd, string DesStart, string DesEnd)
        {
            try
            {
                Excel.Range range = worksheet.get_Range(SourceStart, SourceEnd);
                Excel.Range range1 = worksheet.get_Range(DesStart, DesEnd);
                range.Copy(range1);
            }
            catch { }
        }

        public void CopyWorksheet(int source_index, int des_index)
        {
            try
            {
                Excel.Worksheet sheetSource = (Excel.Worksheet)workbook.Worksheets[source_index];
                sheetSource.Select(Missing.Value);
                Excel.Worksheet sheetDest = (Excel.Worksheet)workbook.Worksheets[des_index];
                sheetSource.Copy(Missing.Value, sheetDest);
            }
            catch { }
        }

        public string InsertRow(int row, int row_count)//插入空行
        {
            if (row <= 0)
            {
                return "行索引超出范围！";
            }
            if (row_count <= 0)
            {
                return "插入行数无效！";
            }
            try
            {
                Excel.Range range = (Excel.Range)worksheet.Rows[row, Missing.Value];
                for (int i = 0; i < row_count; i++)
                {
                    range.Insert(Excel.XlDirection.xlDown, Missing.Value);
                }
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public Excel.Range FindFirstRange(Excel.Range xlRange, string FindText)//查找//没有测试
        {
            //查找第一个满足的区域
            //Search for the first match
            Excel.Range firstFind = null;
            firstFind = xlRange.Find(FindText, Missing.Value, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, Missing.Value, Missing.Value);
            return firstFind;  //如果没找到，返回空
        }

        public void SetWorksheetName(int sheetIndex, string worksheetName)
        {
            // Missing.Value
            Excel._Worksheet sheet = (Excel._Worksheet)(workbook.Worksheets[(object)sheetIndex]);
            sheet.Name = worksheetName;
        }

        /// <summary>
        /// 获取字母型列值,如1=A,26=Z,27=AA
        /// </summary>
        /// <param name="columnIndex">数字型列值</param>
        /// <returns>字母型列值</returns>
        private string ConvertColumnIndexToChar(int columnIndex)
        {
            if (columnIndex < 1)
                return "A";
            string res = "";
            int index = columnIndex;
            while (true)
            {
                int charidx = index % 26;
                if (charidx == 0)
                    charidx = 26;
                res = Convert.ToChar(64 + charidx).ToString() + res;
                if (index <= 26)
                    break;
                index = (index - charidx) / 26;
            }
            if (res == "")
                res = "A";
            return res;
        }

        public string SaveExcel()
        {
            if (file_path == "")
            {
                return "未指定要保存的文件名";
            }
            try
            {
                worksheet.SaveAs(file_path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value);
                return "";
            }
            catch (Exception ex)
            {
                CloseApplication();
                return ex.Message;
            }
        }

        public string SaveExcel(string FilePath)
        {
            if (FilePath == "")
            {
                return "未指定要保存的文件名";
            }
            try
            {
                worksheet.SaveAs(FilterFilePath(FilePath), Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value);
                return "";
            }
            catch (Exception ex)
            {
                CloseApplication();
                return ex.Message;
            }
        }

        /// <summary>
        /// 保存Excel文件，格式xml.
        /// </summary>
        public string SaveExcelAsXML()
        {
            if (file_path == "")
            {
                return "未指定要保存的文件名";
            }
            try
            {
                worksheet.SaveAs(file_path, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value);
                return "";
            }
            catch (Exception ex)
            {
                CloseApplication();
                return ex.Message;
            }
        }

        public string FilterFilePath(string path)
        {
            string file_path = path.Replace("<", "");
            file_path = file_path.Replace(">", "");
            file_path = file_path.Replace("?", "");
            file_path = file_path.Replace("[", "");
            file_path = file_path.Replace("]", "");
            file_path = file_path.Replace("|", "");
            file_path = file_path.Replace("*", "");
            return file_path;
        }
    }
}