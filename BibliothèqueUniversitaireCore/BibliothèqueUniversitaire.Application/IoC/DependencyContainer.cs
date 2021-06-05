
//using Autofac;
using BibliothèqueUniversitaire.App.Services;
using BibliothèqueUniversitaire.App.Services.Impl;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace BibliothèqueUniversitaire.Infra.Data.Context.IoC
{
    // To configur later 

    public class DependencyContainer
    {
        /*
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<IAdherentService>().As<AdherentService>();
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(BibliothèqueUniversitaire)))
                .Where(t => t.Namespace.Contains("Services"))
                .As(t => t.GetInterfaces().FirstOrDefault(i=>i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(BibliothèqueUniversitaire)))
                .Where(t => t.Namespace.Contains("Repositories"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
        */
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
