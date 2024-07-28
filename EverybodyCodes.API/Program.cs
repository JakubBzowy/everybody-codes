using EverybodyCodes.Application.Cameras;
using EverybodyCodes.Domain.Repositories;
using EverybodyCodes.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// https://stackoverflow.com/questions/54127414/using-factory-pattern-with-asp-net-core-dependency-injection
builder.Services.AddScoped<ICamerasRepository, CamerasRepository>(x => {
    var csvFilePath = builder.Configuration["CsvFilePath"];
    return new CamerasRepository(csvFilePath);
});
builder.Services.AddScoped<ICamerasService, CamerasService>();
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

//temporary
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
