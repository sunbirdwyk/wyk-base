using System.ComponentModel;

namespace wyk.basic
{
    public enum UploadStatus
    {
        [Description("未处理")]
        UnProcessed,
        [Description("上传中")]
        Uploading,
        [Description("上传成功")]
        Uploaded,
        [Description("上传失败")]
        UploadFailed,
    }
}
