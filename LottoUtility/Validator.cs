using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoWPF.LottoKupon;

namespace LottoWPF.LottoUtility
{
    public static class Validator
    {
        public static bool Validate(this IValidateable t, IValidateable[] tals)
        {

            foreach (IValidateable n in tals)
            {
                if (n == null)
                    break;

                if (n != t)
                {
                    if (t.Equal(n))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    }
}
