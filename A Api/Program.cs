using B_Domain.Service;
using B_Domain.Service.Interface;
using C_Data.Context;
using C_Data.Persistence;
using C_Data.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using PeruTripBackend.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencie Injection
builder.Services.AddScoped<IRolDomain, RolDomain>();
builder.Services.AddScoped<IRolData, RolData>();

builder.Services.AddScoped<IUsuarioDomain, UsuarioDomain>();
builder.Services.AddScoped<IUsuarioData, UsuarioData>();

//Cors -> Connection to front
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Connection to MySql
var connectionString = builder.Configuration.GetConnectionString("Conection");

builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });
builder.Services.AddAutoMapper(
    typeof(ModelToResource),
    typeof(ResourceToModel)
);


var app = builder.Build();


using (var scoope = app.Services.CreateScope())
using (var context = scoope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(builder =>
{
    builder.Use(async (context, next) =>
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        await next();
    });
});


app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();