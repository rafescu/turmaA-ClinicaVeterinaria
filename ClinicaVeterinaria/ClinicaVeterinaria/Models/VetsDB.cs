using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            // não podemos usar a chave seguinte, nesta geração de tabelas
            // por causa das tabelas do Identity (gestão de utilizadores)
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}