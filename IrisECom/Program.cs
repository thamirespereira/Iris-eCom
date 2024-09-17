using IrisECom.Data;
using IrisECom.Repositories;
using IrisECom.Services.Implements;
using IrisECom.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

var urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5001";
builder.WebHost.UseUrls(urls);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    }
); ;

//Configuracao para evitar Ciclos nas buscas do Entity Framework
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

// Conexão com o Banco de dados
if (builder.Configuration["Environment:Start"] == "PROD")
{
    // Conexão com o PostgresSQL - Nuvem

    /*builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("secrets.json");*/
    builder.Configuration
    .AddJsonFile("/app/secrets.json", optional: true)
    .AddJsonFile("secrets.json", optional: true);


    var connectionString = builder.Configuration
   .GetConnectionString("ProdConnection");

    builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(connectionString)
    );
}
else
{
    // Conexão com o SQL Server - Localhost
    var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(connectionString)
    );
}

// Configurações repositories
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<UsuarioRepository>();

// Configurações services
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    //Personalizar a Págna inicial do Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto Íris eCom",
        Description = "Projeto Íris eCom - ASP.NET Core 8 - Entity Framework",
        Contact = new OpenApiContact
        {
            Name = "Thamires Fernanda Rodrigues Pereira",
            Email = "thamiresfrpereira2@gmail.com",
            Url = new Uri("https://github.com/thamirespereira")
        },
        License = new OpenApiLicense
        {
            Name = "Github",
            Url = new Uri("https://github.com/thamirespereira/Iris-eCom")
        }
    });

    var xmlFile = "DocumentingSwagger.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
// Configuração do CORS
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "MyPolicy",
            policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
    });

    var app = builder.Build();

// Criar o Banco de dados e as tabelas Automaticamente
using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.EnsureCreated();
}

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

// Swagger Como Página Inicial - Nuvem

if (app.Environment.IsProduction())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Íris eCom - v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

    app.UseCors("MyPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
