using Elastic.CommonSchema.Serilog;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Spenny_Wise.WebAPI.Data_Access;
using Spenny_Wise.WebAPI.Data_Access.Contracts;
using Spenny_Wise.WebAPI.Data_Access.Repository;
using Spenny_Wise.WebAPI.Domain.Models;


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
builder.Services.AddScoped<IBudgetandExpenseBaseContract<Expense>, ExpenseRepository>();

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
