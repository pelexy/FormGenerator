using FormBuilder.Extensions;
using FormBuilder.Modules;
using FormBuilder.Modules.Core;
using FormBuilder.Modules.Core.Implementations;
using FormBuilder.Modules.Core.Interfaces;
using FormBuilder.Modules.Core.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Form;
using Modules.Form.Models;

public class Core : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection builder, IConfiguration configuration)
    {
        // Register CosmosClient as a singleton
        builder.AddSingleton((provider) =>
        {
            var endpointUri = configuration["CosmosDbSettings:EndpointUri"];
            var primaryKey = configuration["CosmosDbSettings:PrimaryKey"];
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];

            var cosmosClientOptions = new CosmosClientOptions
            {
                ApplicationName = databaseName,
                ConnectionMode = ConnectionMode.Direct,
            };

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
            return cosmosClient;
        });

        // Register the generic repository with necessary parameters
        builder.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.AddScoped<IGenericRepository<Programme>>(provider =>
        {
            var config = provider.GetRequiredService<IConfiguration>();
            var connectionString = config.GetConnectionString("CosmosDbConnectionString");
            var databaseName = config.GetValue<string>("CosmosDbSettings:DatabaseName"); // Access database name from config
            var cosmosClient = provider.GetRequiredService<CosmosClient>(); // Get CosmosClient instance
            return new GenericRepository<Programme>(cosmosClient, databaseName);
        });

        builder.Configure<AppConstants>(configuration.GetSection("AppConstants"));
        builder.Configure<AppSecrets>(configuration.GetSection("AppSecrets"));
        builder.AddHttpClient<IHttpDataClient, HttpDataClient>();

        var appConstantSection = configuration.GetSection("AppConstants");
        var appSecretSection = configuration.GetSection("AppSecrets");
        var appConstant = appConstantSection.Get<AppConstants>();
        var appSecret = appSecretSection.Get<AppSecrets>();

        builder.AddSingleton(provider => new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile(appConstant));
            cfg.AddProfile(new FormMappingProfile(appConstant));
        }).CreateMapper());

        builder.AddEndpointsApiExplorer();
        builder.AddSwaggerGen(opts => opts.EnableAnnotations());
        builder.AddCustomSwaggerGen();

        return builder;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }
}
