using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace programmingLab1
{
    public class VirtualMemory
    {
        public string FilePath { get; }

        public VirtualMemory(string filePath)
        {
            this.FilePath = filePath;
        }

        public Page GetPage(int offset)
        {
            using (var mmf = MemoryMappedFile.CreateFromFile(this.FilePath, FileMode.Append))
            {
                return new Page(mmf, offset);
            }
        }
        
        public void WritePage(Page page,int offset)
        {
            using (var mmf = MemoryMappedFile.CreateFromFile(this.FilePath, FileMode.CreateNew))
            {
                page.WritePage(mmf,offset);
            }
        }

        public int this[int index]
        {
            get
            {
                var pageNum = (index / 128);
                //512 128 каждыек 128 числел = 620
                var page = GetPage(pageNum * 640);
                var i = index % 128;
                return page[i];
            }
        }
    }
}