using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Web;

    public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configure the database context using the connection string from appsettings.json
        services.AddDbContext<Data.NinjaEquipmentDbContext>(options =>
        options.UseSqlServer(
                  _configuration.GetConnectionString("DefaultConnection")));


        // Add your services here
        services.AddRazorPages();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Use HTTPS redirection (optional but recommended for production)
        app.UseHttpsRedirection();

        // Serve static files (e.g., CSS, JavaScript, images)
        app.UseStaticFiles();

        // Enable routing
        app.UseRouting();

        // Add authentication and authorization middleware here if needed.

        // Define your endpoints and route to Razor Pages
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
