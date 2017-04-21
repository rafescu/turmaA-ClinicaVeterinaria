using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models {
    public class Animais {

        public Animais() {
            // inicialização da lista de Consultas de um Animal
            Consultas = new HashSet<Consultas>();
        }

        [Key]
        public int AnimalID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [StringLength(30)]
        public string Especie { get; set; }

        [Required]
        [StringLength(30)]
        public string Raca { get; set; }

        public float Peso { get; set; }

        public float? Altura { get; set; }


        // **************************
        // criar a chave forasteira
        // relaciona o objeto ANIMAL com um objeto DONO
        public Donos Dono { get; set; }

        // cria um atributo para funcionar como FK, na BD
        // e relaciona-o com o atributo anterior
        [ForeignKey("Dono")]
        public int DonosFK { get; set; }
        // **************************

        // um ANIMAL tem uma coleção de CONSULTAS
        public virtual ICollection<Consultas> Consultas { get; set; }


    }
}