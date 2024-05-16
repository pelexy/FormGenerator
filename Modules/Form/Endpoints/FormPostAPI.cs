using AutoMapper;
using FormBuilder.Modules.Core;
using FormBuilder.Modules.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modules.Form.Dto;
using Modules.Form.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Modules.Form.Endpoints
{
    public static class FormPostAPI
    {
        public static IEndpointRouteBuilder FormPost(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/", async ([FromBody] ProgrammeDto dto, IGenericRepository<Programme> programRepository, IMapper mapper) =>
      {
          try
          {
              var program = mapper.Map<Programme>(dto);
              await programRepository.AddAsync(program);
              return Results.Ok(new { Message = "Form Created", IsSuccess = true });
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

          .WithMetadata(new SwaggerOperationAttribute(summary: "Create A New Program Form ", description: ""));



            endpoints.MapPut("/{tenantid}", async ([FromRoute] string tenantid, [FromBody] UpdateProgrammeDto dto, IGenericRepository<Programme> programRepository, IMapper mapper) =>
 {
     try
     {
         var program = mapper.Map<Programme>(dto);
         await programRepository.UpdateAsync(tenantid, program);
         return Results.Ok(new { Message = "Form Updated", IsSuccess = true });
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

     .WithMetadata(new SwaggerOperationAttribute(summary: "Update A Form ", description: ""));

            endpoints.MapDelete("/{tenantid}/{id}", async ([FromRoute] string id, [FromRoute] string tenantid, [FromBody] ProgrammeDto dto, IGenericRepository<Programme> programRepository, IMapper mapper) =>
{
    try
    {
        var program = mapper.Map<Programme>(dto);
        await programRepository.DeleteAsync(id, tenantid);
        return Results.Ok(new { Message = "Form Deleted", IsSuccess = true });
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

.WithMetadata(new SwaggerOperationAttribute(summary: "Update A Form ", description: ""));


            return endpoints;
        }



    }

}