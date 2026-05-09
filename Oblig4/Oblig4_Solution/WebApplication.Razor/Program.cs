namespace WebApp.Razor

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = global::Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient();
            builder.Services.AddRazorPages();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}