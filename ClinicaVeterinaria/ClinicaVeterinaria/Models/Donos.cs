using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models {
    public class Donos {

        // vai representar os dados da tabela dos DONOS

        // criar o construtor desta classe
        // e carregar a lista de Animais
        public Donos() {
            ListaDeAnimais = new HashSet<Animais>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //o PK não será AutoNumber
        public int DonoID { get; set; }

        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório.")]
        [Display(Name ="Nome do Dono do Animal")]
        public string Nome { set; get; }

        [Required]
        public string NIF { get; set; }

        // especificar que um DONO tem muitos ANIMAIS
        public ICollection<Animais> ListaDeAnimais { get; set; }

    }
}