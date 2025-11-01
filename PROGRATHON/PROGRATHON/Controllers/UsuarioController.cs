using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROGRATHON.Data;
using PROGRATHON.Models;

namespace PROGRATHON.Controllers
{
    public class UsuarioController : Controller
    {

        //Invocar o hacer una instancia
        private readonly AppDbContext _context;

        //Instanciarme
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }


        //Los metodos ahora son asyncronicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }


        //Crear???

        public IActionResult Crear()
        {

            return View();
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioModel _Usuario)
        {

            if (ModelState.IsValid)
            {

                _context.Add(_Usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return View(_Usuario);
        }

    }
}