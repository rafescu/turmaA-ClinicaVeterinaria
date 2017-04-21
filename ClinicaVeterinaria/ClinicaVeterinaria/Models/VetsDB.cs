using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models {
    public class VetsDB : DbContext{

        //representar as tabelas a criar na Base de Dados
        public virtual DbSet<Donos> Donos { get; set; }

        public virtual DbSet<Animais> Animais { get; set; }

        public virtual DbSet<Veterinarios> Veterinarios { get; set; }

        public virtual DbSet<Consultas> Consultas { get; set; }


        //especificar onde será criada a Base de Dados
        public VetsDB() :base("LocalizacaoDaBD") {

        }
    }
}