using DAL.DataAccess;
using DAL.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Registering services and dependencies

builder.Services.AddControllers();

// Injecting custom repositories for DI
builder.Services.AddScoped<IEventDetailsRepo<EventDetails>, EventDetailsRepo>();
builder.Services.AddScoped<IUserInfoRepo<UserInfo>, UserInfoRepo>();
builder.Services.AddScoped<IParticipantEventDetailsRepo<ParticipantEventDetails>, ParticipantEventDetailsRepo>();


// Swagger configuration with JWT Bearer authentication

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Hexaware Event API",
        Description = "Handles events, users, and participation tracking",
        TermsOfService = new Uri("https://www.hexaware.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Saravanapriya",
            Email = "tsaravanapriya535@gmail.com",
            Url = new Uri("https://www.linkedin.com/saravanapriyat2914")
        },
        License = new OpenApiLicense
        {
            Name = "Hexaware License",
            Url = new Uri("https://hexaware.com/license")
        }
    });

    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Use: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT"
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


// Enable Cross-Origin Requests (CORS)

builder.Services.AddCors(options =>
{
    options.AddPolicy("RestrictedPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:60685", "http://localhost:4200")
              .AllowAnyHeader()
              .WithMethods("GET", "POST");
    });
});


// JWT Token validation setup

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                // Directly use the token without requiring "Bearer " prefix
                var token = context.Request.Headers["Authorization"].FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
                return Task.CompletedTask;
            }
        };

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


// API Versioning setup

builder.Services.AddApiVersioning(versionOptions =>
{
    versionOptions.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    versionOptions.AssumeDefaultVersionWhenUnspecified = true;
    versionOptions.ReportApiVersions = true;
});


// Configure middleware and pipeline

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Hexaware Event API v1");
    });
}

// Apply middleware pipeline in correct order
app.UseRouting();
app.UseCors("RestrictedPolicy");
app.UseAuthentication();
app.UseAuthorization();

// Map controller endpoints to handle requests
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
