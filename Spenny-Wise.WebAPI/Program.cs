using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Spenny_Wise.WebAPI.Data_Access;
using Spenny_Wise.WebAPI.Data_Access.Contracts;
using Spenny_Wise.WebAPI.Data_Access.Contracts.AuthContract;
using Spenny_Wise.WebAPI.Data_Access.Contracts.BaseContract;
using Spenny_Wise.WebAPI.Data_Access.DataAccessHelpers;
using Spenny_Wise.WebAPI.Data_Access.Repositories;
using Spenny_Wise.WebAPI.Data_Access.Repositories.Authentication;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;
using Spenny_Wise.WebAPI.Domain.Utilities;
using Spenny_Wise.WebAPI.Service.MailService;
using System.Text;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Verbose()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Verbose()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .Enrich.WithProcessId()
    .Enrich.WithProcessName()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .WriteTo.Console(new EcsTextFormatter())
    .WriteTo.File(new EcsTextFormatter(), "Log/log.text", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SpennyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Spenny-Connect"));
});
builder.Services.AddTransient<IBudgetandExpenseBaseContract<Expense>, ExpenseRepository>();
builder.Services.AddScoped<ExceptionHandler>();
builder.Services.AddTransient<DBAccessHelper>();
builder.Services.AddTransient<IAuthService, AuthRepository>();
builder.Services.AddTransient<ModelMapper>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    var secret = builder.Configuration.GetSection("AppSettings:SECRET").Value;
 
    option.SaveToken = true;
    option.RequireHttpsMetadata = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT_ISSUER"],
        ValidateLifetime = true,
        
    };

});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Authorize", Version = "v1" });
    options.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string []{}
        }
    });
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
