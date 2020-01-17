using System;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// 线程计数器
    /// </summary>
    public class ThreadLocker
    {
        private int counter = 0;
        private StringBuilder sb = new StringBuilder();
        private readonly object counter_locker = new object();
        private readonly object msg_locker = new object();

        /// <summary>
        /// 设置线程总数
        /// </summary>
        /// <param name="counter">待开启的线程数量</param>
        public void set(int counter)
        {
            lock (counter_locker)
            {
                this.counter = counter;
            }
        }

        /// <summary>
        /// 获取线程剩余数量
        /// </summary>
        public int count()
        {
            lock (counter_locker)
            {
                return counter;
            }
        }

        /// <summary>
        /// 线程数减1
        /// </summary>
        public void dec()
        {
            lock (counter_locker)
            {
                counter--;
            }
        }

        /// <summary>
        /// 线程数一个减少多个
        /// </summary>
        public void dec(int num)
        {
            lock (counter_locker)
            {
                counter = counter > num ? counter - num : 0;
            }
        }

        /// <summary>
        /// 判断是否所有线程都执行完
        /// </summary>
        public bool finished()
        {
            lock (counter_locker)
            {
                return counter == 0;
            }
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        public void append(string msg)
        {
            lock (msg_locker)
            {
                sb.Append(msg);
                sb.Append(Environment.NewLine);
            }
        }

        /// <summary>
        /// 获取错误信息
        /// </summary>
        public string errMsg()
        {
            lock (msg_locker)
            {
                return sb.ToString();
            }
        }

        /// <summary>
        /// 清除错误信息
        /// </summary>
        public void clearMsg()
        {
            lock (msg_locker)
            {
                sb.Clear();
            }
        }
    }
}
