using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prj_ConsultaNotas_SO_DG.Data;
using Prj_ConsultaNotas_SO_DG.Entities;

namespace Prj_ConsultaNotas_SO_DG.Pages.EstudiantePage
{
    public class DeleteModel : PageModel
    {
        private readonly Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext _context;

        public DeleteModel(Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estudiante = await _context.Estudiante.FirstOrDefaultAsync(m => m.Id == id);

            if (Estudiante == null)
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

            Estudiante = await _context.Estudiante.FindAsync(id);

            if (Estudiante != null)
            {
                _context.Estudiante.Remove(Estudiante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
