using System;
using System.Collections.Generic;
using System.Text;

namespace ZooVrt.Common.Models
{
    public class LokacijaModel
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Vrsta { get; set; }
        public int Zbir { get; set; }

        public TipStanistaModel Staniste { get; set; }
    }
}
