using System;
using System.Collections.Generic;

namespace Prj_ConsultaNotas_SO_DG.Entities
{
    public partial class Notas
    {
        public int Id { get; set; }
        public int? Docente_Id { get; set; }
        public int? Estudiante_Id { get; set; }
        public int? Asignatura_Id { get; set; }
        public decimal? Nota1 { get; set; }
        public decimal? Nota2 { get; set; }
        public decimal? Nota3 { get; set; }

        public virtual Asignatura Asignatura { get; set; }
        public virtual Docente Docente { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
