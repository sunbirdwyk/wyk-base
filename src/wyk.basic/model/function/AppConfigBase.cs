using System;
using System.IO;
using System.Xml;

namespace wyk.basic
{
    /// <summary>
    /// 基础的配置文件类, 在程序根目录下"config.xml"文件的对应读写类
    /// 注:
    /// </summary>
    public class AppConfigBase
    {
        /// <summary>
        /// 当前配置是否可保存
        /// 有些时候配置还没读取就会有调用保存的情况, 为了解决此问题, 设置这个判断字段
        /// </summary>
        public bool can_save = false;
        /// <summary>
        /// 配置文件路径
        /// </summary>
        /// <returns></returns>
        public string configPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + configFileName();
        }

        /// <summary>
        /// 配置文件文件名(包括扩展名)
        /// </summary>
        /// <returns></returns>
        protected virtual string configFileName()
        {
            return "config.xml";
        }

        /// <summary>
        /// 根节点名
        /// </summary>
        /// <returns></returns>
        protected virtual string rootName()
        {
            return "config";
        }

        /// <summary>
        /// 从默认的配置文件路径加载配置内容
        /// </summary>
        /// <returns></returns>
        public string load()
        {
            return load(configPath());
        }

        /// <summary>
        /// 从指定文件路径加载配置内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string load(string path)
        {
            can_save = true;
            try
            {
                if (!File.Exists(path))
                    return save();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlNode root = xDoc.SelectSingleNode(rootName());
                if (root != null)
                {
                    XmlNode xn;
                    var fields = this.GetType().GetFields();
                    foreach (var fi in fields)
                    {
                        try
                        {
                            var attr = fi.getAttribute<AppConfigPropertyAttribute>();
                            if (attr == null)
                                continue;
                            xn = root.SelectSingleNode(fi.Name);
                            this.setValue(fi, xn.InnerText.xmlDecode());
                        }
                        catch { }
                    }
                    var properties = this.GetType().GetProperties();
                    foreach (var pi in properties)
                    {
                        try
                        {
                            var attr = pi.getAttribute<AppConfigPropertyAttribute>();
                            if (attr == null)
                                continue;
                            xn = root.SelectSingleNode(pi.Name);
                            this.setValue(pi, xn.InnerText.xmlDecode());
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex) { return ex.Message; }
            return "";
        }

        /// <summary>
        /// 将配置内容存储到默认配置文件路径
        /// </summary>
        /// <returns></returns>
        public string save()
        {
            return save(configPath());
        }

        /// <summary>
        /// 将配置内容存储到指定文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string save(string path)
        {
            if (!can_save)
                return "当前还不允许保存";
            try
            {
                IOUtil.deleteFileIfExists(path);
                IOUtil.createDirectoryIfNotExist(IOUtil.directoryPath(path));
                var tw = File.CreateText(path);
                tw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                tw.WriteLine("<" + rootName() + ">");
                var fields = this.GetType().GetFields();
                foreach (var fi in fields)
                {
                    var attr = fi.getAttribute<AppConfigPropertyAttribute>();
                    if (attr==null)
                        continue;
                    try
                    {
                        tw.WriteLine("  <" + fi.Name + ">" + fi.GetValue(this).ToString().xmlEncode() + "</" + fi.Name + ">");
                    }
                    catch { }
                }
                var properties = this.GetType().GetProperties();
                foreach (var pi in properties)
                {
                    var attr = pi.getAttribute<AppConfigPropertyAttribute>();
                    if (attr == null)
                        continue;
                    try
                    {
                        tw.WriteLine("  <" + pi.Name + ">" + pi.GetValue(this).ToString().xmlEncode() + "</" + pi.Name + ">");
                    }
                    catch { }
                }
                tw.WriteLine("</" + rootName() + ">");
                tw.Flush();
                tw.Close();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}