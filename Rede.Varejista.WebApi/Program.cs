using MongoDB.Bson.Serialization;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Domain.Services.Facade;
using Rede.Varejista.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("RedeVarejistaDatabase"));

builder.Services.AddSingleton<CategoriaCommandServiceFacade>();
builder.Services.AddSingleton<CategoriaQueryServiceFacade>();
//builder.Services.AddSingleton<ProdutoCommandServiceFacade>();
//builder.Services.AddSingleton<ProdutoQueryServiceFacade>();

BsonClassMap.RegisterClassMap<Categoria>(map =>
{
    map.AutoMap();
    map.SetIgnoreExtraElements(true);
    BsonClassMap.RegisterClassMap<Produto>(child =>
    {
        child.AutoMap();
    });
});

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

app.Run();