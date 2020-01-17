using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace wyk.office
{
    public class WordUtil
    {
        ///<summary>
        /// 将Word文件转换为HTML文件
        ///</summary>
        ///<param name="source_path">Word文件路径（绝对）</param>
        ///<param name="target_path">生成的Html文件路径（绝对），路径的目录结构必须存在，否则保存失败</param>
        ///<returns>是否执行成功</returns>
        public static bool toHtml(string source_path, string target_path)
        {
            Word.Application wordApp = new Word.Application();
            Type wordType = wordApp.GetType();
            Word.Documents docs = wordApp.Documents;
            Type docsType = docs.GetType();
            try
            {
                if (File.Exists(target_path))
                    File.Delete(target_path);
                Word.Document doc = (Word.Document)docsType.InvokeMember("Open", BindingFlags.InvokeMethod, null, docs, new Object[] { source_path, true, true });
                Type docType = doc.GetType();
                docType.InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, doc, new object[] { target_path, Word.WdSaveFormat.wdFormatFilteredHTML });
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                wordType.InvokeMember("Quit", BindingFlags.InvokeMethod, null, wordApp, null);
                try
                {
                    wordApp.Quit();
                }
                catch { }
                Thread.Sleep(3000);
            }
        }
    }
}