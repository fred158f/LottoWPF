using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //System.IO;**

namespace LottoWPF
{
    public static class FileSaver // public static**
    {
        static DirectoryInfo dir = new DirectoryInfo(@$"C:\lotto\{DateTime.Today.ToShortDateString()}\");
        public static void Save(string kupon, int i)
        {   
            if (!dir.Exists)
            {
                dir.Create();
            }
            FileStream stream = new(dir.FullName + $"lottokupon{i:0#}.txt", FileMode.OpenOrCreate);
            byte[] s = new UTF8Encoding(true).GetBytes(kupon);
            stream.Write(s);
            stream.Close();
        }

    }
}
