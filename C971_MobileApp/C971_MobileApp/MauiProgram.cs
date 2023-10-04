using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using C971_MobileApp.Data;

namespace C971_MobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "instructor.db");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<InstructorData>(s, dbPath));

            return builder.Build();
        }
    }
}