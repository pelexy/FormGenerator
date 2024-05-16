using AutoMapper;
using FormBuilder.Modules.Core;
using FormBuilder.Modules.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modules.Form.Dto;
using Modules.Form.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Modules.Form.Endpoints
{
    public static class FormGetAPI
    {
        public static IEndpointRouteBuilder FormGet(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/", async (IGenericRepository<Programme> programRepository, IMapper mapper) =>
      {
          try
          {
              var data = await programRepository.GetAllAsync();
              var programs = mapper.Map<List<ReadProgrammeDto>>(data);
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

          .WithMetadata(new SwaggerOperationAttribute(summary: "Get all Programme form on the system", description: ""));

            endpoints.MapGet("/{tenantid}/{id}", async ([FromRoute] string id, [FromRoute] string tenantid, IGenericRepository<Programme> programRepository, IMapper mapper) =>
      {
          try
          {
              var data = await programRepository.GetSingleAsync(id, tenantid);
              var programs = mapper.Map<ReadProgrammeDto>(data);
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

          .WithMetadata(new SwaggerOperationAttribute(summary: "Get single form", description: ""));


            return endpoints;
        }



    }

}