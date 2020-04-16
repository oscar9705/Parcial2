using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prj_ConsultaNotas_SO_DG.Data;
using Prj_ConsultaNotas_SO_DG.Entities;

namespace Prj_ConsultaNotas_SO_DG.Pages.NotasPage
{
    public class EditModel : PageModel
    {
        private readonly Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext _context;

        public EditModel(Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notas Notas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notas = await _context.Notas
                .Include(n => n.Asignatura)
                .Include(n => n.Docente)
                .Include(n => n.Estudiante).FirstOrDefaultAsync(m => m.Id == id);

            if (Notas == null)
            {
                return NotFound();
            }
           ViewData["Asignatura_Id"] = new SelectList(_context.Asignatura, "Id", "Id");
           ViewData["Docente_Id"] = new SelectList(_context.Docente, "Id", "Id");
           ViewData["Estudiante_Id"] = new SelectList(_context.Estudiante, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotasExists(Notas.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotasExists(int id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }
    }
}
