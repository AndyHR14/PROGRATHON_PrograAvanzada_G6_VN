using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROGRATHON.Data;
using PROGRATHON.Models;

namespace PROGRATHON.Controllers
{
    public class LaboratoriosController : Controller
    {
        private readonly AppDbContext _context;

        public LaboratoriosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Laboratorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Laboratorio.ToListAsync());
        }

        //Crear

        public IActionResult Crear()
        {

            return View();
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Crear(Laboratorio _Laboratorio)
        {

            if (ModelState.IsValid)
            {

                _context.Add(_Laboratorio);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return View(_Laboratorio);
        }

    }
}
    
