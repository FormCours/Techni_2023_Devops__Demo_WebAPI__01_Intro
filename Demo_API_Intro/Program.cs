var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
    // Ajout des controlleurs
    .AddControllers(config =>
    {
        // Prend en compte l'attribut "Accept" du Header => Format XML
        config.RespectBrowserAcceptHeader = true;

        // Erreur (406) quand le format n'est pas supporté
        config.ReturnHttpNotAcceptable = true;
    })
    // Ajout du support pour le format XML
    .AddXmlDataContractSerializerFormatters();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
