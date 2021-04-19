using Aornis;
using BibliothèqueUniversitaire.Data.Repositories;
using BibliothèqueUniversitaire.Data.Repositories.Impl;
using BibliothèqueUniversitaire.Ifrostructure.Context;
using BibliothèqueUniversitaire.Ifrostructure.IoC;
using BibliothèqueUniversitaire.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliothèqueUniversitaire
{
    static class Program
    {
        /*
         * Architecture Project inspired from:
         * https://nishanc.medium.com/clean-architecture-net-core-part-2-implementation-7376896390c5
         * https://blogs.infinitesquare.com/posts/web/creer-son-api-dotnet-core-3-0-avec-une-architecture-clean
         */

        static ILivreRepository livreService;
        static IEmpruntRepository empruntService;
        static IAdherentRepository adherentService;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            livreService = new LivreRepository(new ModelContext());
            empruntService = new EmpruntRepository(new ModelContext());
            adherentService = new AdherentRepository(new ModelContext());

            //TestInsertionsLivres();
            //TestSupressionDetoutLesLivres();
            //TestGetByIdLivres();
            //TestSelectionLivres();
            TestUpdateLivres();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // IoC
        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }


        #region CRUD Test

        static void TestInsertionsLivres()
        {
            livreService.SaveOrUpdateAsync(
                new LivreEntity("Lite Code", 365, 343.45D, new List<AuteurEntity>() {
                new AuteurEntity(new PersoneEntity("BOUANANE","Mohamed","Fès")) },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue Allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane")),

                new LivreEntity("Lite Code", 365, 343.45D, new List<AuteurEntity>() {
                new AuteurEntity(new PersoneEntity("BOUANANE","Mohamed","Fès")) },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue Allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane")),

                new LivreEntity("Lite Code", 365, 343.45D, new List<AuteurEntity>() {
                new AuteurEntity(new PersoneEntity("BOUANANE","Mohamed","Fès")) },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue Allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane")),

                new LivreEntity("Lite Code", 365, 343.45D, new List<AuteurEntity>() {
                new AuteurEntity(new PersoneEntity("BOUANANE","Mohamed","Fès")) },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue Allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane")),

                new LivreEntity("Lite Code", 365, 343.45D, new List<AuteurEntity>() {
                new AuteurEntity(new PersoneEntity("BOUANANE","Mohamed","Fès")) },
               new MaisonEditionEntity(new ProvenanceEntity("Maison X", "Rue Allah")),
               new ProvenanceEntity("Maison y", "Rue Rarmane"))
                );
        }

        static void TestSupressionDetoutLesLivres()
        {
            livreService.GetAll().IfPresent(o => livreService.DeleteAsync(o.ToArray()));
            
        }

        static void TestGetByIdLivresAsync()
        {
            //livreService.GetByIdAsync(1).IfPresentAsync(o => MessageBox.Show(o.Titre));  
        }

        static void TestSelectionLivres()
        {
            //MessageBox.Show(livreService.GetAll().ToList()[1].Titre) ;
        }

        static void TestUpdateLivres()
        {
            //LivreEntity livre = await livreService.GetByIdAsync(2);
            //livre.Titre = "Aaaa";
            //await livreService.SaveOrUpdateAsync(livre);
        }

        #endregion CRUD Test


    }
}
