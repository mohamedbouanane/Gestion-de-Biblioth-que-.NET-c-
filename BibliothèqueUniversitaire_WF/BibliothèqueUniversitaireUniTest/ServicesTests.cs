using BibliothèqueUniversitaire.Models;
using BibliothèqueUniversitaire.Services;
using BibliothèqueUniversitaire.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using BibliothèqueUniversitaire.Services;

namespace BibliothèqueUniversitaireUniTest
{
    [TestClass]
    public class ServicesTests
    {
        ILivreService livreService;
        IEmpruntService empruntService;
        IAdherentService adherentService;

        [TestInitialize]
        public void InitTest()
        {
            livreService = new LivreService(new BibliothèqueUniversitaire.Context.ModelContext());
            empruntService = new EmpruntService(new BibliothèqueUniversitaire.Context.ModelContext());
            adherentService = new AdherentService(new BibliothèqueUniversitaire.Context.ModelContext());
        }


        [TestMethod]
        public void TestInsertions()
        {
            livreService = new LivreService(new BibliothèqueUniversitaire.Context.ModelContext());
            livreService.SaveOrUpdateAsync(new LivreEntity(
               "Lite Code", 365, 343.45D, new List<AuteurEntity>() {
new AuteurEntity(new PersoneEntity("BOUANANE","Mohamed","Fès")) },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue Allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane")
               ));
        }

    }
}
