using AutoMapper;
using FormBuilder.Modules.Core;
using FormBuilder.Modules.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modules.Form.Dto;
using Modules.Form.Models;
using Modules.FormApplication.Dtos;
using Modules.FormApplication.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Modules.FormApplication.Endpoints
{
    public static class FormApplicationPostAPI
    {
        public static IEndpointRouteBuilder FormApplicationPost(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/", async ([FromBody] ApplicationDto dto, IGenericRepository<Application> applicationRepository, IMapper mapper) =>
      {
          try
          {
              var application = mapper.Map<Application>(dto);
              await applicationRepository.AddAsync(application);
              return Results.Ok(new { Message = "Answers  Submited", IsSuccess = true });
          }
          catch (AppException ex)
          {
              return Results.BadRequest(new { ex.Message, IsSuccess = false });
          }
          catch (Exception ex)
          {
              return Results.BadRequest(new { Message = "Error processing request.", IsSuccess = false });
          }
      })

          .WithMetadata(new SwaggerOperationAttribute(summary: "Applicant Can Submit form created", description: ""));





            return endpoints;
        }



    }

}