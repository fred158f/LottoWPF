using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoWPF.LottoUtility;

namespace LottoWPF.LottoKupon
{
    public abstract class Række :  IValidateable
    {  
        public string Id { get; protected set; }
        public Tal[] tals;
        public Række(int antalTal = 7)
        {
            tals = new Tal[antalTal];
        }
        public abstract void FillRække();
        public bool Equal(dynamic other) => other != null && Id == other.Id;
    }
}
