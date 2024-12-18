namespace KuaforRandevuSistemi.Models
{
    public class Calisan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string UzmanlikAlani { get; set; }
        public bool MusaitlikDurumu { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
    }

}
