namespace wyk.db.preset
{
    public class DBPresetTable
    {
        #region 系统
        public DBTable table_1 = new DBTable("sys_configuration", "系统配置表");
        #endregion
        #region sequence
        public DBTable table_2 = new DBTable("seq_all", "全局sequence表, 序列号值从1开始递增");
        public DBTable table_3 = new DBTable("seq_daily", "每日sequence表, 序列号值每天从1开始递增, 第二天重置");
        #endregion
        #region 字典
        public DBTable table_4 = new DBTable("dic_common_dictionary", "常规字典表, 主要用于下拉框列表等");
        #endregion
    }
}
