using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetC_.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjetC_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetC_Context") ?? throw new InvalidOperationException("Connection string 'ProjetC_Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ProjetC_Context>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
app.Run();
