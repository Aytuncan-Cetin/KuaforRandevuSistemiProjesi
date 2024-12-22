using KuaforRandevuSistemi.Models;

public class Calisan
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Telefon { get; set; }
    public string UzmanlikAlanlari { get; set; }
    public ICollection<Islem> YapabildigiIslemler { get; set; }
    public ICollection<Randevu> Randevular { get; set; }
}
