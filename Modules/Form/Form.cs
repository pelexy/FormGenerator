using FormBuilder.Modules;
using Modules.Form.Endpoints;

namespace Modules.Form
{
    public class Form : IModule
    {



        public IServiceCollection RegisterModule(IServiceCollection builder, IConfiguration configuration)
        {
            //Incase i need to override my IGeneric I can do it here 
            return builder;
        }
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGroup("/Programme").WithTags("Form").FormGet();
            endpoints.MapGroup("/Programme").WithTags("Form").FormPost();
            return endpoints;
        }


    }
}

