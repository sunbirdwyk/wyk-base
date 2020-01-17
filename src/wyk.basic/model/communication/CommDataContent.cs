using System;
using System.Collections.Generic;
using System.Text;

namespace wyk.basic
{
    /// <summary>
    /// 通信数据内容
    /// </summary>
    public class CommDataContent
    {
        /// <summary>
        /// 数据块的最大长度(包含各个外层包装之后)
        /// 此值默认为4096, 需要用其他值时, 请在***开始使用前***进行更改, 全局影响, 只需要修改一次即可
        /// </summary>
        public static int DATA_BLOCK_SIZE = 4096;
        public static uint _current_task_id = 0;

        private static CommunicationInfo _communication_info = null;
        public CommDataContent()
        {
            _task_id = nextTaskId();
        }

        public CommDataContent(string content)
        {
            _task_id = nextTaskId();
            data_content = content;
        }

        uint _task_id = 0;
        string _data_content = "";
        SortedList<uint, CommDataBlock> _data_blocks = new SortedList<uint, CommDataBlock>();

        private static CommunicationInfo communication_info
        {
            get
            {
                if (_communication_info == null)
                {
                    _communication_info = new CommunicationInfo();
                    _communication_info.load();
                }
                return _communication_info;
            }
        }

        private static uint nextTaskId()
        {
            if (_current_task_id == 0)
                _current_task_id = communication_info.task_id;
            ++_current_task_id;
            if (_current_task_id > 10000)
                _current_task_id = _current_task_id % 10000;
            if (_current_task_id == 0)
                _current_task_id = 1;
            communication_info.task_id = _current_task_id;
            communication_info.save();
            return _current_task_id;
        }

        public string data_content
        {
            get => _data_content;
            set
            {
                if (_data_content == value)
                    return;
                _data_content = value;
                resetDataBlocks();
            }
        }

        public uint task_id
        {
            get => _task_id;
            set
            {
                if (_task_id == value)
                    return;
                _task_id = value;
                if (_data_blocks != null && _data_blocks.Count > 0)
                {
                    foreach (var db in _data_blocks.Values)
                    {
                        db.setTaskId(task_id);
                    }
                }
            }
        }

        public SortedList<uint, CommDataBlock> data_blocks
        {
            get
            {
                if (_data_blocks == null)
                    _data_blocks = new SortedList<uint, CommDataBlock>();
                return _data_blocks;
            }
            set
            {
                _data_blocks = value;
                getDataContent();
            }
        }

        private void resetDataBlocks()
        {
            if (_data_content.isNull())
            {
                _data_blocks = new SortedList<uint, CommDataBlock>();
                return;
            }
            _data_blocks = new SortedList<uint, CommDataBlock>();
            var max_data = DATA_BLOCK_SIZE - 12;
            var buffer = Encoding.UTF8.GetBytes(_data_content);
            if (buffer.Length < max_data)
                _data_blocks.Add(1, CommDataBlock.createDataBlock(_task_id, 1, buffer));
            else
            {
                var start = 0;
                uint block_id = 1;
                while (start + max_data < buffer.Length)
                {
                    var data = new byte[max_data];
                    Array.Copy(buffer, start, data, 0, data.Length);
                    _data_blocks.Add(block_id, CommDataBlock.createDataBlock(_task_id, block_id, data));
                    start += max_data;
                    block_id++;
                }
                if (start < buffer.Length)
                {
                    var data = new byte[buffer.Length - start];
                    Array.Copy(buffer, start, data, 0, data.Length);
                    _data_blocks.Add(block_id, CommDataBlock.createDataBlock(_task_id, block_id, data));
                }
            }
        }

        private void getDataContent()
        {
            if (data_blocks.Count <= 0)
            {
                _data_content = "";
                return;
            }
            var max_data = DATA_BLOCK_SIZE - 12;
            var last_block_id = data_blocks.Values[data_blocks.Count - 1].getBlockId();
            if (last_block_id == 0 || data_blocks.Count != last_block_id)
            {
                _data_content = "";
                return;
            }
            try
            {
                _task_id = data_blocks.Values[0].getTaskId();
                var length = (last_block_id - 1) * max_data + data_blocks.Values[data_blocks.Count - 1].content_bytes.Length - 12;
                var buffer = new byte[length];
                var start = 0;
                foreach (var db in data_blocks.Values)
                {
                    var data_length = db.content_bytes.Length - 12;
                    Array.Copy(db.content_bytes, 10, buffer, start, data_length);
                    start += data_length;
                }
                _data_content = Encoding.UTF8.GetString(buffer);
            }
            catch { _data_content = ""; }
        }
    }
}