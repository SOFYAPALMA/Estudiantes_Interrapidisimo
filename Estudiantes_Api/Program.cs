using Business.IService;
using Business.Service;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string DefaultConnection not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped(typeof(IEstudiantesRepository), typeof(EstudiantesRepository));
builder.Services.AddScoped(typeof(IEstudiantesService), typeof(EstudiantesService));

builder.Services.AddScoped(typeof(IMateriaRepository), typeof(MateriaRepository));
builder.Services.AddScoped(typeof(IMateriaService), typeof(MateriaService));

builder.Services.AddScoped(typeof(IProfesorRepository), typeof(ProfesorRepository));
builder.Services.AddScoped(typeof(IProfesorService), typeof(ProfesorService));

builder.Services.AddScoped(typeof(IEstudianteMateriaRepository), typeof(EstudianteMateriaRepository));
builder.Services.AddScoped(typeof(IEstudianteMateriaService), typeof(EstudianteMateriaService));

builder.Services.AddScoped(typeof(IProfesorMateriaRepository), typeof(ProfesorMateriaRepository));
builder.Services.AddScoped(typeof(IProfesorMateriaService), typeof(ProfesorMateriaService));

builder.Services.AddScoped(typeof(IAuth), typeof(Auth));


// Add services to the container.

builder.Services.AddControllers();

// Configuración JWT

//builder.Services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();
//builder.Services
//    .AddAuthorization()
//    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,

//            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//            ValidAudience = builder.Configuration["JwtSettings:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
//        };
//    });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region Shows UseCors with CorsPolicyBuilder.

app.UseCors(builder =>
{
    builder
    .WithOrigins("http://170.247.0.104:2180")
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

#endregion

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
