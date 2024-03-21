using log_data_well.Forms;
using log_data_well.Services.Implementations;
using log_data_well.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace log_data_well
{
    internal static class DIExtensions
    {
        public static void InitServices(this ServiceCollection services)
        {
            services.AddTransient<MainForm>();
            services.AddTransient<LoginForm>();

            services.AddScoped<IDbLogg, DbLogg>();
        }
    }
}
