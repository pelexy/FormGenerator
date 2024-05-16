using Hangfire;
using System.Reflection;
using Ripple.API.Extensions;
using Ripple.API.Modules.Core.Endpoints;
using Ripple.API.Modules.Core.Extensions;
using Ripple.API.Modules.Core.Implementations;
using Ripple.API.Modules.Core.Interfaces;
using Ripple.API.Modules.Core.Models;
using Ripple.API.Modules.Identity;
using Hangfire.PostgreSql;
using Ripple.API.Modules.Finance;
using Ripple.API.Modules.Monnify;

using Ripple.API.Modules.Notification;
using Modules.Property;
using Ripple.API.Modules.Paystack;

namespace Ripple.API.Modules.Core
{
    public class Core : IModule
    {


        public IServiceCollection RegisterModule(IServiceCollection builder, IConfiguration configuration)
        {

            //builder.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.AddCoreInfrastructure(configuration);
            builder.Configure<AppConstants>(configuration.GetSection("AppConstants"));
            builder.Configure<AppSecrets>(configuration.GetSection("AppSecrets"));
            builder.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.AddHttpClient<IHttpDataClient, HttpDataClient>();
            var appConstantSection = configuration.GetSection("AppConstants");
            var appSecretSection = configuration.GetSection("AppSecrets");
            var appConstant = appConstantSection.Get<AppConstants>();
            var appSecret = appSecretSection.Get<AppSecrets>();
            builder.AddSingleton(
                provider => new AutoMapper.MapperConfiguration(
                    cfg =>
                    {
                        cfg.AddProfile(new MappingProfile(appConstant!));
                        cfg.AddProfile(new WalletMappingProfile(appConstant!));
                        cfg.AddProfile(new IdentityMappingProfile(appConstant!));
                        cfg.AddProfile(new PropertyMappingProfile());
                        cfg.AddProfile(new MonnifyMappingProfile(appConstant!));


                        cfg.AddProfile(new NotificationProfileMapping(appConstant!));

                    }
                    ).CreateMapper()
                );
            builder.AddJWT(configuration);
            builder.AddPaystackApi(configuration);
            builder.AddEndpointsApiExplorer();
            builder.AddSwaggerGen(opts => opts.EnableAnnotations());
            builder.AddCustomSwaggerGen();
            var HangfireConnection = configuration.GetConnectionString("HangfireConnection");
            builder.AddHangfire(x =>
            {

                x.UseSqlServerStorage(HangfireConnection);
                x.UseFilter(new AutomaticRetryAttribute { Attempts = 2 });


            });
            builder.AddHangfireServer();
            return builder;
        }
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            return endpoints;
        }


    }
}
