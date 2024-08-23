using EshopApi.Application.Services;
using EshopApi.Infrastructure.Data.DbContexts;
using EshopApi.Infrastructure.Extensions;
using EshopApi.Presentation.Extensions;
using EshopApi.Presentation.Middlewares;

//var builder = WebApplication.CreateSlimBuilder(args);
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddInfrastructure(builder.Configuration);

// Register Application Services
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IAccountService, AccountService>();

builder.Services.AddControllers();

builder.Services.AddSwagger();

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EshopDbContext>();
    // Create the database if it does not exist
    await dbContext.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapWhen(
    httpContext => httpContext.Request.Path.Equals("/api/auth/login")
        || httpContext.Request.Path.StartsWithSegments("/swagger")
        || httpContext.Request.Path.Equals("/api/seed"),
    subApp => subApp
        .UseRouting()
        .UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        })
        .UseSwagger()
        .UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Eshop API V1");
            options.SwaggerEndpoint("/swagger/v2/swagger.json", "Eshop API V2");
        })
);

app.UseMiddleware<JwtAuthMiddleware>();
app.UseMiddleware<SessionMiddleware>();
app.MapControllers();

//app.UseSwagger();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Eshop API V1");
//    options.SwaggerEndpoint("/swagger/v2/swagger.json", "Eshop API V2");
//});

app.Run();
