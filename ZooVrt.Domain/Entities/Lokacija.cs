
namespace ZooVrt.Domain.Entities
{
    public class Lokacija
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Vrsta { get; set; }
        public int Zbir { get; set; }
        public int StanisteId { get; set; }
        public int ZooVrtId { get; set; }

        public TipStanista Staniste { get; set; }
        public ZooVrt ZooVrt { get; set; }
    }
}
