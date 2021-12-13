using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LottoWPF.LottoKupon;

namespace LottoWPF
{
    public static class FileSaver 
    {
        static DirectoryInfo dir = new DirectoryInfo(@$"C:\lotto\{DateTime.Today.ToString("dd-MM-yy")}\");
        public static void Save(Kupon[] kuponer)
        {
            if (!dir.Exists)
            {
                dir.Create();
            }

            for (int i = 0; i < kuponer.Length; i++)
            {
                string Filename = $"lottokupon{i + 1:0#}.txt";
                StreamWriter stream = new StreamWriter(dir + Filename);
                stream.WriteLine(kuponer[i].Coupon);
                stream.Close();

            }
        }
    }
}
