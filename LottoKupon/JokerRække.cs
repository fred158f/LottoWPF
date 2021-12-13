using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoWPF.LottoKupon
{


    class JokerRække : Række
    {
        public JokerRække()
        {
            FillRække();
        }

        public override void FillRække()
        {
            for (int i = 0; i < tals.Length; i++)
            {
                tals[i] = new Tal(9);
                Id += $"{tals[i].Værdi}";
            }
            Array.Sort(tals);
        }

        public override string ToString()
        {
            string result = "";
            foreach (Tal t in tals)
            {
                result += $"{t.Værdi} ";
            }
            return result;


        }
    }
}
