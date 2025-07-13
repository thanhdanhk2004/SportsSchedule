using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SportSchedule.Context;
using SportSchedule.Services;
using SportSchedule.Services.Users;

var builder = WebApplication.CreateBuilder(args);

//Cau hinh PostgreSQL
builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectedDB"))
    .ConfigureWarnings(warnings =>
               warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});


// Thêm HttpClient cho API-Football
builder.Configuration.AddJsonFile("key.json", optional: false, reloadOnChange: true);
builder.Services.AddHttpClient("FootballAPI", client =>
{
    client.BaseAddress = new Uri("https://v3.football.api-sports.io/");
    client.DefaultRequestHeaders.Add("x-apisports-key", builder.Configuration["MyApiSettings:ApiKeySport"]);
});



// Add services to the container.
builder.Services.AddTransient<IUserSevice, UserService>();

builder.Services.AddControllers();
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

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
