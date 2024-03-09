using UserService.Api;
using UserService.Application;
using UserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Logging.ClearProviders();   
    builder.Logging.AddConsole();
    
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration.GetConnectionString("UserServiceDb"));
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.UseHttpsRedirection();
}

app.Run();