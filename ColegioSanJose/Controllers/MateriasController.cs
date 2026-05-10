using Microsoft.AspNetCore.Mvc;
using ColegioSanJose.Data;
using ColegioSanJose.Models;

namespace ColegioSanJose.Controllers
{
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public IActionResult Index()
        {
            var lista = _context.Materias.ToList();

            return View(lista);
        }

        // ABRIR CREATE
        public IActionResult Create()
        {
            return View(new Materia());
        }

        // GUARDAR CREATE
        [HttpPost]
        public IActionResult Create(Materia materia)
        {
            _context.Materias.Add(materia);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ABRIR EDIT
        public IActionResult Edit(int id)
        {
            var materia = _context.Materias.Find(id);

            return View(materia);
        }

        // GUARDAR EDIT
        [HttpPost]
        public IActionResult Edit(Materia materia)
        {
            _context.Materias.Update(materia);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ELIMINAR
        public IActionResult Delete(int id)
        {
            var materia = _context.Materias.Find(id);

            _context.Materias.Remove(materia);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
