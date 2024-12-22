using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KuaforRandevuSistemi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Admin panel ana sayfası
    public IActionResult Index()
    {
        return View();
    }

    // Çalışan ekleme sayfası
    public IActionResult CreateCalisan()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCalisan(Calisan calisan)
    {
        if (ModelState.IsValid)
        {
            _context.Calisanlar.Add(calisan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(calisan);
    }

    // Randevu onaylama sayfası
    public async Task<IActionResult> OnayBekleyenRandevular()
    {
        var randevular = await _context.Randevular
            .Include(r => r.Musteri)
            .Include(r => r.Calisan)
            .Include(r => r.Islem)
            .Where(r => !r.Onaylandi)
            .ToListAsync();
        return View(randevular);
    }

    [HttpPost]
    public async Task<IActionResult> Onayla(int id)
    {
        var randevu = await _context.Randevular.FindAsync(id);
        if (randevu != null)
        {
            randevu.Onaylandi = true;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(OnayBekleyenRandevular));
    }
}
