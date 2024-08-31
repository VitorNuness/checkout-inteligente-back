using System.Text;
using App.Repositories.Database;
using App.Repositories;
using App.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<CheckoutDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAnyOrigins",
                builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SECRET_KEY"]!))
                            };
                        });

        builder.Services.AddAuthorization();

        builder.Services
            .AddControllers()
            .AddJsonOptions(option =>
                option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

        builder.Services.AddScoped<CampaignService>();
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<ImageService>();
        builder.Services.AddScoped<OrderItemService>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<SuggestionService>();
        builder.Services.AddScoped<TokenService>();
        builder.Services.AddScoped<UserService>();

        builder.Services.AddScoped<CampaignRepository>();
        builder.Services.AddScoped<CategoryRepository>();
        builder.Services.AddScoped<ImageRepository>();
        builder.Services.AddScoped<OrderItemRepository>();
        builder.Services.AddScoped<OrderRepository>();
        builder.Services.AddScoped<ProductRepository>();
        builder.Services.AddScoped<UserRepository>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors("AllowAnyOrigins");

        app.Run();
    }
}
