using AutomobiliuNuoma.API.Contracts;
using AutomobiliuNuoma.API.Service;
using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Repositories;
using AutomobiliuNuoma.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IKlientaiRepository, KlientaiFileRepository>(_ => new KlientaiFileRepository("Klientai.csv"));
builder.Services.AddTransient<IAutomobiliaiRepository, AutomobiliaiDbRepository>(_ => new AutomobiliaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;"));
builder.Services.AddTransient<IKlientaiService, KlientaiService>();
builder.Services.AddTransient<IAutomobiliaiService, AutomobiliaiService>();
builder.Services.AddTransient<IDarbuotojaiRepository, DarbuotojaiDbRepository>(_ => new DarbuotojaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;"));
builder.Services.AddTransient<IDarbuotojaiService, DarbuotojaiService>();
builder.Services.AddTransient<IAutonuomaService, AutonuomosService>();
builder.Services.AddSingleton<ICacheService, CacheService>();


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


static IAutonuomaService SetupDependencies()
{
    IKlientaiRepository klientaiRepository = new KlientaiFileRepository("Klientai.csv");
    //IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiFileRepository("Auto.csv");
    IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;");
    IKlientaiService klientaiService = new KlientaiService(klientaiRepository);
    IAutomobiliaiService automobiliaiService = new AutomobiliaiService(automobiliaiRepository);
    IDarbuotojaiRepository darbuotojaiRepository = new DarbuotojaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;");
    IDarbuotojaiService darbuotojaiService = new DarbuotojaiService(darbuotojaiRepository);
    return new AutonuomosService(klientaiService, automobiliaiService, darbuotojaiService);
}