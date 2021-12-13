using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoWPF.LottoKupon
{
    class LottoRække : Række
    {
        public LottoRække()
        {
            FillRække();
        }

        public override string ToString()
        {
            string result = "";
            foreach(Tal t in tals)
            {
                result += $"{t.Værdi:0#}  ";
            }
            return result;


        }
    }
}
