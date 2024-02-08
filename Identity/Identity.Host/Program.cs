using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Identity.Application;
using Identity.Application.Authorizations;
using Identity.Application.Contracts;
using Identity.Application.Contracts.Dtos;
using Identity.Application.Contracts.Repositories;
using Identity.Application.Contracts.Services;
using Identity.Application.Identity;
using Identity.Application.Providers;
using Identity.Application.Repositories;
using Identity.Application.Repository;
using Identity.Application.Services;
using Identity.Application.Validators;
using Identity.Domain;
using Identity.Domain.Models;
using Identity.EntityFrameworkCore.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var identityCors = "_identityCors";
var jwtOptions = new JwtOptions();


builder.Configuration.GetSection("Jwt").Bind(jwtOptions);
builder.Services.AddSingleton(jwtOptions);

builder.Services.AddCors(options =>
{
    options.AddPolicy(identityCors, policy =>
    {
        policy.WithOrigins("http://localhost:4200");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext"));
});

builder.Services.AddIdentityCore<User>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.SignIn.RequireConfirmedEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddUserManager<UserManager<User>>()
    .AddSignInManager<SignInManager<User>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.JwtKey)),
            ValidIssuer = jwtOptions.JwtIssuer,
            ValidateIssuer = true,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityDomainAuthorizationPolicyConstants.HasNationality, builder => 
        builder.RequireClaim(IdentityDomainAuthorizationPolicyConstants.Nationality, "German", "English"));
    options.AddPolicy(IdentityDomainAuthorizationPolicyConstants.AtLeast18, builder => 
        builder.AddRequirements(new MinimumAgeRequirement(18)));
    options.AddPolicy(IdentityDomainAuthorizationPolicyConstants.TrialOnly, builder => 
        builder.RequireClaim(IdentityDomainAuthorizationPolicyConstants.Trial));
});

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IValidator<RegisterDto>, RegisterUserValidator>();
builder.Services.AddScoped<IAuthorizationHandler, MinimumAgeHandler>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(identityCors);

app.Run();
