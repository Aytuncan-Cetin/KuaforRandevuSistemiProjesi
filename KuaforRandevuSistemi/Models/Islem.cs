using KuaforRandevuSistemi.Models;

public class Islem
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public decimal Fiyat { get; set; }
    public TimeSpan Sure { get; set; }
    public ICollection<Randevu> Randevular { get; set; }
}
