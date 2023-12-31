using ProdutoService.Configuracoes;
using ProdutoService.Domain;
using ProdutoService.Services.Queries;

var connectionString = !string.IsNullOrEmpty(CustomConfig.ConnectionString) ? CustomConfig.ConnectionString : string.Empty;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddMap();
builder.Services.AddMediatRConfiguration();
builder.Services.AddRepositorios(connectionString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
