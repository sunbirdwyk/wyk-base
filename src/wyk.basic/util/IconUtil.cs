using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace wyk.basic
{
    /// <summary>
    /// ICO文件操作单元
    /// </summary>
    public class IconUtil
    {
        /*
                  if (openFileDialog1.ShowDialog() == DialogResult.OK)
                  {
                      IconDir T = new IconDir(openFileDialog1.FileName);
                      T.GetImage(0); //获取一个ICO图形
                      int Temp =T.ImageCount; //ICO数量
                      T.DelImage(0);   //删除
                      T.SaveData(@"C:/1.ico"); //保存成文件 
                  }
                  //添加一个ICO AddImage参数Rectangle 宽高不能超过255
                  IconDir MyIcon = new IconDir(); 
                  Image TempImage =Image.FromFile(@"c:/bfx/T5.BMP");          
                  MyIcon.AddImage(TempImage,new Rectangle(0,0,32,32));
                  MyIcon.SaveData(@"C:/1.ico");

               */
        private ushort _IdReserved = 0;
        private ushort _IdType = 1;
        private ushort _IdCount = 1;
        private IList<IconDirentry> _Identries = new List<IconDirentry>();
        public IconUtil()
        {
        }
        public IconUtil(string IconFile)
        {
            System.IO.FileStream _FileStream = new System.IO.FileStream(IconFile, System.IO.FileMode.Open);
            byte[] IconData = new byte[_FileStream.Length];
            _FileStream.Read(IconData, 0, IconData.Length);
            _FileStream.Close();
            LoadData(IconData);
        }
        /// <summary>
        /// 读取ICO
        /// </summary>
        /// <param name="IconData"></param>
        private void LoadData(byte[] IconData)
        {
            _IdReserved = BitConverter.ToUInt16(IconData, 0);
            _IdType = BitConverter.ToUInt16(IconData, 2);
            _IdCount = BitConverter.ToUInt16(IconData, 4);
            if (_IdType != 1 || _IdReserved != 0) return;
            int ReadIndex = 6;
            for (ushort i = 0; i != _IdCount; i++)
            {
                _Identries.Add(new IconDirentry(IconData, ref ReadIndex));
            }

        }
        /// <summary>
        /// 保存ICO
        /// </summary>
        /// <param name="FileName"></param>
        public void SaveData(string FileName)
        {
            if (ImageCount == 0) return;
            System.IO.FileStream _FileStream = new System.IO.FileStream(FileName, System.IO.FileMode.Create);
            byte[] Temp = BitConverter.GetBytes(_IdReserved);
            _FileStream.Write(Temp, 0, Temp.Length);
            Temp = BitConverter.GetBytes(_IdType);
            _FileStream.Write(Temp, 0, Temp.Length);
            Temp = BitConverter.GetBytes((ushort)ImageCount);
            _FileStream.Write(Temp, 0, Temp.Length);
            for (int i = 0; i != ImageCount; i++)
            {
                _FileStream.WriteByte(_Identries[i].Width);
                _FileStream.WriteByte(_Identries[i].Height);
                _FileStream.WriteByte(_Identries[i].ColorCount);
                _FileStream.WriteByte(_Identries[i].Breserved);
                Temp = BitConverter.GetBytes(_Identries[i].Planes);
                _FileStream.Write(Temp, 0, Temp.Length);
                Temp = BitConverter.GetBytes(_Identries[i].Bitcount);
                _FileStream.Write(Temp, 0, Temp.Length);
                Temp = BitConverter.GetBytes(_Identries[i].ImageSize);
                _FileStream.Write(Temp, 0, Temp.Length);
                Temp = BitConverter.GetBytes(_Identries[i].ImageRVA);
                _FileStream.Write(Temp, 0, Temp.Length);
            }
            for (int i = 0; i != ImageCount; i++)
            {
                _FileStream.Write(_Identries[i].ImageData, 0, _Identries[i].ImageData.Length);
            }
            _FileStream.Close();
        }
        /// <summary>
        /// 根据索引返回图形
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Bitmap GetImage(int Index)
        {
            int ReadIndex = 0;
            BitmapInfo MyBitmap = new BitmapInfo(_Identries[Index].ImageData, ref ReadIndex);
            return MyBitmap.IconBmp;
        }
        public void AddImage(Image SetBitmap, Rectangle SetRectangle)
        {
            if (SetRectangle.Width > 255 || SetRectangle.Height > 255) return;


            Bitmap IconBitmap = new Bitmap(SetRectangle.Width, SetRectangle.Height);
            Graphics g = Graphics.FromImage(IconBitmap);
            g.DrawImage(SetBitmap, new Rectangle(0, 0, IconBitmap.Width, IconBitmap.Height), SetRectangle, GraphicsUnit.Pixel);
            g.Dispose();
            System.IO.MemoryStream BmpMemory = new System.IO.MemoryStream();
            IconBitmap.Save(BmpMemory, System.Drawing.Imaging.ImageFormat.Bmp);

            IconDirentry NewIconDirentry = new IconDirentry();
            BmpMemory.Position = 14;        //只使用13位后的数字 40开头 
            NewIconDirentry.ImageData = new byte[BmpMemory.Length - 14 + 128];
            BmpMemory.Read(NewIconDirentry.ImageData, 0, NewIconDirentry.ImageData.Length);
            NewIconDirentry.Width = (byte)SetRectangle.Width;
            NewIconDirentry.Height = (byte)SetRectangle.Height;
            //BMP图形和ICO的高不一样  ICO的高是BMP的2倍
            byte[] Height = BitConverter.GetBytes((uint)NewIconDirentry.Height * 2);
            NewIconDirentry.ImageData[8] = Height[0];
            NewIconDirentry.ImageData[9] = Height[1];
            NewIconDirentry.ImageData[10] = Height[2];
            NewIconDirentry.ImageData[11] = Height[3];


            NewIconDirentry.ImageSize = (uint)NewIconDirentry.ImageData.Length;
            _Identries.Add(NewIconDirentry);
            uint RvaIndex = 6 + (uint)(_Identries.Count * 16);
            for (int i = 0; i != _Identries.Count; i++)
            {
                _Identries[i].ImageRVA = RvaIndex;
                RvaIndex += _Identries[i].ImageSize;
            }
        }
        public void DelImage(int Index)
        {

            _Identries.RemoveAt(Index);
            uint RvaIndex = 6 + (uint)(_Identries.Count * 16);
            for (int i = 0; i != _Identries.Count; i++)
            {
                _Identries[i].ImageRVA = RvaIndex;
                RvaIndex += _Identries[i].ImageSize;
            }
        }
        /// <summary>
        /// 返回图形数量
        /// </summary>
        public int ImageCount { get { return _Identries.Count; } }

        private class IconDirentry
        {
            public IconDirentry()
            {
            }
            public IconDirentry(byte[] IconDate, ref int ReadIndex)
            {
                bWidth = IconDate[ReadIndex];
                ReadIndex++;
                bHeight = IconDate[ReadIndex];
                ReadIndex++;
                bColorCount = IconDate[ReadIndex];
                ReadIndex++;
                breserved = IconDate[ReadIndex];
                ReadIndex++;
                wplanes = BitConverter.ToUInt16(IconDate, ReadIndex);
                ReadIndex += 2;
                wbitcount = BitConverter.ToUInt16(IconDate, ReadIndex);
                ReadIndex += 2;
                dwbytesinres = BitConverter.ToUInt32(IconDate, ReadIndex);
                ReadIndex += 4;
                dwimageoffset = BitConverter.ToUInt32(IconDate, ReadIndex);
                ReadIndex += 4;
                System.IO.MemoryStream MemoryData = new System.IO.MemoryStream(IconDate, (int)dwimageoffset, (int)dwbytesinres);
                _ImageData = new byte[dwbytesinres];
                MemoryData.Read(_ImageData, 0, _ImageData.Length);
            }
            private byte bWidth = 16;
            private byte bHeight = 16;
            private byte bColorCount = 0;
            private byte breserved = 0;        //4 
            private ushort wplanes = 1;
            private ushort wbitcount = 32;      //8
            private uint dwbytesinres = 0;
            private uint dwimageoffset = 0;         //16
            private byte[] _ImageData;

            /// <summary>
            /// 图像宽度，以象素为单位。一个字节
            /// </summary>
            public byte Width { get => bWidth; set => bWidth = value; }
            /// <summary>
            /// 图像高度，以象素为单位。一个字节  
            /// </summary>
            public byte Height { get => bHeight; set => bHeight = value; }
            /// <summary>
            /// 图像中的颜色数（如果是>=8bpp的位图则为0）
            /// </summary>
            public byte ColorCount { get => bColorCount; set => bColorCount = value; }
            /// <summary>
            /// 保留字必须是0
            /// </summary>
            public byte Breserved { get => breserved; set => breserved = value; }
            /// <summary>
            /// 为目标设备说明位面数，其值将总是被设为1
            /// </summary>
            public ushort Planes { get => wplanes; set => wplanes = value; }
            /// <summary>
            /// 每象素所占位数。
            /// </summary>
            public ushort Bitcount { get => wbitcount; set => wbitcount = value; }
            /// <summary>
            /// 字节大小。
            /// </summary>
            public uint ImageSize { get => dwbytesinres; set => dwbytesinres = value; }
            /// <summary>
            /// 起点偏移位置。
            /// </summary>
            public uint ImageRVA { get => dwimageoffset; set => dwimageoffset = value; }
            /// <summary>
            /// 图形数据
            /// </summary>
            public byte[] ImageData { get => _ImageData; set => _ImageData = value; }

        }

        private class BitmapInfo
        {
            private uint biSize = 40;
            private uint biWidth;
            private uint biHeight;
            private ushort biPlanes = 1;
            private ushort biBitCount;
            private uint biCompression = 0;
            private uint biSizeImage;
            private uint biXPelsPerMeter;
            private uint biYPelsPerMeter;
            private uint biClrUsed;
            private uint biClrImportant;
            public IList<Color> ColorTable = new List<Color>();

            /// <summary>
            /// 占4位，位图信息头(Bitmap Info Header)的长度,一般为$28  
            /// </summary>
            public uint InfoSize { get => biSize; set => biSize = value; }
            /// <summary>
            /// 占4位，位图的宽度，以象素为单位
            /// </summary>
            public uint Width { get => biWidth; set => biWidth = value; }
            /// <summary>
            /// 占4位，位图的高度，以象素为单位  
            /// </summary>
            public uint Height { get => biHeight; set => biHeight = value; }
            /// <summary>
            /// 占2位，位图的位面数（注：该值将总是1）  
            /// </summary>
            public ushort Planes { get => biPlanes; set => biPlanes = value; }
            /// <summary>
            /// 占2位，每个象素的位数，设为32(32Bit位图)  
            /// </summary>
            public ushort BitCount { get => biBitCount; set => biBitCount = value; }
            /// <summary>
            /// 占4位，压缩说明，设为0(不压缩)   
            /// </summary>
            public uint Compression { get => biCompression; set => biCompression = value; }
            /// <summary>
            /// 占4位，用字节数表示的位图数据的大小。该数必须是4的倍数  
            /// </summary>
            public uint SizeImage { get => biSizeImage; set => biSizeImage = value; }
            /// <summary>
            ///  占4位，用象素/米表示的水平分辨率 
            /// </summary>
            public uint XPelsPerMeter { get => biXPelsPerMeter; set => biXPelsPerMeter = value; }
            /// <summary>
            /// 占4位，用象素/米表示的垂直分辨率  
            /// </summary>
            public uint YPelsPerMeter { get => biYPelsPerMeter; set => biYPelsPerMeter = value; }
            /// <summary>
            /// 占4位，位图使用的颜色数  
            /// </summary>
            public uint ClrUsed { get => biClrUsed; set => biClrUsed = value; }
            /// <summary>
            /// 占4位，指定重要的颜色数(到此处刚好40个字节，$28)  
            /// </summary>
            public uint ClrImportant { get => biClrImportant; set => biClrImportant = value; }
            private Bitmap _IconBitMap;
            /// <summary>
            /// 图形
            /// </summary>
            public Bitmap IconBmp { get => _IconBitMap; set => _IconBitMap = value; }
            public BitmapInfo(byte[] ImageData, ref int ReadIndex)
            {
                #region 基本数据
                biSize = BitConverter.ToUInt32(ImageData, ReadIndex);
                if (biSize != 40) return;
                ReadIndex += 4;
                biWidth = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                biHeight = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                biPlanes = BitConverter.ToUInt16(ImageData, ReadIndex);
                ReadIndex += 2;
                biBitCount = BitConverter.ToUInt16(ImageData, ReadIndex);
                ReadIndex += 2;
                biCompression = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                biSizeImage = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                biXPelsPerMeter = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                biYPelsPerMeter = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                biClrUsed = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                biClrImportant = BitConverter.ToUInt32(ImageData, ReadIndex);
                ReadIndex += 4;
                #endregion
                int ColorCount = RgbCount();
                if (ColorCount == -1) return;
                for (int i = 0; i != ColorCount; i++)
                {
                    byte Blue = ImageData[ReadIndex];
                    byte Green = ImageData[ReadIndex + 1];
                    byte Red = ImageData[ReadIndex + 2];
                    byte Reserved = ImageData[ReadIndex + 3];
                    ColorTable.Add(Color.FromArgb((int)Reserved, (int)Red, (int)Green, (int)Blue));
                    ReadIndex += 4;
                }
                int Size = (int)(biBitCount * biWidth) / 8;       // 象素的大小*象素数 /字节数              
                if ((double)Size < biBitCount * biWidth / 8) Size++;       //如果是 宽19*4（16色）/8 =9.5 就+1;
                if (Size < 4) Size = 4;
                byte[] WidthByte = new byte[Size];
                _IconBitMap = new Bitmap((int)biWidth, (int)(biHeight / 2));
                for (int i = (int)(biHeight / 2); i != 0; i--)
                {
                    for (int z = 0; z != Size; z++)
                    {
                        WidthByte[z] = ImageData[ReadIndex + z];
                    }
                    ReadIndex += Size;
                    IconSet(_IconBitMap, i - 1, WidthByte);
                }

                //取掩码
                int MaskSize = (int)(biWidth / 8);
                if ((double)MaskSize < biWidth / 8) MaskSize++;       //如果是 宽19*4（16色）/8 =9.5 就+1;
                if (MaskSize < 4) MaskSize = 4;
                byte[] MashByte = new byte[MaskSize];
                for (int i = (int)(biHeight / 2); i != 0; i--)
                {
                    for (int z = 0; z != MaskSize; z++)
                    {
                        MashByte[z] = ImageData[ReadIndex + z];
                    }
                    ReadIndex += MaskSize;
                    IconMask(_IconBitMap, i - 1, MashByte);
                }

            }
            private int RgbCount()
            {
                switch (biBitCount)
                {
                    case 1:
                        return 2;
                    case 4:
                        return 16;
                    case 8:
                        return 256;
                    case 24:
                        return 0;
                    case 32:
                        return 0;
                    default:
                        return -1;
                }
            }
            private void IconSet(Bitmap IconImage, int RowIndex, byte[] ImageByte)
            {
                int Index = 0;
                switch (biBitCount)
                {
                    case 1:
                        #region 一次读8位 绘制8个点
                        for (int i = 0; i != ImageByte.Length; i++)
                        {
                            System.Collections.BitArray MyArray = new System.Collections.BitArray(new byte[] { ImageByte[i] });

                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[7])]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[6])]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[5])]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[4])]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[3])]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[2])]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[1])]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[0])]);
                            Index++;
                        }
                        #endregion
                        break;
                    case 4:
                        #region 一次读8位 绘制2个点
                        for (int i = 0; i != ImageByte.Length; i++)
                        {
                            int High = ImageByte[i] >> 4;  //取高4位
                            int Low = ImageByte[i] - (High << 4); //取低4位
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[High]);
                            Index++;
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[Low]);
                            Index++;
                        }
                        #endregion
                        break;
                    case 8:
                        #region 一次读8位 绘制一个点
                        for (int i = 0; i != ImageByte.Length; i++)
                        {
                            if (Index >= IconImage.Width) return;
                            IconImage.SetPixel(Index, RowIndex, ColorTable[ImageByte[i]]);
                            Index++;
                        }
                        #endregion
                        break;
                    case 24:
                        #region 一次读24位 绘制一个点

                        for (int i = 0; i != ImageByte.Length / 3; i++)
                        {
                            if (i >= IconImage.Width) return;
                            IconImage.SetPixel(i, RowIndex, Color.FromArgb(ImageByte[Index + 2], ImageByte[Index + 1], ImageByte[Index]));
                            Index += 3;
                        }
                        #endregion
                        break;
                    case 32:
                        #region 一次读32位 绘制一个点

                        for (int i = 0; i != ImageByte.Length / 4; i++)
                        {
                            if (i >= IconImage.Width) return;

                            IconImage.SetPixel(i, RowIndex, Color.FromArgb(ImageByte[Index + 2], ImageByte[Index + 1], ImageByte[Index]));
                            Index += 4;
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
            }
            private void IconMask(Bitmap IconImage, int RowIndex, byte[] MaskByte)
            {

                BitArray set = new BitArray(MaskByte);
                int ReadIndex = 0;
                for (int i = set.Count; i != 0; i--)
                {
                    if (ReadIndex >= IconImage.Width) return;
                    Color SetColor = IconImage.GetPixel(ReadIndex, RowIndex);
                    if (!set[i - 1]) IconImage.SetPixel(ReadIndex, RowIndex, Color.FromArgb(255, SetColor.R, SetColor.G, SetColor.B));
                    ReadIndex++;

                }

            }
            private int GetBitNumb(bool BitArray)
            {
                if (BitArray) return 1;
                return 0;
            }

        }
    }
}