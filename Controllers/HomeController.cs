using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeEventsWeb.Models;
using AnimeEventsWeb.Data;
using System.Threading.Tasks;

namespace AnimeEventsWeb.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Home/Index (Public Gallery)
    public async Task<IActionResult> Index()
    {
        // Solo mostraremos los eventos que no estén "Borrados" lógicamente (o simplemente mostrar todos y pintarles el estado)
        var events = await _context.AnimeEvents.ToListAsync();
        return View(events);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
