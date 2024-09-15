using IrisECom.Data;
using IrisECom.Repositories;
using IrisECom.Services.Implements;
using IrisECom.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

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
var connectionString = builder.Configuration.
GetConnectionString("DefaultConnection");

// Registra o DataContext como um serviço de contexto de banco de dados
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString)
);

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

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("MyPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
