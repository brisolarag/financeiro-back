using financeiro_back.Context;
using financeiro_back.Repositories.SaidasRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinanceiroContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging().LogTo(Console.WriteLine);
    }
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISaidaRepository, SaidaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
