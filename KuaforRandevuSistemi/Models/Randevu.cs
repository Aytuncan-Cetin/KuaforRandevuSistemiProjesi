using Microsoft.AspNetCore.Mvc;

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
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context; 
        public RandevuController(ApplicationDbContext context) 
        {
            _context = context; 
        }

        [HttpGet] 
        public IActionResult Create() 
        {
            ViewBag.Calisanlar = _context.Calisanlar.ToList(); 
            ViewBag.Islemler = _context.Islemler.ToList(); 
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                var musteri = _context.Musteriler.FirstOrDefault(m => m.Email == User.Identity.Name); 
                if (musteri == null) 
                { 
                    ModelState.AddModelError("", "Kayıtlı müşteri bulunamadı."); 
                    ViewBag.Calisanlar = _context.Calisanlar.ToList(); 
                    ViewBag.Islemler = _context.Islemler.ToList(); 
                    return View(randevu);
                }
                var existingRandevu = _context.Randevular.FirstOrDefault(r => r.CalisanId == randevu.CalisanId && r.Tarih == randevu.Tarih); 

                if (existingRandevu != null) 
                {
                    ModelState.AddModelError("", "Bu saatte çalışan zaten başka bir randevuda."); 
                    ViewBag.Calisanlar = _context.Calisanlar.ToList(); 
                    ViewBag.Islemler = _context.Islemler.ToList(); 
                    return View(randevu); 
                }
                randevu.Onaylandi = false; 
                randevu.MusteriId = musteri.Id; // Müşteri ID'sini ekle 
                _context.Randevular.Add(randevu);
                _context.SaveChanges(); 
                return RedirectToAction("Index"); 
            }   
            ViewBag.Calisanlar = _context.Calisanlar.ToList(); 
            ViewBag.Islemler = _context.Islemler.ToList(); 
            return View(randevu); } }
        }
        
