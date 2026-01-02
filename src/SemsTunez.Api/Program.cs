using Microsoft.EntityFrameworkCore;
using SemsTunez.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<SemsTunezDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Default")));


// Auth will be added later
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Swagger (dev only)
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