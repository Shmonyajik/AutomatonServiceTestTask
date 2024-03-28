using Contracts.Services;
using Domain.Enums;
using Domain.Models;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace AutoServiceAPI.Extensions
{
    public static class APIConfigureExtension
    {
        public static void ConfigureApi(this WebApplication app)
        {

            app.MapGet("/stores/{id:int}", async ([FromServices] IStoreService _service, int id) =>
            {
                var response = await _service.GetStoreByKeeperAsync(id);
                if(response.StatusCode != StatusCode.OK)
                {
                    return Results.BadRequest(response);
                }
                return Results.Ok(response);
                
            })
                .Produces<BaseResponse<Store>>(StatusCodes.Status200OK)
                .Produces<BaseResponse<Store>>(StatusCodes.Status400BadRequest)
                .WithName("GetStoreByKeeper")
                .WithTags("Getters");


            app.MapPatch("/products", async ([FromServices] IProductService _service, [FromBody] IEnumerable<StoreProducts> products) =>
            {
                var response = await _service.EditProductsAsync(products);
                if (response.StatusCode != StatusCode.OK)
                {
                    return Results.BadRequest(response);
                }
                return Results.Ok(response);
            })
                .Accepts<StoreProducts>("application/json")
                .Produces<BaseResponse<IEnumerable<int>>>(StatusCodes.Status200OK)
                .Produces<BaseResponse<IEnumerable<int>>>(StatusCodes.Status400BadRequest)
                .WithName("EditProducts")
                .WithTags("Updates");

            app.MapPatch("/product", async ([FromServices] IProductService _service, [FromBody] StoreProducts product) =>
            {
                var response = await _service.EditProductAsync(product);
                if (response.StatusCode != StatusCode.OK)
                {
                    return Results.BadRequest(response);
                }
                return Results.Ok(response);
            })
                .Accepts<StoreProducts>("application/json")
                .Produces<BaseResponse<int>>(StatusCodes.Status200OK)
                .Produces<BaseResponse<int>>(StatusCodes.Status400BadRequest)
                .WithName("EditProduct")
                .WithTags("Updates");
        }

       
    }
}
