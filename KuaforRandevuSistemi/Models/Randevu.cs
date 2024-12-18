namespace KuaforRandevuSistemi.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }
        public int IslemId { get; set; }
        public Islem Islem { get; set; }
        public bool Onaylandi { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
    }

}
