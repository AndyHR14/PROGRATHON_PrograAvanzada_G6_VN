using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROGRATHON.Data;
using PROGRATHON.Models;
using PROGRATHON.ViewModels;

namespace PROGRATHON.Controllers
{
    public class ReservaController : Controller
    {
        private readonly AppDbContext _context;

        public ReservaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Reserva
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reserva
                .Include(r => r.Usuario)
                .Include(r => r.Laboratorio)
                .OrderByDescending(r => r.FechaYHora)
                .ToListAsync();

            return View(reservas);
        }

        // GET: /Reserva/Crear
        public async Task<IActionResult> Crear()
        {
            var vm = new ReservaCreateVM
            {
                Usuarios = await _context.Usuario
                    .Select(u => new SelectListItem
                    {
                        Value = u.IDUsuario.ToString(),
                        Text = u.NombreUsuario
                    })
                    .ToListAsync(),

                Laboratorios = await _context.Laboratorio
                    .Select(l => new SelectListItem
                    {
                        Value = l.IDLab.ToString(),
                        Text = l.NombreLab
                    })
                    .ToListAsync(),

                FechaYHora = DateTime.Now.AddHours(1)
            };

            return View(vm);
        }

        // POST: /Reserva/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ReservaCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                await CargarListas(vm);
                return View(vm);
            }

            // Validar existencia de usuario/lab
            var usuarioExiste = await _context.Usuario.AnyAsync(u => u.IDUsuario == vm.IDUsuario);
            var labExiste = await _context.Laboratorio.AnyAsync(l => l.IDLab == vm.IDLab);

            if (!usuarioExiste)
                ModelState.AddModelError(nameof(vm.IDUsuario), "El usuario no existe.");
            if (!labExiste)
                ModelState.AddModelError(nameof(vm.IDLab), "El laboratorio no existe.");

            if (!ModelState.IsValid)
            {
                await CargarListas(vm);
                return View(vm);
            }

            // Validar que no sea fecha pasada
            if (vm.FechaYHora <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(vm.FechaYHora), "La fecha debe ser futura.");
                await CargarListas(vm);
                return View(vm);
            }

            // Validar que no exista una reserva activa en ese lab y hora
            var conflicto = await _context.Reserva.AnyAsync(r =>
                r.Activa &&
                r.IDLab == vm.IDLab &&
                r.FechaYHora == vm.FechaYHora);

            if (conflicto)
            {
                ModelState.AddModelError("", "Ya hay una reserva activa para ese laboratorio en esa fecha y hora.");
                await CargarListas(vm);
                return View(vm);
            }

            // Crear la reserva
            var reserva = new Reserva
            {
                IDUsuario = vm.IDUsuario,
                IDLab = vm.IDLab,
                FechaYHora = vm.FechaYHora,
                Activa = true
            };

            _context.Add(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: /Reserva/Cancelar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancelar(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
                return NotFound();

            reserva.Activa = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Cargar listas de dropdowns
        private async Task CargarListas(ReservaCreateVM vm)
        {
            vm.Usuarios = await _context.Usuario
                .Select(u => new SelectListItem
                {
                    Value = u.IDUsuario.ToString(),
                    Text = u.NombreUsuario
                })
                .ToListAsync();

            vm.Laboratorios = await _context.Laboratorio
                .Select(l => new SelectListItem
                {
                    Value = l.IDLab.ToString(),
                    Text = l.NombreLab
                })
                .ToListAsync();
        }
    }
}
