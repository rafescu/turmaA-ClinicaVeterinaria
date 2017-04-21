using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models {
    public class Consultas {
        [Key] //forca o atributo a ser PK
        public int ConsultaID { get; set; }

        [Column(TypeName = "date")] //só regista 'datas', não 'horas'
        public DateTime DataConsulta { get; set; }


        [ForeignKey("Veterinario")]
        public int VeterinarioFK { get; set; }
        public virtual Veterinarios Veterinario { get; set; }


        [ForeignKey("Animal")]
        public int AnimalFK { get; set; }
        public virtual Animais Animal { get; set; }
    }
}