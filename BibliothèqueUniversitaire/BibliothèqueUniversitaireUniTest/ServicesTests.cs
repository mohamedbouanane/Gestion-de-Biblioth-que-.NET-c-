using BibliothèqueUniversitaire.Models;
using BibliothèqueUniversitaire.Services;
using BibliothèqueUniversitaire.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BibliothèqueUniversitaireUniTest
{
    [TestClass]
    public class ServicesTests
    {
        ILivreService livreService;

        [TestInitialize]
        public void InitTest()
        {
            livreService = new LivreService(new BibliothèqueUniversitaire.Context.AppDbContext());
        }


        [TestMethod]
        public void TestInsertions()
        {
            Console.WriteLine("\n\nStart test services\n\n");
            livreService.Save(new LivreEntity(
               "Lite Code", 365, 343.45D, new List<AuteurEntity>() { new AuteurEntity() },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane")
               ));
            Console.WriteLine("\n\nInit du services\n\n");
        }
    }
}
