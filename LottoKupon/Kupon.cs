using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoWPF.LottoUtility;

namespace LottoWPF.LottoKupon
{
    public class Kupon
    {
        const int antal = 10;
        Række[] rækkes = new Række[antal];
        JokerRække[] joker = new JokerRække[2];
        public string Date { get; private set; }
        public string Coupon { get; private set; }
        public string SaveableCoupon { get; private set; }
        private bool joke;
        public Kupon(bool wantJoke)
        {
            joke = wantJoke;
            CreateCoupon(joke);
            SaveableCoupon = ToString();
        }

        public void CreateCoupon(bool joke)
        {
            Date = DateTime.Today.ToShortDateString();

            Coupon += $"Lotto {Date}\n\n1-uge\nLYN-LOTTO\n\n";

            for (int i = 0; i < antal; i++)
            {
                rækkes[i] = new LottoRække();
                if (i != 0 && rækkes[i].Validate(rækkes) == false)
                {
                    rækkes[i] = null;
                    i--;
                }
                Coupon += i < 9 ? $"  {i + 1}. " : $"{i + 1}. ";
                Coupon += rækkes[i].ToString();
                Coupon += "\n";
            }


            if (joke)
            {
                Coupon += "\n* * * * * * Joker Tal * * * * * * *\n";

                for (int i = 0; i < joker.Length; i++)
                {
                    joker[i] = new JokerRække();
                    Coupon += joker[i].ToString();
                    Coupon += "\n";
                }

            }
        }

        public override string ToString()
        {
            string[] arr = Coupon.Split('\n');
            string final = "";

            foreach(string s in arr)
            {
                if (s == arr[joke ? arr.Length-6 : arr.Length-1])
                    final += " ";
                final += $"{new string(' ', (20 - s.Length/2))}{s}\n";
            }

            return final;
        }


    }
}
