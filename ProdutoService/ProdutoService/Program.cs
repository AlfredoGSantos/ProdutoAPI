using Microsoft.OpenApi.Models;
using ProdutoService.Configuracoes;
using ProdutoService.Domain;
using ProdutoService.Services.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddMap();
builder.Services.AddMediatRConfiguration();
builder.Services.AddRepositorios();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(set => set.SwaggerDoc("v1", new OpenApiInfo()
{
    Title = "ProdutoService",
    Version = "v1",
    Description = "API REST .NET CORE"
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(set => set.SwaggerEndpoint("/swagger/v1/swagger.json", "Produto API"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
