using Business.TService;
using DataAccess;
using DataAccess.Repo.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
});

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>)); // Düzenlenicek
builder.Services.AddScoped(typeof(Service<>));


builder.Services.AddDbContext<AppDBContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


void AutoMigrateDatabase(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
    scope.ServiceProvider.GetRequiredService<AppDBContext>().Database.Migrate();
}


var app = builder.Build();


// Configure the HTTP request pipeline.

AutoMigrateDatabase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.MapControllers();

app.Run();
