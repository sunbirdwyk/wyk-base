using Newtonsoft.Json;
using System;
using System.Configuration;
using wyk.basic;

namespace wyk.api
{
    /// <summary>
    /// api 返回结果, code=0表示结果为正常
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 返回错误信息, 如结果为正常, 返回此值为空字符串
        /// </summary>
        public string message = "";
        /// <summary>
        /// 返回错误代码, 如结果为正常, 返回此值为0
        /// </summary>
        public int code = 0;

        /// <summary>
        /// 返回接口结果, 如果结果为一个列表, 则结果装在"list"中
        /// </summary>
        public object data = null;

        public static bool debug = false;

        public static void load()
        {
            try
            {
                debug = Convert.ToBoolean(ConfigurationManager.AppSettings["ApiDebug"]);
            }
            catch { debug = false; }
        }

        /// <summary>
        /// 注:默认初始化时结果为错误信息
        /// </summary>
        public ApiResult()
        {
            errorCommon();
        }

        /// <summary>
        /// 使用code 和 message 初始化
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ApiResult(int code, string message)
        {
            this.code = code;
            this.message = message.Replace("\r\n", "    ").Replace("\"", "'");
            data = null;
        }

        /// <summary>
        /// 使用code, message 和 data 初始化
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ApiResult(int code, string message, object data)
        {
            this.code = code;
            this.message = message.Replace("\r\n", "    ").Replace("\"", "'");
            this.data = data;
        }

        /// <summary>
        /// 使用json字符串初始化
        /// </summary>
        /// <param name="serialized_content"></param>
        public ApiResult(string serialized_content)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<ApiResult>(serialized_content);
                message = result.message;
                code = result.code;
                data = result.data;
            }
            catch { errorDataFormat(); }
        }

        public string serialized()
        {
            return JsonConvert.SerializeObject(this);
        }


        /// <summary>
        /// 正常接口数据
        /// </summary>
        /// <param name="data"></param>
        public static ApiResult success(object data)
        {
            return new ApiResult(ApiErrorCode.None, "", data);
        }

        /// <summary>
        /// 正常接口数据(无返回值)
        /// </summary>
        public static ApiResult success()
        {
            return new ApiResult(ApiErrorCode.None, "", null);
        }

        #region 设置错误代码和相应错误信息的方法
        /// <summary>
        /// 未知错误
        /// </summary>
        /// <returns></returns>
        public static ApiResult errorCommon()
        {
            return new ApiResult(ApiErrorCode.Common, "发生未知错误");
        }
        /// <summary>
        /// 自定义错误信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResult errorCustom(string msg)
        {
            return new ApiResult(ApiErrorCode.CustomError, msg);
        }
        /// <summary>
        /// 数据格式错误
        /// </summary>
        /// <returns></returns>
        public static ApiResult errorDataFormat()
        {
            return new ApiResult(ApiErrorCode.DataFormatError, "数据格式错误");
        }

        /// <summary>
        /// 接口处理中发生错误
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResult errorProcessFailed(string msg)
        {
            string error = "处理时发生错误";
            if (!msg.isNull() && debug)
                error += ", 错误信息:" + msg;
            return new ApiResult(ApiErrorCode.ProcessFailed, error);
        }
        /// <summary>
        /// 传入参数错误
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResult errorParameter(string msg)
        {
            string error = "参数传入有误";
            if (!msg.isNull())
                error += ", " + msg;
            return new ApiResult(ApiErrorCode.ParameterError, error);
        }
        /// <summary>
        /// 记录重复, 数据库中已存在当前记录
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResult errorDuplicate(string msg)
        {
            string error = " 记录重复, 数据库中已存在当前记录";
            if (!msg.isNull() && debug)
                error += ", " + msg;
            return new ApiResult(ApiErrorCode.RecordDuplicate, error);
        }
        /// <summary>
        /// 记录重复, 数据库中已存在当前记录
        /// </summary>
        /// <returns></returns>
        public static ApiResult errorDuplicate()
        {
            string error = " 记录重复, 数据库中已存在当前记录";
            return new ApiResult(ApiErrorCode.RecordDuplicate, error);
        }
        /// <summary>
        /// 保存数据时发生错误
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ApiResult errorDataSave(string msg)
        {
            string error = "保存数据时发生错误";
            if (!msg.isNull() && debug)
                error += ", 错误信息:" + msg;
            return new ApiResult(ApiErrorCode.DataSaveError, error);
        }
        /// <summary>
        /// 未登录或登录失效
        /// </summary>
        /// <returns></returns>
        public static ApiResult errorNeedsLogin()
        {
            return new ApiResult(ApiErrorCode.NeedsLogin, "未登录或登录已失效, 请重新登录");
        }
        /// <summary>
        /// 无操作权限
        /// </summary>
        /// <returns></returns>
        public static ApiResult errorNoPrivilege()
        {
            return new ApiResult(ApiErrorCode.NoPrivilege, "您没有进行此项操作的权限");
        }

        /// <summary>
        /// 所查找的记录不存在
        /// </summary>
        /// <param name="record_type">记录类型/名称</param>
        /// <returns></returns>
        public static ApiResult errorRecordNotExist(string record_type)
        {
            return new ApiResult(ApiErrorCode.RecordNotExist, (record_type.isNull() ? "记录" : record_type) + "不存在");
        }

        /// <summary>
        /// 所查找的记录不存在
        /// </summary>
        /// <returns></returns>
        public static ApiResult errorRecordNotExist()
        {
            return new ApiResult(ApiErrorCode.RecordNotExist, "记录不存在");
        }
        #endregion
    }
}