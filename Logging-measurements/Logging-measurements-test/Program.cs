using Logging_measurements_test.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Logging_measurements_test
{
    internal static class Program
    {
        private static IServiceProvider _serviceProvider = null!;

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            services.InitServices();
            _serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(_serviceProvider.GetRequiredService<LoginForm>());
        }
    }
}