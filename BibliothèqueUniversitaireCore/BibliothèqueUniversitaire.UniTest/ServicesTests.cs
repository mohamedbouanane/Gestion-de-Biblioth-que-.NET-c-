
using Microsoft.EntityFrameworkCore;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;
using BibliothèqueUniversitaire.App.Services;
using BibliothèqueUniversitaire.Infra.Data.Context;
using BibliothèqueUniversitaire.App.Services.Impl;
using BibliothèqueUniversitaire.Infra.Data.Repositories.Impl;
using BibliothèqueUniversitaire.Infra.Domain.Models;

namespace BibliothèqueUniversitaire.NUniTest
{
    public class ServicesTests
    {
        DbContext context;

        IAdherentService adherentService;
        IAuteurService auteurService;
        IEmpruntService empruntService;
        ILivreService livreService;

        [SetUp]
        public void Setup()
        {
            context = new ModelContext();

            adherentService = new AdherentService(new AdherentRepository(context));
            auteurService = new AuteurService(new AuteurRepository(context));
            empruntService = new EmpruntService(new EmpruntRepository(context));
            livreService = new LivreService(new LivreRepository(context));
        }

        /*
        public async Task Test1Async()
        {
            using (var context = new ModelContext())
            {
                adherentService = new AdherentService(new AdherentRepository(context));
                auteurService = new AuteurService(new AuteurRepository(context));
                empruntService = new EmpruntService(new EmpruntRepository(context));
                livreService = new LivreService(new LivreRepository(context));

                // Transférer plusieurs requêtes dans une seule transaction
                await context.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
                {
                    using (var transaction = context.Database.BeginTransactionAsync())
                        try
                        {
                            await InsertDemoLivreDataAsyncTest();
                            await InsertDemoAdherentDataAsyncTest();
                            await InsertDemoEmpruntDataAsyncTest();

                            MessageBox.Show("Insertion donne");

                            await context.SaveChangesAsync();
                            await transaction.Result.CommitAsync();
                        }
                        catch (Exception ex)
                        {
                            await transaction.Result.RollbackAsync();
                            MessageBox.Show(ex.ToString());
                        }
                });
            }
        }*/

        [Test]
        public async Task InsertFakeDataLivreAsyncTest()
        {
            for (int i = 0; i < 30; i++)
                await livreService.SaveAsync(
               new LivreEntity(Faker.Currency.Name(), (uint)Faker.RandomNumber.Next(), (uint)Faker.RandomNumber.Next(),
               new List<AuteurEntity>() {
                new AuteurEntity(new PersoneEntity(Faker.Name.First(), Faker.Name.Last(), Faker.Address.StreetAddress()))
               },
               new MaisonEditionEntity(Faker.Name.First() + " " + Faker.Name.Last(),
               new ProvenanceEntity(Faker.Company.Name(), Faker.Address.StreetAddress())),
               new ProvenanceEntity(Faker.Company.Name(), Faker.Address.StreetAddress()))
               );
            await context.SaveChangesAsync();
        }

        [Test]
        public async Task InsertFakeDataAdherentAsyncTest()
        {
            for (int i = 0; i < 30; i++)
                await adherentService.SaveAsync(
                    new AdherentEntity(new PersoneEntity(Faker.Name.First(), Faker.Name.Last(), Faker.Address.StreetAddress()))
               );
            await context.SaveChangesAsync();
        }

        [Test]
        public async Task InsertFakeDataEmpruntAsyncTest()
        {
            for (int i = 0; i < 5; i++)
                await empruntService.SaveAsync(
                    new EmpruntEntity(RandomizerFactory.GetRandomizer(new FieldOptionsDateTime()).Generate().Value,
                    RandomizerFactory.GetRandomizer(new FieldOptionsDateTime()).Generate().Value,
                    await livreService.GetByIdAsync(1),
                    await adherentService.GetByIdAsync(2)
                    )
               );
            await context.SaveChangesAsync();
        }

        [Test]
        public void DeleteTest()
        {
            //livreService.DeleteAsync();
        }

    }
}
