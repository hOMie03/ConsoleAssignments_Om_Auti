using PPB.Application;
using PPB.Identity;
using PPB.Infrastructure;

namespace PPB.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.AddInfraServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //string conn = builder.Configuration.GetConnectionString("PPBDBConnString");
            //builder.Services.AddDbContext<PPBDBContext>(opt => opt.UseSqlServer(conn));
            //builder.Services.AddScoped<IAccountService, AccountService>();
            //builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
