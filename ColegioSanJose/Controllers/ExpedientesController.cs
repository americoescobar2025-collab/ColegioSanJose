using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Data;
using ColegioSanJose.Models;

namespace ColegioSanJose.Controllers
{
    public class ExpedientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // LISTADO
        // =========================
        public async Task<IActionResult> Index()
        {
            var lista = _context.Expedientes
                .Include(e => e.Alumno)
                .Include(e => e.Materia);

            return View(await lista.ToListAsync());
        }

        // =========================
        // CREATE (GET)
        // =========================
        public IActionResult Create()
        {
            ViewBag.Alumnos = _context.Alumnos.ToList();
            ViewBag.Materias = _context.Materias.ToList();
            return View();
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expediente expediente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alumnos = _context.Alumnos.ToList();
                ViewBag.Materias = _context.Materias.ToList();
                return View(expediente);
            }

            _context.Add(expediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // EDIT (GET)
        // =========================
        public async Task<IActionResult> Edit(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);

            if (expediente == null)
                return NotFound();

            ViewBag.Alumnos = _context.Alumnos.ToList();
            ViewBag.Materias = _context.Materias.ToList();

            return View(expediente);
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expediente expediente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alumnos = _context.Alumnos.ToList();
                ViewBag.Materias = _context.Materias.ToList();
                return View(expediente);
            }

            _context.Update(expediente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // DELETE (GET)
        // =========================
        public async Task<IActionResult> Delete(int id)
        {
            var expediente = await _context.Expedientes
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (expediente == null)
                return NotFound();

            return View(expediente);
        }

        // =========================
        // DELETE (POST)
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);

            if (expediente != null)
            {
                _context.Expedientes.Remove(expediente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // PROMEDIOS
        // =========================
        public IActionResult Promedios()
        {
            var data = _context.Expedientes
                .Include(e => e.Alumno)
                .ToList()
                .GroupBy(e => e.Alumno.Nombres + " " + e.Alumno.Apellidos)
                .Select(g => new
                {
                    Alumno = g.Key,
                    Promedio = g.Average(x => x.Nota)
                })
                .ToList();

            return View(data);
        }

        // =========================
        // DATOS PROMEDIOS (GRÁFICA)
        // =========================
        public IActionResult PromediosData()
        {
            var data = _context.Expedientes
                .Include(e => e.Alumno)
                .ToList()
                .GroupBy(e => e.Alumno.Nombres + " " + e.Alumno.Apellidos)
                .Select(g => new
                {
                    alumno = g.Key,
                    promedio = g.Average(x => x.Nota)
                })
                .ToList();

            return Json(data);
        }

        // =========================
        // GRÁFICA DE PROMEDIOS
        // =========================
        public IActionResult Grafica()
        {
            return View();
        }
    }
}