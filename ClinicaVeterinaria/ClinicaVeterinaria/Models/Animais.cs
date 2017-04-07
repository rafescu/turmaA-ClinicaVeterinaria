using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models {
    public class Animais {

        public int ID { get; set; }

        public string Nome { get; set; }

        public string Raca { get; set; }

        public string Especie { get; set; }

        public double Peso { get; set; }

        public int Idade { get; set; }

        //#######################################################
        //definir as Chaves Forasteiras, associadas a esta classe
        //#######################################################

        [ForeignKey("DonoFK")]
        public Donos Dono { get; set; } //relaciona, no C#, o objeto Animal com o objeto Dono

        public int DonoFK { get; set; } //relaciona, no SqlServer, o Animal com o seu Dono {FK}


    }
}