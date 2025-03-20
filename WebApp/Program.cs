using System.Data;
using Microsoft.Data.SqlClient;
using WebApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnection>(sp =>
{
    return new SqlConnection(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddTransient<ColaboradorRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "Test_Policy",
        policy =>
        {
            policy
            .AllowAnyOrigin()
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

app.UseAuthorization();

app.UseCors("Test_Policy");

app.MapControllers();

app.Run();
