namespace wyk.db.model
{
    public class DBIndexChangeResult
    {
        public object current_id;
        public object target_id;
        public int current_index;
        public int target_index;
        public string error_message = "";
    }
}
