using Microsoft.Office.Core;
using System.IO;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace wyk.office
{
    public class PowerPointUtil
    {
        ///<summary>
        /// 将PPT文件转换为HTML文件
        ///</summary>
        ///<param name="source_path">PPT文件路径（绝对）</param>
        ///<param name="target_path">生成的Html文件路径（绝对），路径的目录结构必须存在，否则保存失败</param>
        ///<returns>是否执行成功</returns>
        public static bool PowerPointToHtml(string source_path, string target_path)
        {
            PowerPoint.Application ppt = new PowerPoint.Application();
            MsoTriState m1 = new MsoTriState();
            MsoTriState m2 = new MsoTriState();
            MsoTriState m3 = new MsoTriState();
            PowerPoint.Presentation pp = null;
            try
            {
                if (File.Exists(target_path))
                    File.Delete(target_path);
                pp = ppt.Presentations.Open(source_path, m1, m2, m3);
                pp.SaveAs(target_path, PowerPoint.PpSaveAsFileType.ppSaveAsHTML, MsoTriState.msoTriStateMixed);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                try
                {
                    pp.Close();
                }
                catch { }
                //Thread.Sleep(3000);
            }
        }
    }
}