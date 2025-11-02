using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROGRATHON.Data;
using PROGRATHON.Models;

namespace PROGRATHON.Controllers
{
    public class ReservaController : Controller
    {

        //Invocar o hacer una instancia
        private readonly AppDbContext _context;

        //Instanciarme
        public ReservaController(AppDbContext context)
        {
            _context = context;
        }


        //Los metodos ahora son asyncronicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reserva.ToListAsync());
        }


        //Crear

        public IActionResult Crear()
        {

            return View();
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Crear(Reserva _Reserva)
        {

            if (ModelState.IsValid)
            {

                _context.Add(_Reserva);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return View(_Reserva);
        }

    }
}