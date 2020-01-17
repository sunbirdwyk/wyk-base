namespace wyk.idcard.unit
{
    public abstract class ReaderUnit
    {
        public string port_number = "";
        /// <summary>
        /// 读取身份证信息
        /// </summary>
        /// <param name="get_photo">是否获取头像图片</param>
        /// <param name="msg">错误信息</param>
        /// <returns>身份证信息</returns>
        public abstract IDCardInfo readIDCard(bool get_photo, out string msg);
    }
}
