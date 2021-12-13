using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoWPF.LottoUtility;

namespace LottoWPF.LottoKupon
{
    class LottoRække : Række
    {
        public LottoRække()
        {
            FillRække();
        }

        public override void FillRække()
        {
            for (int i = 0; i < tals.Length; i++)
            {
                tals[i] = new Tal(36);

                if (tals[i].Validate(tals) == false && i != 0)
                {
                    tals[i] = null;
                    i--;
                }
                else
                {
                    this.Id += $"{tals[i].Værdi}-";
                }
            }
            Array.Sort(tals);
        }
        public override string ToString()
        {
            string result = "";
            foreach(Tal t in tals)
            {
                result += $"{t.Værdi:0#} ";
            }
            return result;
        }
    }
}
