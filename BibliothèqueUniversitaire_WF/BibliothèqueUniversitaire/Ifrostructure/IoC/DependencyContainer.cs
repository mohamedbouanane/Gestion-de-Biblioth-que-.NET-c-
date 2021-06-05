
using BibliothèqueUniversitaire.App.Services;
using BibliothèqueUniversitaire.App.Services.Impl;
using BibliothèqueUniversitaire.Data.Repositories;
using BibliothèqueUniversitaire.Data.Repositories.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BibliothèqueUniversitaire.Ifrostructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            /*
            //Services
            services.AddScoped<IAdherentService, AdherentService>();
            services.AddScoped<IAuteurService, AuteurService>();
            services.AddScoped<IEmpruntService, EmpruntService>();
            services.AddScoped<ILivreService, LivreService>();
            
            //Repositories
            services.AddScoped<IAdherentRepository, AdherentRepository>();
            services.AddScoped<IAuteurRepository, AuteurRepository>();
            services.AddScoped<IEmpruntRepository, EmpruntRepository>();
            services.AddScoped<ILivreRepository, LivreRepository>();*/

        }
    }
}
