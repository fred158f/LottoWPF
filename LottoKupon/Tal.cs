using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoWPF.LottoUtility;

namespace LottoWPF.LottoKupon
{
    public class Tal : IComparable<Tal>, IValidateable
    {
        public int Værdi { get; private set; }
        public Tal(int Max) => Værdi = Max.RndTal();
        public int CompareTo(Tal other) => Værdi.CompareTo(other.Værdi);
        public bool Equal(dynamic other) => other != null && Værdi == other.Værdi;

    }
}
