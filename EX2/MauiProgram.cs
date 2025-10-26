using Microsoft.Extensions.Logging;
using EX2.Services;
using EX2.ViewModels;

namespace EX2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Регистрация сервисов
            builder.Services.AddSingleton<GraphDataService>();
            builder.Services.AddTransient<GraphViewModel>();
            builder.Services.AddTransient<GraphPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}