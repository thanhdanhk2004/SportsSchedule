using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SportSchedule.Context;
using SportSchedule.Context.Seed;
using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.User;
using SportSchedule.Services;
using SportSchedule.Services.Fixtures;
using SportSchedule.Services.League;
using SportSchedule.Services.Permission;
using SportSchedule.Services.Statistic;
using SportSchedule.Services.Users;
using System.Text;

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

builder.Services.AddHttpClient("FootballData", client =>
{
    client.BaseAddress = new Uri("https://api.football-data.org/v4/");
    client.DefaultRequestHeaders.Add("X-Auth-Token", builder.Configuration["MyApiSettings:ApiToken"]);
});

//Cau hinh JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);

var secretKey = jwtSettings["SecretKey"];
var key = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],

        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});

builder.Services.AddAuthorization();

//Cau hinh Authorization
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

// Add services to the container.
builder.Services.AddTransient<IUserSevice, UserService>();
builder.Services.AddTransient<ILeagueService, LeagueService>();
builder.Services.AddTransient<IFixturesService, FixturesService>();
builder.Services.AddTransient<IStatisticService, StatisticService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dang ky Scope
builder.Services.AddScoped<MatchStatistic>();

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

//Dang ky Authorization
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContextDB>();
    var permissions = dbContext.Permissions.Select(p => p.PermisstionName).ToList();

    var authOptions = app.Services.GetRequiredService<IAuthorizationPolicyProvider>() as AuthorizationOptions;
    if (authOptions != null)
    {
        foreach (var permission in permissions)
        {
            authOptions.AddPolicy($"Permission.{permission}", policy =>
                policy.Requirements.Add(new PermissionRequirement(permission!)));
        }
    }
}


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Seeding data
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ContextDB>();
var leagueService = app.Services.CreateScope().ServiceProvider.GetRequiredService<ILeagueService>();
var fixtureService = app.Services.CreateScope().ServiceProvider.GetRequiredService<IFixturesService>();
var statisticService = app.Services.CreateScope().ServiceProvider.GetRequiredService<IStatisticService>();
await DataSeedFixture.SeedingData(context, leagueService, fixtureService);
await DataSeedStatistic.SeenDataStatistic(context, statisticService);

app.Run();
