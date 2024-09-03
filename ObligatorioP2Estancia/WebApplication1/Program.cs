namespace WebApplication1
{ 
    public class Program
    { 
        public static void Main(string[] args)
        { 
            var builder = WebApplication.CreateBuilder(args);

                    // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
                app.UseStaticFiles();

                app.UseSession();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                name: "default",
                pattern: "{controller=MenuUsu}/{action=Inicio}/{id?}");
                app.Run();
        }
    }
}