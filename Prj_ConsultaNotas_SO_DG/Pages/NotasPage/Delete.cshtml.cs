using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prj_ConsultaNotas_SO_DG.Data;
using Prj_ConsultaNotas_SO_DG.Entities;

namespace Prj_ConsultaNotas_SO_DG.Pages.NotasPage
{
    public class DeleteModel : PageModel
    {
        private readonly Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext _context;

        public DeleteModel(Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notas = await _context.Notas.FindAsync(id);

            if (Notas != null)
            {
                _context.Notas.Remove(Notas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
