using System;

namespace wyk.basic
{
    /// <summary>
    /// 通信数据块, 在数据过大时, 会拆解成数据块分批发送
    /// </summary>
    public class CommDataBlock
    {
        /*
         * ------------------------------------------------------------------
         * -=发送数据包=-数据块结构
         *   起始位:      0x01 (SOH)     - 1 byte     [0]
         *   TaskID:      [4位数字]      - 4 byte    [1-4]
         *   BlockID:     [4位数字]      - 4 byte    [5-8]
         *   内容开始:    0x02 (STX)     - 1 byte     [9]
         *   包内容:      [包内容]       - ? byte     [10+]
         *   内容结束     0x03 (ETX)     - 1 byte 
         *   传输结束:    0x04 (EOT)     - 1 byte
         * 
         * 注: 包内容的最大长度为 数据块最大长度[CommDataContent.DATA_BLOCK_SIZE] - 12, 但是在本单元中, 不判断传入包的长度, 只封装后传回结果
         * 
         * ------------------------------------------------------------------
         * 
         * -=回执成功包=-数据块结构:
         *   起始位:      0x01 (SOH)    - 1 byte     [0]
         *   TaskID:      [4位数字]      - 4 byte    [1-4]
         *   BlockID:     [4位数字]      - 4 byte    [5-8]
         *   确认位:      0x06 (ACK)    - 1 byte    [9]
         *   传输结束:    0x04 (EOT)    - 1 byte     [10]
         *   
         * 注:回执包共11字节
         * -------------------------------------------------------------------
         * 
         * -=数据结束包=-数据块结构
         *   起始位:      0x01 (SOH)    - 1 byte     [0]
         *   TaskID:      [4位数字]      - 4 byte    [1-4]
         *   包结束标志:  0x07 (BEL)    - 1 byte    [5]
         *   传输结束:    0x04 (EOT)    - 1 byte     [6]
         *   
         * 注:数据结束包共7个字节, 主要以 0x07 (BEL) 为判断条件, 接收到此包后, 证明此数据内容段已全部传输完成
         * --------------------------------------------------------------------
         * 
         * -=打招呼包=-数据块结构
         *   起始位:      0x01 (SOH)    - 1 byte     [0]
         *   包结束标志:  0x05 (ENQ)    - 1 byte     [1]
         *   传输结束:    0x04 (EOT)    - 1 byte     [2]
         *   
         * 注:此包用于UDP通信时向服务器发送连接时发送, 服务器收到时返回ACK, 证明与服务器之间的状态为连通状态
         * -----------------------------------------------------------------------
         * 
         */

        public byte[] content_bytes = null;
        public static CommDataBlock createDataBlock(uint task_id, uint block_id, byte[] data)
        {
            if (data == null || data.Length <= 0)
                return null;
            var bytes = new byte[data.Length + 12];
            bytes[0] = 0x01;
            bytes[9] = 0x02;
            Array.Copy(data, 0, bytes, 10, data.Length);
            bytes[bytes.Length - 2] = 0x03;
            bytes[bytes.Length - 1] = 0x04;
            var block = new CommDataBlock()
            {
                content_bytes = bytes
            };
            block.setTaskId(task_id);
            block.setBlockId(block_id);
            return block;
        }

        public static CommDataBlock createAckBlock(uint task_id, uint block_id)
        {
            var bytes = new byte[11];
            bytes[0] = 0x01;
            bytes[9] = 0x06;
            bytes[10] = 0x04;
            var block = new CommDataBlock()
            {
                content_bytes = bytes
            };
            block.setTaskId(task_id);
            block.setBlockId(block_id);
            return block;
        }

        public static CommDataBlock createEndBlock(uint task_id)
        {
            var bytes = new byte[7];
            bytes[0] = 0x01;
            bytes[5] = 0x07;
            bytes[6] = 0x04;
            var block = new CommDataBlock()
            {
                content_bytes = bytes
            };
            block.setTaskId(task_id);
            return block;
        }

        public static CommDataBlock createHelloBlock()
        {
            var bytes = new byte[] { 0x01, 0x05, 0x04 };
            var block = new CommDataBlock()
            {
                content_bytes = bytes
            };
            return block;
        }

        public bool isAvailableAck()
        {
            //注: 只判断长度和第9位是不是0x06
            if (content_bytes == null || content_bytes.Length == 11 && content_bytes[9] == 0x06)
                return true;
            return false;
        }

        public bool isAvailableEnd()
        {
            //注: 只判断长度和第5位是不是0x07
            if (content_bytes == null || content_bytes.Length == 7 && content_bytes[5] == 0x07)
                return true;
            return false;
        }

        public bool isAvailableHello()
        {
            //注: 只判断长度和第1位是不是0x05
            if (content_bytes == null || content_bytes.Length == 3 && content_bytes[1] == 0x05)
                return true;
            return false;
        }

        public bool isAvailableData()
        {
            //注: 判断长度和内容开始/结束
            if (content_bytes.Length > 12 && content_bytes[9] == 0x02 && content_bytes[content_bytes.Length - 2] == 0x03)
                return true;
            return false;
        }

        public byte[] dataBytes()
        {
            if (content_bytes == null || content_bytes.Length <= 12)
                return null;
            var data = new byte[content_bytes.Length - 12];
            Array.Copy(content_bytes, 10, data, 0, data.Length);
            return data;
        }

        public uint getTaskId()
        {
            if (content_bytes == null || content_bytes.Length <= 5)
                return 0;
            uint task_id = 0;
            try
            {
                task_id = Convert.ToUInt32($"{Convert.ToChar(content_bytes[1])}{Convert.ToChar(content_bytes[2])}{Convert.ToChar(content_bytes[3])}{Convert.ToChar(content_bytes[4])}");
            }
            catch { }
            return task_id;
        }

        public void setTaskId(uint task_id)
        {
            if (content_bytes == null || content_bytes.Length <= 5)
                return;
            var str = task_id.ToString();
            while (str.Length < 4)
                str = "0" + str;
            if (str.Length > 4)
                str.Substring(str.Length - 4, 4);
            var task_id_arr = str.ToCharArray();
            for (int i = 0; i < 4; i++)
                content_bytes[1 + i] = (byte)task_id_arr[i];
        }

        public uint getBlockId()
        {
            if (content_bytes == null || content_bytes.Length <= 9)
                return 0;
            uint block_id = 0;
            try
            {
                block_id += Convert.ToUInt32($"{Convert.ToChar(content_bytes[5])}{Convert.ToChar(content_bytes[6])}{Convert.ToChar(content_bytes[7])}{Convert.ToChar(content_bytes[8])}");
            }
            catch { }
            return block_id;
        }

        public void setBlockId(uint block_id)
        {
            if (content_bytes == null || content_bytes.Length <= 9)
                return;
            var str = block_id.ToString();
            while (str.Length < 4)
                str = "0" + str;
            if (str.Length > 4)
                str.Substring(str.Length - 4, 4);
            var block_id_arr = str.ToCharArray();
            for (int i = 0; i < 4; i++)
                content_bytes[5 + i] = (byte)block_id_arr[i];
        }
    }
}