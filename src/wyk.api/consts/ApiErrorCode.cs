using System.ComponentModel;

namespace wyk.api
{
    public class ApiErrorCode
    {
        /// <summary>
        /// 正常返回值
        /// </summary>
        [Description("正常")]
        public const int None = 0;
        /// <summary>
        /// 通用返回代码, 无法判断错误类型时使用此代码
        /// </summary>
        [Description("通用错误")]
        public const int Common = 1;
        /// <summary>
        /// 带自定义错误信息的代码
        /// </summary>
        [Description("自定义错误")]
        public const int CustomError = 2;
        /// <summary>
        /// 处理数据时发生错误, 一般为接口处理过程中发生了错误
        /// </summary>
        [Description("处理失败")]
        public const int ProcessFailed = 3;
        /// <summary>
        /// 传入参数有误, 一般为get传入参数不符合要求时使用
        /// </summary>
        [Description("参数有误")]
        public const int ParameterError = 4;
        /// <summary>
        /// 保存结果时失败, 一般为写数据库时发生错误时使用
        /// </summary>
        [Description("数据保存失败")]
        public const int DataSaveError = 5;
        /// <summary>
        /// 传入数据结构有误, 一般为post时传入的数据有误时使用或者对ApiResult进行反序列化时发生错误
        /// </summary>
        [Description("数据结构有误")]
        public const int DataFormatError = 6;
        /// <summary>
        /// 无法获取到相应的记录, id等参数传入有误或者记录不存在
        /// </summary>
        [Description("记录不存在")]
        public const int RecordNotExist = 7;
        /// <summary>
        /// 记录主要信息重复, 数据库中已经有相关记录
        /// </summary>
        [Description("记录重复")]
        public const int RecordDuplicate = 8;
        /// <summary>
        /// 需要登录, 登录信息不存在或者已失效时使用
        /// </summary>
        [Description("需要登录")]
        public const int NeedsLogin = 9;
        /// <summary>
        /// 无操作权限, 登录账户分配权限不足时使用
        /// </summary>
        [Description("无权限")]
        public const int NoPrivilege = 10; 
    }
}
