using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace programmingLab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            
            VirtualMemory a = new VirtualMemory("123.dat");


            Page h = new Page();
      
            
            using (var mmf = MemoryMappedFile.CreateFromFile("sdsd.dat", FileMode.OpenOrCreate))
            {
                h.WritePage(mmf,0);
            }
           
          

         
           // Console.WriteLine(132%128);
            Console.WriteLine(a[5]);
            Console.WriteLine(a[128]);
        }
    }
}