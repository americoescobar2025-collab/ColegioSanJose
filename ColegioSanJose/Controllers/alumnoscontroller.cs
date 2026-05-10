using Microsoft.AspNetCore.Mvc;
using ColegioSanJose.Data;
using ColegioSanJose.Models;

namespace ColegioSanJose.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public IActionResult Index()
        {
            var lista = _context.Alumnos.ToList();

            return View(lista);
        }

        // ABRIR FORMULARIO CREATE
        public IActionResult Create()
        {
            return View(new Alumno());
        }

        // GUARDAR CREATE
        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ABRIR FORMULARIO EDIT
        public IActionResult Edit(int id)
        {
            var alumno = _context.Alumnos.Find(id);

            return View(alumno);
        }

        // GUARDAR EDIT
        [HttpPost]
        public IActionResult Edit(Alumno alumno)
        {
            _context.Alumnos.Update(alumno);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ELIMINAR
        public IActionResult Delete(int id)
        {
            var alumno = _context.Alumnos.Find(id);

            _context.Alumnos.Remove(alumno);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}