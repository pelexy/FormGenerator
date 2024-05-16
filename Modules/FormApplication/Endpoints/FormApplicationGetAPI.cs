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
    public static class FormApplicationGetAPI
    {
        public static IEndpointRouteBuilder FormApplicationGet(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/", async (IGenericRepository<Application> applicationRepository, IMapper mapper) =>
      {
          try
          {
              var data = await applicationRepository.GetAllAsync();
              var programs = mapper.Map<List<ReadApplicationDto>>(data);
              return Results.Ok(programs);
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

          .WithMetadata(new SwaggerOperationAttribute(summary: "Get all submited forms", description: ""));

            endpoints.MapGet("/{userid}/{id}", async ([FromRoute] string id, [FromRoute] string userid, IGenericRepository<Application> applicationRepository, IMapper mapper) =>
      {
          try
          {
              var data = await applicationRepository.GetSingleAsync(id, userid);
              var programs = mapper.Map<ReadApplicationDto>(data);
              return Results.Ok(programs);
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

          .WithMetadata(new SwaggerOperationAttribute(summary: "Get single submited form", description: ""));


            return endpoints;
        }



    }

}