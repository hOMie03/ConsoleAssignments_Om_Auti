using Microsoft.EntityFrameworkCore;
using TicketTango.Context;
using TicketTango.Filters;
using TicketTango.Repository;
using TicketTango.Service;

namespace TicketTango
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            string conn = builder.Configuration.GetConnectionString("localDBConnection");
            builder.Services.AddDbContext<TicketTangoDBContext>(opt => opt.UseSqlServer(conn)); // DB Connection
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<ITicketBookingService, TicketBookingService>();
            builder.Services.AddScoped<ITicketBookingRepository, TicketBookingRepository>();

            // Filters
            builder.Services.AddSingleton<userAuthorizeFilter>(); // Authorization
            builder.Services.AddSingleton<ExceptionHandlerAttribute>(); // Exception Handler Attribute

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}