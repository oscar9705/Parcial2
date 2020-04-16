using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prj_ConsultaNotas_SO_DG.Data;
using Prj_ConsultaNotas_SO_DG.Entities;

namespace Prj_ConsultaNotas_SO_DG.Pages.AsignaturaPage
{
    public class IndexModel : PageModel
    {
        private readonly Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext _context;

        public IndexModel(Prj_ConsultaNotas_SO_DG.Data.Prj_ConsultaNotas_SO_DGContext context)
        {
            _context = context;
        }

        public IList<Asignatura> Asignatura { get;set; }

        public async Task OnGetAsync()
        {
            Asignatura = await _context.Asignatura.ToListAsync();
        }
    }
}
