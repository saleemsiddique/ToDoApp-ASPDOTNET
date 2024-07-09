using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Pages
{
    public class ToDoScreenModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ToDoScreenModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Tarea> Tareas { get; set; }

        public async Task OnGetAsync()
        {
            Tareas = await _context.Tareas.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCrearTareaAsync(string titulo, string descripcion)
        {
            if (ModelState.IsValid)
            {
                var nuevaTarea = new Tarea
                {
                    title = titulo,
                    description = descripcion
                };

                _context.Tareas.Add(nuevaTarea);
                await _context.SaveChangesAsync();

                return RedirectToPage();
            }

            // Si el modelo no es válido, agregamos un error al ModelState
            ModelState.AddModelError(string.Empty, "La creación de la tarea ha fallado. Por favor, verifica los datos ingresados.");

            // Retornamos la página actual para que se pueda mostrar el mensaje de error
            return Page();
        }

        public async Task<IActionResult> OnpostEditarTareaAsync(int id, string titulo, string descripcion)
        {
            if (ModelState.IsValid) {
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea != null)
                {
                    tarea.title = titulo;
                    tarea.description = descripcion;
                    await _context.SaveChangesAsync();
                }
                return RedirectToPage();
            }
            // Si el modelo no es válido, agregamos un error al ModelState
            ModelState.AddModelError(string.Empty, "La edicion de la tarea ha fallado. Por favor, verifica los datos ingresados.");

            // Retornamos la página actual para que se pueda mostrar el mensaje de error
            return Page();
        }

    }
}
