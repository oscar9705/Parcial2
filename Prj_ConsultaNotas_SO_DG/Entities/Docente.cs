using System;
using System.Collections.Generic;

namespace Prj_ConsultaNotas_SO_DG.Entities
{
    public partial class Docente
    {
        public Docente()
        {
            Notas = new HashSet<Notas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Notas> Notas { get; set; }
    }
}
