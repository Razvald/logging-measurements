using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Logging_measurements_test.Forms;
using Logging_measurements_test.Models;
using Logging_measurements_test.Services.Interfaces;
using Logging_measurements_test.Services.Implementations;

namespace Logging_measurements_test
{
    internal static class DIExtensions
    {
        public static void InitServices(this ServiceCollection services)
        {
            services.AddTransient<Form1>();
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();

            services.AddScoped<IDbWorker, DbWorker>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data source=./app.db")
            );
        }
    }
}
