using Microsoft.AspNetCore.Mvc;
using ColegioSanJose.Data;
using System.Linq;

namespace ColegioSanJose.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            ViewBag.Alumnos = _context.Alumnos.Count();
            ViewBag.Materias = _context.Materias.Count();

            var promedio = _context.Expedientes.Any()
                ? _context.Expedientes.Average(e => Convert.ToDouble(e.Nota))
                : 0;

            ViewBag.Promedio = Math.Round(promedio, 2);

            return View();
        }
    }
}
