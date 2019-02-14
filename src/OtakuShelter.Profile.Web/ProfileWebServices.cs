using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Phema.Routing;
using Swashbuckle.AspNetCore.Swagger;

namespace OtakuShelter.Profile
{
    public static class ProfileWebServices
    {
        public static IServiceCollection AddWebServices(
			this IServiceCollection services,
			ProfileWebConfiguration configuration)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options => 
					options.AddPolicy("admin", builder => builder.RequireRole("admin")))
				.AddApiExplorer()
				.AddPhemaRouting(routing => routing.AddProfilesController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			var secret = Encoding.ASCII.GetBytes(configuration.Secret);
			services.AddAuthentication(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(secret),
						ValidateIssuer = true,
						ValidIssuer = configuration.Issuer,
						ValidateAudience = true,
						ValidAudience = configuration.Audience
					};
				});
			
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info {Title = "OtakuShelter Profile API", Version = "v1"});
				
				options.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					Description = "JWT Authorization header",
					Name = "Authorization",
					In = "header",
					Type = "apiKey"
				});
				
				options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
				{
					["Bearer"] = Enumerable.Empty<string>()
				});
			});
			
			return services;
		}

		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<ProfileContext>()
					.Database
					.Migrate();
			}
		}
    }
}