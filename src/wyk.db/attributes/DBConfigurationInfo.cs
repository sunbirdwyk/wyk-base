using System;

namespace wyk.db
{
    /// <summary>
    /// 用于标记简易配置表信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DBConfigurationInfo : Attribute
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string table_name = "";
        /// <summary>
        /// 参数名列
        /// </summary>
        public string name_column = "param_name";
        /// <summary>
        /// 参数值列
        /// </summary>
        public string value_column = "param_value";

        /// <summary>
        /// 域ID列, 不填则视为此Configuration只支持单域
        /// </summary>
        public string domain_column = "";

        /// <summary>
        /// 配置表信息初始化, 默认使用 param_name/param_value作为名/值
        /// </summary>
        /// <param name="TableName"></param>
        public DBConfigurationInfo(string TableName)
        {
            table_name = TableName;
        }

        /// <summary>
        /// 配置表信息初始化, 默认使用 param_name/param_value作为名/值
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="DomainColumn"></param>
        public DBConfigurationInfo(string TableName, string DomainColumn)
        {
            table_name = TableName;
            domain_column = DomainColumn;
        }

        /// <summary>
        /// 配置表信息初始化
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="NameColumn"></param>
        /// <param name="ValueColumn"></param>
        public DBConfigurationInfo(string TableName, string NameColumn, string ValueColumn)
        {
            table_name = TableName;
            name_column = NameColumn;
            value_column = ValueColumn;
        }

        /// <summary>
        /// 配置表信息初始化
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="NameColumn"></param>
        /// <param name="ValueColumn"></param>
        /// <param name="DomainColumn"></param>
        public DBConfigurationInfo(string TableName, string NameColumn, string ValueColumn, string DomainColumn)
        {
            table_name = TableName;
            name_column = NameColumn;
            value_column = ValueColumn;
            domain_column = DomainColumn;
        }
    }
}
