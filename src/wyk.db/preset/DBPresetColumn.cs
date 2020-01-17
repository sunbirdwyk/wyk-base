namespace wyk.db.preset
{
    public class DBPresetColumn
    {
        #region sys_configuration
        public DBColumn sys_configuration_1 = new DBColumn("param_name", DBDataType.Varchar, 50, 0, "", false, true, false, "配置参数名", false);
        public DBColumn sys_configuration_2 = new DBColumn("param_value", DBDataType.Text, 0, 0, "", true, false, false, "配置值", false);
        #endregion

        #region seq_all
        public DBColumn seq_all_1 = new DBColumn("seq_type", DBDataType.Varchar, 50, 0, "", false, true, false, "sequence类型", false);
        public DBColumn seq_all_2 = new DBColumn("record_index", DBDataType.Long, 0, 0, "", true, false, false, "sequence值", false);
        #endregion

        #region seq_daily
        public DBColumn seq_daily_1 = new DBColumn("seq_type", DBDataType.Varchar, 50, 0, "", false, true, false, "sequence类型", false);
        public DBColumn seq_daily_2 = new DBColumn("record_date", DBDataType.DateTime, 0, 0, "", false, true, false, "记录日期", false);
        public DBColumn seq_daily_3 = new DBColumn("record_index", DBDataType.Long, 0, 0, "", true, false, false, "sequence值", false);
        #endregion

        #region dic_common_dictionary
        public DBColumn dic_common_dictionary_1 = new DBColumn("id", DBDataType.Integer, 0, 0, "", false, true, false, "字典项ID", false);
        public DBColumn dic_common_dictionary_2 = new DBColumn("dic_type", DBDataType.Varchar, 50, 0, "", true, false, false, "字典类", false);
        public DBColumn dic_common_dictionary_3 = new DBColumn("content", DBDataType.Varchar, 255, 0, "", true, false, false, "字典值", false);
        public DBColumn dic_common_dictionary_4 = new DBColumn("shortcut", DBDataType.Varchar, 50, 0, "", true, false, false, "字典值简写(前50位)", false);
        public DBColumn dic_common_dictionary_5 = new DBColumn("idx", DBDataType.Integer, 0, 0, "", true, false, false, "顺序号", false);
        #endregion

        #region 
        #endregion

    }
}
