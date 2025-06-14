using RecamProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RecamProject.Settings;



namespace RecamProject
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();




            // configure Swagger
            builder.Services.AddSwaggerGen(
                options =>
                {
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);
                }
            );

            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
            builder.Services.AddSingleton<MongoDbContext>();

            var connectionString = builder.Configuration.GetConnectionString("RecamDb");
            builder.Services.AddDbContext<RecamDbContext>(options =>
                           options.UseSqlServer(connectionString));


            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<RecamDbContext>();
           

            var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
              builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireClaim("scope", "admin"));

    options.AddPolicy("UserPolicy", policy =>
        policy.RequireClaim("scope", "user"));
});


            // builder.Services.AddScoped<JwtTokenService>();

            builder.Services.AddAutoMapper(typeof(Program));





            var app = builder.Build();




            // Configure the HTTP request pipeline.
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
        }
    }
}