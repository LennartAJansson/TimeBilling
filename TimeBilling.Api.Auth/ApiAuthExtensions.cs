namespace TimeBilling.Api.Auth;

using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

using TimeBilling.Api.Auth.Data.Context;
using TimeBilling.Api.Auth.Data.Model;
using TimeBilling.Api.Auth.Services;

public static class ApiAuthExtensions
{
  public static IServiceCollection AddApiAuth(this IServiceCollection services, IConfiguration configuration)
  {
    _ = services.AddControllers();
    _ = services.AddEndpointsApiExplorer();
    _ = services.AddSwaggerGen(options => options.EnableAnnotations());

    _ = services.AddAutoMapper(typeof(ApiAuthExtensions).Assembly);
    _ = services.AddMediatR(configuration =>
    {
      _ = configuration.RegisterServicesFromAssembly(typeof(ApiAuthExtensions).Assembly);
    });
    _ = services.AddTransient<IApiAuthService, ApiAuthService>();
    _ = services.AddTransient<IAuthMail, DummyAuthMail>();

    JwtSettings? jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>()
      ?? throw new ArgumentException("No jwtsettings");
    _ = services.Configure<JwtSettings>(opt => configuration.GetSection("JwtSettings").Bind(opt));

    string connectionString = configuration.GetConnectionString("AuthDb")
      ?? throw new ArgumentException("No connectionstring");

    ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);

    _ = services.AddDbContext<ApiAuthDbContext>(options => options.UseMySql(connectionString, serverVersion));

    _ = services.AddIdentity<AuthUser, AuthRole>(options =>
    {
      options.Password.RequireDigit = jwtSettings.RequireDigit;
      options.Password.RequiredLength = jwtSettings.RequiredLength;
      options.Password.RequireNonAlphanumeric = jwtSettings.RequireNonAlphanumeric;
      options.Password.RequireUppercase = jwtSettings.RequireUppercase;
      options.Password.RequireLowercase = jwtSettings.RequireLowercase;
    })
      .AddEntityFrameworkStores<ApiAuthDbContext>()
      .AddDefaultTokenProviders();

    _ = services.AddAuthorization()
      .AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      //https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src
      .AddJwtBearer(options =>
      {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidIssuer = jwtSettings.Issuer,
          ValidAudience = jwtSettings.Issuer,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
          ClockSkew = TimeSpan.Zero
        };
      });

    _ = services.AddAuthorizationBuilder()
        //https://www.yogihosting.com/aspnet-core-identity-policies/
        .AddPolicy("adminPolicy", policy => policy
            .RequireRole("Admin")
            .RequireAuthenticatedUser())
        //.RequireClaim("")
        //.RequireUserName(""))
        .AddPolicy("userPolicy", policy => policy
            .RequireRole("User")
            .RequireAuthenticatedUser());

    return services;
  }

  public static WebApplication UseApiAuth(this WebApplication app)
  {
    _ = app.UseAuthentication();

    _ = app.UseAuthorization();

    _ = app.UseRouting();

    _ = app.MapControllers();

    return app;
  }

  public static WebApplication UpdateIdentityDb(this WebApplication host)
  {
    using (IServiceScope scope = host.Services.CreateScope())
    {
      scope.ServiceProvider.GetRequiredService<ApiAuthDbContext>().EnsureDbExists();
    }

    return host;
  }

  public static IServiceCollection ChangeMailProvider<T>(this IServiceCollection services) where T : class, IAuthMail
  {
    ServiceDescriptor descriptor = new(typeof(IAuthMail), typeof(T), ServiceLifetime.Transient);
    _ = services.Replace(descriptor);

    return services;
  }
}
