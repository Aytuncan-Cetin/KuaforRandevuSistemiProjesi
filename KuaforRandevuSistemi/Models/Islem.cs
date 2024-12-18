namespace KuaforRandevuSistemi.Models
{
    public class Islem
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Sure { get; set; }
        public decimal Ucret { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        public List<Randevu> Randevular { get; set; }
    }

}