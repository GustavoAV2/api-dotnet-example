using Microsoft.EntityFrameworkCore;
using RpgGame.Domain.Entities;
using RpgGame.Repository;
using System.Text.Json.Serialization;

namespace RpgGame.WebApi
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<DatabaseContext>(op => {
                    op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddScoped(typeof(IEFCoreRepository<>), typeof(EFCoreRepository<>));
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

        }

        public void ConfigureWebApi(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
