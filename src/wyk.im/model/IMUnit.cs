using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace wyk.im
{
    public class IMUnit
    {
        public virtual int tokenExpireDays()
        {
            return 0;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="name">用户姓名</param>
        /// <param name="avatar_url">头像URL</param>
        /// <returns></returns>
        public virtual string token(string user_id, string name, string avatar_url)
        {
            return "";
        }

        /// <summary>
        /// 刷新用户信息
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="name">用户姓名</param>
        /// <param name="avatar_url">头像URL</param>
        /// <returns></returns>
        public virtual bool refreshUser(string user_id, string name, string avatar_url)
        {
            return false;
        }

        /// <summary>
        /// 获取用户的在线状态
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <returns></returns>
        public virtual IMOnlineStatus userOnlineStatus(string user_id)
        {
            return IMOnlineStatus.Unknown;
        }

        /// <summary>
        /// 通过服务端返回路由消息内容(String)转换为通用消息信息IMMessageInfo
        /// </summary>
        /// <param name="content">消息内容(string)</param>
        /// <returns></returns>
        public virtual IMMessageInfo messageInfoFromServerContent(string content)
        {
            return null;
        }

        /// <summary>
        /// 通过服务端返回路由消息内容(JObject)转换为通用消息信息IMMessageInfo
        /// </summary>
        /// <param name="obj">消息内容(string)</param>
        /// <returns></returns>
        public virtual IMMessageInfo messageInfoFromServerContent(JObject obj)
        {
            return null;
        }

        /// <summary>
        /// 验证IM服务器返回信息的签名是否有效
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual bool checkIMServerSignature(HttpRequestMessage request)
        {
            return true;
        }
    }
}
