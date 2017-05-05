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
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+((-| )(((da|de|do|das|dos )))?[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+)*", ErrorMessage = "O {0} introduzido não é válido. Não são permitidos números e os nomes iniciam com letra maiúscula.")]
        public string Nome { set; get; }

        [Required]
        [RegularExpression("[0-9 ]{9}", ErrorMessage ="Escreva apenas 9 carateres numéricos...")]
        public string NIF { get; set; }

        // especificar que um DONO tem muitos ANIMAIS
        public ICollection<Animais> ListaDeAnimais { get; set; }

    }
}