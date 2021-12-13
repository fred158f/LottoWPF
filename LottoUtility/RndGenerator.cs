using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoWPF.LottoUtility
{
    public static class RndGenerator
    {
        static Random rnd = new Random();
        public static int RndTal(this int max) => rnd.Next(1, max + 1);  
    }
}
