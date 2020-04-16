using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prj_ConsultaNotas_SO_DG.Data;
using Prj_ConsultaNotas_SO_DG.Entities;

namespace Prj_ConsultaNotas_SO_DG.Pages.NotasPage
{
    public class CreateModel : PageModel
    {
        private readonly Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext _context;

        public CreateModel(Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Asignatura_Id"] = new SelectList(_context.Asignatura, "Id", "Nombre");
        ViewData["Docente_Id"] = new SelectList(_context.Docente, "Id", "Nombre");
        ViewData["Estudiante_Id"] = new SelectList(_context.Estudiante, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Notas Notas { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notas.Add(Notas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
