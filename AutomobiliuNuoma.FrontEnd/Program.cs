using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Repositories;
using AutomobiliuNuoma.Core.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient("mongodb+srv://testuser3:123!asd56@cluster0.kcffo36.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"));
builder.Services.AddTransient<IMongoDbCacheRepository, MongoDbCacheRepository>();
builder.Services.AddTransient<IKlientaiRepository, KlientaiFileRepository>(_ => new KlientaiFileRepository("Klientai.csv"));
builder.Services.AddTransient<IAutomobiliaiRepository, AutomobiliaiDbRepository>(_ => new AutomobiliaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;"));
builder.Services.AddTransient<IKlientaiService, KlientaiService>();
builder.Services.AddTransient<IAutomobiliaiService, AutomobiliaiService>();
builder.Services.AddTransient<IDarbuotojaiRepository, DarbuotojaiDbRepository>(_ => new DarbuotojaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;"));
builder.Services.AddTransient<IDarbuotojaiService, DarbuotojaiService>();
builder.Services.AddTransient<IAutonuomaService, AutonuomosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
