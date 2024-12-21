using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ManageSalons()
    {
        var salons = _context.Salonlar.ToList();
        return View(salons);
    }

    public IActionResult ManageEmployees()
    {
        var employees = _context.Calisanlar.ToList();
        return View(employees);
    }

    public IActionResult ManageAppointments()
    {
        var appointments = _context.Randevular.Include(r => r.Calisan).Include(r => r.Islem).Include(r => r.Musteri).ToList();
        return View(appointments);
    }

    [HttpPost]
    public IActionResult ApproveAppointment(int id)
    {
        var randevu = _context.Randevular.Find(id);
        if (randevu != null)
        {
            randevu.Onaylandi = true;
            _context.SaveChanges();
        }
        return RedirectToAction("ManageAppointments");
    }
}
