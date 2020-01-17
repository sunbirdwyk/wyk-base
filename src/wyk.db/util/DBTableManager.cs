using System;
using System.Collections.Generic;
using System.IO;

namespace wyk.db
{
    /// <summary>
    /// 根据数据表描述生成与各个表对应的适配类
    /// </summary>
    public class DBTableManager
    {
        /// <summary>
        /// 自动生成各个数据表相关的适配类, 命名空间imc.db, 删除所有原文件
        /// </summary>
        /// <param name="tables">类描述文件</param>
        /// <param name="root_folder">输出根目录</param>
        /// <returns>错误信息</returns>
        public static string generateDBTableAdapters(List<DBTable> tables, string root_folder)
        {
            return generateDBTableAdapters(tables, root_folder, "wyk.db", true);
        }

        /// <summary>
        /// 自动生成各个数据表相关的适配类, 删除所有原文件
        /// </summary>
        /// <param name="tables">类描述文件</param>
        /// <param name="root_folder">输出根目录</param>
        /// <param name="adapter_namespace">适配类namespace(空字符串默认为imc.db)</param>
        /// <returns>错误信息</returns>
        public static string generateDBTableAdapters(List<DBTable> tables, string root_folder, string adapter_namespace)
        {
            return generateDBTableAdapters(tables, root_folder, adapter_namespace, true);
        }

        /// <summary>
        /// 自动生成各个数据表相关的适配类
        /// </summary>
        /// <param name="tables">类描述文件</param>
        /// <param name="root_folder">输出根目录</param>
        /// <param name="adapter_namespace">适配类namespace(空字符串默认为imc.db)</param>
        /// <param name="remove_all">是否在生成文件前删除所有根目录下文件</param>
        /// <returns>错误信息</returns>
        public static string generateDBTableAdapters(List<DBTable> tables, string root_folder, string adapter_namespace, bool remove_all)
        {
            if (root_folder.Trim() == "")
                return "根目录不能为空!";
            if (remove_all)
            {
                try
                {
                    Directory.Delete(root_folder, true);
                }
                catch { }
            }
            if (!Directory.Exists(root_folder))
            {
                try
                {
                    Directory.CreateDirectory(root_folder);
                }
                catch (Exception ex) { return "创建根目录失败, 错误信息:" + ex.Message; }
            }
            root_folder = root_folder.Trim('\\').Trim('/') + "\\";
            if (adapter_namespace.Trim() == "")
                adapter_namespace = "wyk.db";
            string err = "";
            foreach (DBTable table in tables)
            {
                if (table.table_name.Trim() == "")
                    continue;
                string table_name = table.getClassName();
                string path = root_folder + table_name + ".cs";
                try
                {
                    try
                    {
                        if (File.Exists(path))
                            File.Delete(path);
                    }
                    catch { }
                    TextWriter tw = File.CreateText(path);
                    tw.Write(table.getClassContent(adapter_namespace));
                    tw.Flush();
                    tw.Close();
                }
                catch (Exception ex) { err += table_name + "导出失败!错误信息:" + ex.Message + "\r\n"; }
            }
            return err;
        }
    }
}
