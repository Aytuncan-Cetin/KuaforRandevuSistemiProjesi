using System.Collections.Generic;

namespace KuaforRandevuSistemi.Models
{
    public class Salon
    {
       
            public int Id { get; set; }
            public string Ad { get; set; }
            public string Adres { get; set; }
            public string Telefon { get; set; }
            public List<Calisan> Calisanlar { get; set; }
            public List<Islem> Islemler { get; set; }
        

    }
}
