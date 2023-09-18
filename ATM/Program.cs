using ATM.Core.Abstarctions;
using ATM.Core.Features.Account.GetAccount;
using ATM.Core.Features.Account.UpdateAccount;
using ATM.Core.Features.Auth.Login;
using ATM.Core.Features.Card.UpdateCard;
using ATM.Core.Features.Transaction.AddTransaction;
using ATM.Core.Features.Transaction.GetTransactions;
using ATM.Core.Features.WithdrawMoney;
using ATM.Infrastructure.Persistence;
using ATM.Infrastructure.Persistence.EntityMapping;
using ATM.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));



builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})


// Adding Jwt Bearer
    .AddJwtBearer(options => {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();


builder.Services.AddSwaggerGen(c => {

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header. Enter the token provided at the login endpoint",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = null;
});


builder.Services.AddDbContext<ATMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IRequestHandler<LoginRequest, LoginResponse>, LoginHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateCardRequest, Unit>, UpdateCardHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateAccountRequest, Unit>, UpdateAccountHandler>();
builder.Services.AddScoped<IRequestHandler<GetAccountRequest, GetAccountResponse>, GetAccountHandler>();
builder.Services.AddScoped<IRequestHandler<WithdrawMoneyRequest, WithdrawMoneyResponse>, WithdrawMoneyHandler>();
builder.Services.AddScoped<IRequestHandler<AddTransactionRequest, AddTransactionResponse>, AddTransactionHandler>();
builder.Services.AddScoped<IRequestHandler<GetTransactionsRequest, GetTransactionsResponse>, GetTransactionsHandler>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ATMContext>();
    context.Database.Migrate();
}

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
