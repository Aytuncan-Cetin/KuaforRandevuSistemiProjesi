using KuaforRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class IslemApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public IslemApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("Uzmanlik/{uzmanlik}")]
    public ActionResult<IEnumerable<Islem>> GetByUzmanlik(string uzmanlik)
    {
        var islemler = _context.Islemler.ToList(); // UzmanlikAlani olmadan tüm islemleri döndürür

        if (!islemler.Any())
        {
            return NotFound();
        }

        return islemler;
    }
}
