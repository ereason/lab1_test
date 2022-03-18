using System;
using System.IO.MemoryMappedFiles;

namespace programmingLab1
{
    public class Page
    {
        private const int bitmapSize = 128;
        private const int arrSize = 512; //bits int - 4 bites, 128*4=512
        public bool[] bitmap = new bool[bitmapSize];
        public int[] arr = new int[arrSize / sizeof(int)];

        public Page()
        {
            
        }

        public Page(MemoryMappedFile file, int offset)
        {
            using (var accessor = file.CreateViewAccessor(offset, bitmapSize + arrSize))
            {
                byte c;
                for (long i = 0; i < bitmapSize; i += 1)
                {
                    accessor.Read(i, out c);
                    bitmap[i] = c == 1;
                }

                byte[] val = new byte[4];
                var j = 0;
                for (long i = bitmapSize; i < (arrSize + bitmapSize); i += 4)
                {
                    accessor.ReadArray(i, val, 0, 4);
                    arr[j++] = BitConverter.ToInt32(val, 0);
                }
            }
        }

        public void WritePage(MemoryMappedFile file, int offset)
        {
            using (var accessor = file.CreateViewAccessor(offset, bitmapSize + arrSize, access: MemoryMappedFileAccess.ReadWrite))
            {
               
                    accessor.Write(0, 'e');
            }
        }

        public int this[int index]
        {
            get
            {
                return arr[index];
            }
        }
    }
}