using AutoServiceAPI.Extensions;
internal class Program
{
    private static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureCors();
        builder.Services.ConfigureSqlContext(builder.Configuration);
        builder.Services.ConfigureRepositoryWrapper();
        builder.Services.ConfigureServices();
        //builder.Services.ConfigureJsonSerialization();

        var app = builder.Build();

        app.UseCors("AllowSpecificOrigin");
        app.UseSwagger();
        app.UseSwaggerUI();
        app.ConfigureApi();
        

        app.Run();
        
        
    }   

}