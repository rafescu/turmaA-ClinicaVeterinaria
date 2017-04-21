namespace ClinicaVeterinaria.Migrations
{
    using ClinicaVeterinaria.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClinicaVeterinaria.Models.VetsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ClinicaVeterinaria.Models.VetsDB context)
        {
            //  This method will be called after migrating to the latest version.

            //#############################################################
            // criação das classes DONOS, VETERINARIOS, ANIMAIS e CONSULTAS
            //#############################################################




            // Configuration --- SEED
            //=============================================================

            // ############################################################################################
            // adiciona DONOS
            var donos = new List<Donos> {
   new Donos  {DonoID=1, Nome = "Luís Freitas", NIF ="813635582" },
   new Donos  {DonoID=2, Nome = "Andreia Gomes", NIF ="854613462" },
   new Donos  {DonoID=3, Nome = "Cristina Sousa", NIF ="265368715" },
   new Donos  {DonoID=4, Nome = "Sónia Rosa", NIF ="835623190" },
   new Donos  {DonoID=5, Nome = "António Santos", NIF ="751512205" },
   new Donos  {DonoID=6, Nome = "Gustavo Alves", NIF ="728663835" },
   new Donos  {DonoID=7, Nome = "Rosa Vieira", NIF ="644388118" },
   new Donos  {DonoID=8, Nome = "Daniel Dias", NIF ="262618487" },
   new Donos  {DonoID=9, Nome = "Tânia Gomes", NIF ="842615197" },
   new Donos  {DonoID=10, Nome = "Andreia Correia", NIF ="635139506" },
   new Donos  {DonoID=11, Nome = "Márcio Alves", NIF ="715428372" },
   new Donos  {DonoID=12, Nome = "Inês Martins", NIF ="348385836" },
   new Donos  {DonoID=13, Nome = "Teresinha Vieira", NIF ="365555205" },
   new Donos  {DonoID=14, Nome = "Marco Soares", NIF ="540161898" },
   new Donos  {DonoID=15, Nome = "Lourdes Vieira", NIF ="528411261" },
   new Donos  {DonoID=16, Nome = "Júlio Morais", NIF ="266563928" },
   new Donos  {DonoID=17, Nome = "Carmem Oliveira", NIF ="717250604" },
   new Donos  {DonoID=18, Nome = "Denise Silva", NIF ="843547587" },
   new Donos  {DonoID=19, Nome = "Cristina Melo", NIF ="416933279" },
   new Donos  {DonoID=20, Nome = "Augusto Rosa", NIF ="485162005" }
};

            donos.ForEach(dd => context.Donos.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges(); //commit

            // ############################################################################################
            // adiciona ANIMAIS
            var animais = new List<Animais> {
   new Animais  {AnimalID=1, Nome = "Bubi", Especie ="cão", Raca="Pastor Alemão", Peso=24, DonosFK=1},
   new Animais  {AnimalID=2, Nome = "Pastor", Especie ="cão", Raca="Serra Estrela", Peso=50, DonosFK=3},
   new Animais  {AnimalID=3, Nome = "Tripé", Especie ="cão", Raca="Serra Estrela", Peso=45, DonosFK=2},
   new Animais  {AnimalID=4, Nome = "Kika", Especie ="cão", Raca="Serra Estrela", Peso=39, DonosFK=5},
   new Animais  {AnimalID=5, Nome = "Traquina", Especie ="cão", Raca="Serra Estrela", Peso=55, DonosFK=6},
   new Animais  {AnimalID=6, Nome = "Rufia", Especie ="cão", Raca="Serra Estrela", Peso=45, DonosFK=9},
   new Animais  {AnimalID=7, Nome = "Morde Tudo", Especie ="cão", Raca="Dobreman", Peso=39, DonosFK=10},
   new Animais  {AnimalID=8, Nome = "Forte", Especie ="cão", Raca="Rotweiler", Peso=20, DonosFK=7},
   new Animais  {AnimalID=9, Nome = "Mau", Especie ="cão", Raca="Rotweiler", Peso=38, DonosFK=8},
   new Animais  {AnimalID=10, Nome = "Saltitão", Especie ="cão", Raca="Rotweiler", Peso=36, DonosFK=1},
   new Animais  {AnimalID=11, Nome = "Amigo", Especie ="cão", Raca="Labrador", Peso=24, DonosFK=1},
   new Animais  {AnimalID=12, Nome = "Pintas", Especie ="cão", Raca="Labrador", Peso=6, DonosFK=8},
   new Animais  {AnimalID=13, Nome = "Babado", Especie ="cão", Raca="Labrador", Peso=45, DonosFK=11},
   new Animais  {AnimalID=14, Nome = "Bebé", Especie ="cão", Raca="Labrador", Peso=35, DonosFK=12},
   new Animais  {AnimalID=15, Nome = "Bernardo", Especie ="cão", Raca="São Bernardo", Peso=67, DonosFK=15},
   new Animais  {AnimalID=16, Nome = "Miau", Especie ="gato", Raca="siamês", Peso=2, DonosFK=16},
   new Animais  {AnimalID=17, Nome = "Tareco", Especie ="gato", Raca="siamês", Peso=1, DonosFK=17},
   new Animais  {AnimalID=18, Nome = "Fofo", Especie ="gato", Raca="persa", Peso=10, DonosFK=17},
   new Animais  {AnimalID=19, Nome = "Pantufa", Especie ="gato", Raca="persa", Peso=1, DonosFK=18},
   new Animais  {AnimalID=20, Nome = "Vadio", Especie ="gato", Raca="rafeiro", Peso=2, DonosFK=19},
   new Animais  {AnimalID=21, Nome = "Saltador", Especie ="Cavalo", Raca="Lusitana", Peso=780, DonosFK=20},
   new Animais  {AnimalID=22, Nome = "Crina Branca", Especie ="Cavalo", Raca="Lusitana", Peso=900, DonosFK=13},
   new Animais  {AnimalID=23, Nome = "Brincalhão", Especie ="Cavalo", Raca="Lusitana", Peso=458, DonosFK=12},
   new Animais  {AnimalID=24, Nome = "Malhada", Especie ="Vaca", Raca="Charolesa", Peso=452, DonosFK=13},
   new Animais  {AnimalID=25, Nome = "Coxa", Especie ="Vaca", Raca="Charolesa", Peso=562, DonosFK=13},
   new Animais  {AnimalID=26, Nome = "Tansa", Especie ="Vaca", Raca="Charolesa", Peso=284, DonosFK=14},
   new Animais  {AnimalID=27, Nome = "Salta Pocinha", Especie ="Cavalo", Raca="Lusitana", Peso=793, DonosFK=4}

};

            animais.ForEach(aa => context.Animais.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();


            // ############################################################################################
            // adiciona VETERINARIOS
            var veterinarios = new List<Veterinarios> {
   new Veterinarios  {VeterinarioID=1, Nome = "Maria Pinto", NumCedulaProf ="vet-34589" },
   new Veterinarios  {VeterinarioID=2, Nome = "Luís Santos", NumCedulaProf ="vet-34590" },
   new Veterinarios  {VeterinarioID=3, Nome = "João  Pinto", NumCedulaProf ="vet-56732" },
   new Veterinarios  {VeterinarioID=4, Nome = "Paula Fernandes", NumCedulaProf ="vet-64327" }
};

            veterinarios.ForEach(vv => context.Veterinarios.AddOrUpdate(v => v.Nome, vv));
            context.SaveChanges();


            // ############################################################################################
            // adiciona CONSULTAS
            var consultas = new List<Consultas> {
   new Consultas  {ConsultaID = 1, DataConsulta =  new DateTime(2015,2,8), VeterinarioFK = 1, AnimalFK = 2 },
   new Consultas  {ConsultaID = 2, DataConsulta =  new DateTime(2015,5,8), VeterinarioFK = 1, AnimalFK = 19 },
   new Consultas  {ConsultaID = 3, DataConsulta =  new DateTime(2015,6,8), VeterinarioFK = 1, AnimalFK = 13 },
   new Consultas  {ConsultaID = 4, DataConsulta =  new DateTime(2015,7,8), VeterinarioFK = 1, AnimalFK = 11 },
   new Consultas  {ConsultaID = 5, DataConsulta =  new DateTime(2015,8,8), VeterinarioFK = 1, AnimalFK = 4 },
   new Consultas  {ConsultaID = 6, DataConsulta =  new DateTime(2015,9,8), VeterinarioFK = 1, AnimalFK = 22 },
   new Consultas  {ConsultaID = 7, DataConsulta =  new DateTime(2015,10,8), VeterinarioFK = 1, AnimalFK = 22 },
   new Consultas  {ConsultaID = 8, DataConsulta =  new DateTime(2015,11,8), VeterinarioFK = 1, AnimalFK = 19 },
   new Consultas  {ConsultaID = 9, DataConsulta =  new DateTime(2015,11,8), VeterinarioFK = 1, AnimalFK = 23 },
   new Consultas  {ConsultaID = 10, DataConsulta =  new DateTime(2015,12,8), VeterinarioFK = 1, AnimalFK = 1 },
   new Consultas  {ConsultaID = 11, DataConsulta =  new DateTime(2013,3,8), VeterinarioFK = 1, AnimalFK = 21 },
   new Consultas  {ConsultaID = 12, DataConsulta =  new DateTime(2013,3,8), VeterinarioFK = 1, AnimalFK = 24 },
   new Consultas  {ConsultaID = 13, DataConsulta =  new DateTime(2013,3,8), VeterinarioFK = 1, AnimalFK = 4 },
   new Consultas  {ConsultaID = 14, DataConsulta =  new DateTime(2013,3,8), VeterinarioFK = 1, AnimalFK = 5 },
   new Consultas  {ConsultaID = 15, DataConsulta =  new DateTime(2013,3,8), VeterinarioFK = 1, AnimalFK = 5 },
   new Consultas  {ConsultaID = 16, DataConsulta =  new DateTime(2013,4,8), VeterinarioFK = 1, AnimalFK = 2 },
   new Consultas  {ConsultaID = 17, DataConsulta =  new DateTime(2013,5,8), VeterinarioFK = 1, AnimalFK = 25 },
   new Consultas  {ConsultaID = 18, DataConsulta =  new DateTime(2013,5,8), VeterinarioFK = 1, AnimalFK = 26 },
   new Consultas  {ConsultaID = 19, DataConsulta =  new DateTime(2013,5,8), VeterinarioFK = 1, AnimalFK = 25 },
   new Consultas  {ConsultaID = 20, DataConsulta =  new DateTime(2013,5,8), VeterinarioFK = 1, AnimalFK = 22 },
   new Consultas  {ConsultaID = 21, DataConsulta =  new DateTime(2013,6,8), VeterinarioFK = 1, AnimalFK = 15 },
   new Consultas  {ConsultaID = 22, DataConsulta =  new DateTime(2013,6,8), VeterinarioFK = 1, AnimalFK = 23 },
   new Consultas  {ConsultaID = 23, DataConsulta =  new DateTime(2013,6,8), VeterinarioFK = 1, AnimalFK = 13 },
   new Consultas  {ConsultaID = 24, DataConsulta =  new DateTime(2013,7,8), VeterinarioFK = 1, AnimalFK = 23 },
   new Consultas  {ConsultaID = 25, DataConsulta =  new DateTime(2013,7,8), VeterinarioFK = 2, AnimalFK = 27 },
   new Consultas  {ConsultaID = 26, DataConsulta =  new DateTime(2013,7,8), VeterinarioFK = 2, AnimalFK = 11 },
   new Consultas  {ConsultaID = 27, DataConsulta =  new DateTime(2013,8,8), VeterinarioFK = 2, AnimalFK = 9 },
   new Consultas  {ConsultaID = 28, DataConsulta =  new DateTime(2013,9,8), VeterinarioFK = 2, AnimalFK = 9 },
   new Consultas  {ConsultaID = 29, DataConsulta =  new DateTime(2013,9,8), VeterinarioFK = 2, AnimalFK = 15 },
   new Consultas  {ConsultaID = 30, DataConsulta =  new DateTime(2013,10,8), VeterinarioFK = 1, AnimalFK = 17 },
   new Consultas  {ConsultaID = 31, DataConsulta =  new DateTime(2013,11,8), VeterinarioFK = 1, AnimalFK = 2 },
   new Consultas  {ConsultaID = 32, DataConsulta =  new DateTime(2014,2,8), VeterinarioFK = 2, AnimalFK = 9 },
   new Consultas  {ConsultaID = 33, DataConsulta =  new DateTime(2014,2,8), VeterinarioFK = 2, AnimalFK = 9 },
   new Consultas  {ConsultaID = 34, DataConsulta =  new DateTime(2014,3,8), VeterinarioFK = 1, AnimalFK = 14 },
   new Consultas  {ConsultaID = 35, DataConsulta =  new DateTime(2014,5,8), VeterinarioFK = 2, AnimalFK = 6 },
   new Consultas  {ConsultaID = 36, DataConsulta =  new DateTime(2014,5,8), VeterinarioFK = 1, AnimalFK = 15 },
   new Consultas  {ConsultaID = 37, DataConsulta =  new DateTime(2014,7,8), VeterinarioFK = 1, AnimalFK = 5 },
   new Consultas  {ConsultaID = 38, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 2, AnimalFK = 21 },
   new Consultas  {ConsultaID = 39, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 2, AnimalFK = 21 },
   new Consultas  {ConsultaID = 40, DataConsulta =  new DateTime(2014,9,8), VeterinarioFK = 2, AnimalFK = 25 },
   new Consultas  {ConsultaID = 41, DataConsulta =  new DateTime(2014,9,8), VeterinarioFK = 1, AnimalFK = 7 },
   new Consultas  {ConsultaID = 42, DataConsulta =  new DateTime(2014,10,8), VeterinarioFK = 1, AnimalFK = 24 },
   new Consultas  {ConsultaID = 43, DataConsulta =  new DateTime(2014,10,8), VeterinarioFK = 1, AnimalFK = 2 },
   new Consultas  {ConsultaID = 44, DataConsulta =  new DateTime(2014,11,8), VeterinarioFK = 2, AnimalFK = 12 },
   new Consultas  {ConsultaID = 45, DataConsulta =  new DateTime(2014,1,8), VeterinarioFK = 2, AnimalFK = 8 },
   new Consultas  {ConsultaID = 46, DataConsulta =  new DateTime(2014,3,8), VeterinarioFK = 2, AnimalFK = 13 },
   new Consultas  {ConsultaID = 47, DataConsulta =  new DateTime(2014,4,8), VeterinarioFK = 1, AnimalFK = 13 },
   new Consultas  {ConsultaID = 48, DataConsulta =  new DateTime(2014,4,8), VeterinarioFK = 2, AnimalFK = 22 },
   new Consultas  {ConsultaID = 49, DataConsulta =  new DateTime(2014,5,8), VeterinarioFK = 1, AnimalFK = 19 },
   new Consultas  {ConsultaID = 50, DataConsulta =  new DateTime(2014,7,8), VeterinarioFK = 1, AnimalFK = 16 },
   new Consultas  {ConsultaID = 51, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 3, AnimalFK = 1 },
   new Consultas  {ConsultaID = 52, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 3, AnimalFK = 12 },
   new Consultas  {ConsultaID = 53, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 2, AnimalFK = 12 },
   new Consultas  {ConsultaID = 54, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 1, AnimalFK = 6 },
   new Consultas  {ConsultaID = 55, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 1, AnimalFK = 26 },
   new Consultas  {ConsultaID = 56, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 2, AnimalFK = 24 },
   new Consultas  {ConsultaID = 57, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 2, AnimalFK = 12 },
   new Consultas  {ConsultaID = 58, DataConsulta =  new DateTime(2014,8,8), VeterinarioFK = 3, AnimalFK = 22 },
   new Consultas  {ConsultaID = 59, DataConsulta =  new DateTime(2014,9,8), VeterinarioFK = 3, AnimalFK = 10 },
   new Consultas  {ConsultaID = 60, DataConsulta =  new DateTime(2014,9,8), VeterinarioFK = 3, AnimalFK = 15 },
   new Consultas  {ConsultaID = 61, DataConsulta =  new DateTime(2014,10,8), VeterinarioFK = 1, AnimalFK = 6 },
   new Consultas  {ConsultaID = 62, DataConsulta =  new DateTime(2014,10,8), VeterinarioFK = 2, AnimalFK = 26 },
   new Consultas  {ConsultaID = 63, DataConsulta =  new DateTime(2014,11,8), VeterinarioFK = 3, AnimalFK = 16 },
   new Consultas  {ConsultaID = 64, DataConsulta =  new DateTime(2014,11,8), VeterinarioFK = 3, AnimalFK = 2 },
   new Consultas  {ConsultaID = 65, DataConsulta =  new DateTime(2015,1,8), VeterinarioFK = 3, AnimalFK = 26 },
   new Consultas  {ConsultaID = 66, DataConsulta =  new DateTime(2015,2,8), VeterinarioFK = 1, AnimalFK = 24 },
   new Consultas  {ConsultaID = 67, DataConsulta =  new DateTime(2015,2,8), VeterinarioFK = 1, AnimalFK = 21 },
   new Consultas  {ConsultaID = 68, DataConsulta =  new DateTime(2015,2,8), VeterinarioFK = 2, AnimalFK = 6 },
   new Consultas  {ConsultaID = 69, DataConsulta =  new DateTime(2015,3,8), VeterinarioFK = 2, AnimalFK = 14 },
   new Consultas  {ConsultaID = 70, DataConsulta =  new DateTime(2015,3,8), VeterinarioFK = 2, AnimalFK = 19 },
   new Consultas  {ConsultaID = 71, DataConsulta =  new DateTime(2015,4,8), VeterinarioFK = 1, AnimalFK = 14 },
   new Consultas  {ConsultaID = 72, DataConsulta =  new DateTime(2015,4,8), VeterinarioFK = 2, AnimalFK = 22 },
   new Consultas  {ConsultaID = 73, DataConsulta =  new DateTime(2015,5,8), VeterinarioFK = 2, AnimalFK = 24 },
   new Consultas  {ConsultaID = 74, DataConsulta =  new DateTime(2015,5,8), VeterinarioFK = 3, AnimalFK = 6 },
   new Consultas  {ConsultaID = 75, DataConsulta =  new DateTime(2015,6,8), VeterinarioFK = 3, AnimalFK = 26 },
   new Consultas  {ConsultaID = 76, DataConsulta =  new DateTime(2015,6,8), VeterinarioFK = 3, AnimalFK = 12 },
   new Consultas  {ConsultaID = 77, DataConsulta =  new DateTime(2015,7,8), VeterinarioFK = 3, AnimalFK = 4 },
   new Consultas  {ConsultaID = 78, DataConsulta =  new DateTime(2015,9,8), VeterinarioFK = 4, AnimalFK = 25 },
   new Consultas  {ConsultaID = 79, DataConsulta =  new DateTime(2015,9,8), VeterinarioFK = 4, AnimalFK = 27 },
   new Consultas  {ConsultaID = 80, DataConsulta =  new DateTime(2015,9,8), VeterinarioFK = 4, AnimalFK = 16 },
   new Consultas  {ConsultaID = 81, DataConsulta =  new DateTime(2015,9,8), VeterinarioFK = 4, AnimalFK = 2 },
   new Consultas  {ConsultaID = 82, DataConsulta =  new DateTime(2015,10,8), VeterinarioFK = 4, AnimalFK = 19 },
   new Consultas  {ConsultaID = 83, DataConsulta =  new DateTime(2015,12,8), VeterinarioFK = 3, AnimalFK = 16 },
   new Consultas  {ConsultaID = 84, DataConsulta =  new DateTime(2015,12,8), VeterinarioFK = 4, AnimalFK = 16 },
   new Consultas  {ConsultaID = 85, DataConsulta =  new DateTime(2015,12,8), VeterinarioFK = 4, AnimalFK = 7 },
   new Consultas  {ConsultaID = 86, DataConsulta =  new DateTime(2015,12,8), VeterinarioFK = 2, AnimalFK = 16 },
   new Consultas  {ConsultaID = 87, DataConsulta =  new DateTime(2015,12,8), VeterinarioFK = 3, AnimalFK = 2 },
   new Consultas  {ConsultaID = 88, DataConsulta =  new DateTime(2015,12,8), VeterinarioFK = 4, AnimalFK = 27 },
   new Consultas  {ConsultaID = 89, DataConsulta =  new DateTime(2016,4,8), VeterinarioFK = 4, AnimalFK = 17 },
   new Consultas  {ConsultaID = 90, DataConsulta =  new DateTime(2016,5,8), VeterinarioFK = 4, AnimalFK = 22 },
   new Consultas  {ConsultaID = 91, DataConsulta =  new DateTime(2016,6,8), VeterinarioFK = 4, AnimalFK = 21 },
   new Consultas  {ConsultaID = 92, DataConsulta =  new DateTime(2016,7,8), VeterinarioFK = 2, AnimalFK = 24 },
   new Consultas  {ConsultaID = 93, DataConsulta =  new DateTime(2016,8,8), VeterinarioFK = 3, AnimalFK = 4 },
   new Consultas  {ConsultaID = 94, DataConsulta =  new DateTime(2016,8,8), VeterinarioFK = 3, AnimalFK = 7 },
   new Consultas  {ConsultaID = 95, DataConsulta =  new DateTime(2016,9,8), VeterinarioFK = 2, AnimalFK = 11 },
   new Consultas  {ConsultaID = 96, DataConsulta =  new DateTime(2016,9,8), VeterinarioFK = 2, AnimalFK = 26 },
   new Consultas  {ConsultaID = 97, DataConsulta =  new DateTime(2016,10,8), VeterinarioFK = 2, AnimalFK = 27 },
   new Consultas  {ConsultaID = 98, DataConsulta =  new DateTime(2016,10,8), VeterinarioFK = 1, AnimalFK = 14 },
   new Consultas  {ConsultaID = 99, DataConsulta =  new DateTime(2016,10,8), VeterinarioFK = 4, AnimalFK = 19 },
   new Consultas  {ConsultaID = 100, DataConsulta =  new DateTime(2016,10,8), VeterinarioFK = 4, AnimalFK = 11 }
};

            consultas.ForEach(cc => context.Consultas.Add(cc));
            context.SaveChanges();







        }
    }
}
