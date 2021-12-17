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
        const int antalRækker = 10;
        const int antalJokere = 2;
        Række[] rækkes;
        public string Date { get; private set; }
        public string Coupon { get; private set; }
        private bool joke;
        public Kupon(bool wantJoke)
        {
            rækkes = new Række[antalRækker + (wantJoke ? antalJokere : 0)];
            Date = DateTime.Today.ToShortDateString();
            joke = wantJoke;
            CreateCoupon(joke);
            Coupon = Printable();
        }

        public void CreateCoupon(bool joke)
        {
            for (int i = 0; i < rækkes.Length; i++)
            {
                if (i < antalRækker)
                {
                    rækkes[i] = new LottoRække();
                    if (i != 0 && rækkes[i].Validate(rækkes) == false)
                    {
                        rækkes[i] = null;
                        i--;
                    }
                }
                else if (joke)
                {
                    rækkes[i] = new JokerRække();
                }
            }
        }

        public string Printable()
        {
            string final = "";

            string[] title = { $"Lotto {Date}\n\n", "1-uge\n", "LYN-LOTTO\n\n" };
            string jokerTitle = "****** Joker Tal ******\n";

            int cent = (rækkes[0].ToString().Length / 2) + 4;

            final += Spaces(title, cent);

            for (int i = 0; i < rækkes.Length; i++)
            {
                if (i < antalRækker)
                {
                    final += Spaces((i < 9 ? $" {i + 1}. " : $"{i + 1}. ") + rækkes[i].ToString() + "\n", cent);

                }
                else if (joke)
                {
                    if (i == antalRækker)
                        final += "\n"+Spaces(jokerTitle, cent);
                    final += Spaces(rækkes[i].ToString() + "\n", cent + 5);
                }
            }

            return final;
        }

        public override string ToString()
        {
            return Coupon;
        }

        public string Spaces(string[] strings, int center)
        {
            string final = "";
            foreach(string s in strings)
            {
                final += $"{new string(' ', center - s.Length/2)}{s}";
            }

            return final;
        }
        public string Spaces(string strings, int center)
        {
            return $"{new string(' ', center - strings.Length/2)}{strings}";
        }

    }
}
