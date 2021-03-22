using System.Collections.Generic;

namespace ZooVrt.Domain.Entities
{
    public class ZooVrt
    {
        public int Id { get; set; }
        public int N { get; set; }
        public int M { get; set; }
        public int Kapacitet { get; set; }
        public ICollection<Lokacija> Lokacije { get; set; }
    }
}
