using FormBuilder.Modules;
using Modules.FormApplication.Endpoints;

namespace Modules.FormApplication
{
    public class FormApplication : IModule
    {

        public IServiceCollection RegisterModule(IServiceCollection builder, IConfiguration configuration)
        {
            //Incase i need to override my IGeneric I can do it here 
            return builder;
        }
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGroup("/Application").WithTags("Form Application").FormApplicationGet();
            endpoints.MapGroup("/Application").WithTags("Form Application").FormApplicationPost();
            return endpoints;
        }
    }
}