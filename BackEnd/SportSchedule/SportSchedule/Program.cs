using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SportSchedule.Context;
using SportSchedule.Context.Seed;
using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Article;
using SportSchedule.DataTranserferObject.User;
using SportSchedule.Services;
using SportSchedule.Services.Article;
using SportSchedule.Services.Comment;
using SportSchedule.Services.Fixtures;
using SportSchedule.Services.Guess;
using SportSchedule.Services.League;
using SportSchedule.Services.Member;
using SportSchedule.Services.Permission;
using SportSchedule.Services.Ranking;
using SportSchedule.Services.Appointment;
using SportSchedule.Services.Statistic;
using SportSchedule.Services.Users;
using System.Text;
using SportSchedule.Services.Award;
using SportSchedule.Services.Role;

var builder = WebApplication.CreateBuilder(args);
var _context = new ContextDB();

//Cau hinh PostgreSQL
builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectedDB"))
    .ConfigureWarnings(warnings =>
               warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
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

//Dang ky Authorization
var permissions = new List<string>();
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContextDB>();
    permissions = dbContext.Permissions.Select(p => p.PermisstionName).ToList();
}

builder.Services.AddAuthorization(options =>
{
    foreach (var permission in permissions)
    {
        options.AddPolicy($"permission.{permission}", policy =>
            policy.Requirements.Add(new PermissionRequirement(permission)));
    }
});

//Cau hinh Authorization
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

// Add services to the container.
builder.Services.AddTransient<IUserSevice, UserService>();
builder.Services.AddTransient<ILeagueService, LeagueService>();
builder.Services.AddTransient<IFixturesService, FixturesService>();
builder.Services.AddTransient<IStatisticService, StatisticService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IRankingService, RankingService>();   
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IGuessService, GuessService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IAwardService, AwardService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddHostedService<MailBackgroundService>();
builder.Services.AddHostedService<StatisticBackgroundService>();
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dang ky Scope
builder.Services.AddScoped<MatchStatisticDAL>();
builder.Services.AddScoped<PeriodDAL>();
builder.Services.AddScoped<MemberDAL>();
builder.Services.AddScoped<PlayerDAL>();
builder.Services.AddScoped<PlayerMatchDAL>();
builder.Services.AddScoped<TeamMemberDAL>();
builder.Services.AddScoped<GoalDAL>();
builder.Services.AddScoped<CardDAL>();
builder.Services.AddScoped<MatchDAL>();
builder.Services.AddScoped<SubstitutionDAL>();
builder.Services.AddScoped<RankingDAL>();
builder.Services.AddScoped<LeagueDAL>();
builder.Services.AddScoped<UserDAL>();
builder.Services.AddScoped<PostDAL>();
builder.Services.AddScoped<CommentDAL>();
builder.Services.AddScoped<GuessDAL>();
builder.Services.AddScoped<AppointmentDAL>();
builder.Services.AddScoped<PermissionDAL>();
builder.Services.AddScoped<AwardDAL>();
builder.Services.AddScoped<RoleDAL>();

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
var memberService = app.Services.CreateScope().ServiceProvider.GetRequiredService<IMemberService>();
var rankingService = app.Services.CreateScope().ServiceProvider.GetRequiredService<IRankingService>();
var appointmentService = app.Services.CreateScope().ServiceProvider.GetRequiredService<IAppointmentService>();
//await DataSeedFixture.SeedingData(context, leagueService, fixtureService);
//await DataSeedStatistic.SeenDataStatistic(context, statisticService, memberService, rankingService);
//await DataSeedRanking.SeedRanking(context, rankingService);
//await DataSeedMail.SeedDataMail(_context, appointmentService);
app.Run();
