using KuaforRandevuSistemi.Models;
using Microsoft.AspNetCore.Identity;

public class Musteri
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Telefon { get; set; }
    public string Email { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public ICollection<Randevu> Randevular { get; set; }
}
