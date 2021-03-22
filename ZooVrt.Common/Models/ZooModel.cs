using System;
using System.Collections.Generic;
using System.Text;

namespace ZooVrt.Common.Models
{
    public class ZooModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int N { get; set; }
        public int M { get; set; }
        public int Kapacitet { get; set; }
        public ICollection<LokacijaModel> Lokacije { get; set; }
    }
}
