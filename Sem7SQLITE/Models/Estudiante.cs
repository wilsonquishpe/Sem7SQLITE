using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Sem7SQLITE.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }

        [MaxLength(50)]
        public string COntrasena { get; set; }
    }
}
