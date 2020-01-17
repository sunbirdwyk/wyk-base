namespace wyk.api
{
    /// <summary>
    /// 用于异步访问接口时参数传递
    /// </summary>
    public class ApiState
    {
        public object self = null;
        public ApiSuccess api_success = null;
        public ApiFailed api_failed = null;

        public ApiState() { }

        public ApiState(object self, ApiSuccess api_success, ApiFailed api_failed)
        {
            this.self = self;
            this.api_success = api_success;
            this.api_failed = api_failed;
        }

        public void success(object data)
        {
            api_success?.Invoke(data);
        }

        public void fail(string message, int code)
        {
            api_failed?.Invoke(message, code);
        }

        public void fail(string message)
        {
            fail(message, 1);
        }
    }
}