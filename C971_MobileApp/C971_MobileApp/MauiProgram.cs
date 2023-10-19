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
            string dbPathInstructor = Path.Combine(FileSystem.AppDataDirectory, "instructor.db");
            string dbPathCourse = Path.Combine(FileSystem.AppDataDirectory, "course.db");
            string dbPathAssessment = Path.Combine(FileSystem.AppDataDirectory, "assessment.db");
            string dbPathTerm = Path.Combine(FileSystem.AppDataDirectory, "term.db");

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<InstructorData>(s, dbPathInstructor));
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CourseData>(s, dbPathCourse, s.GetRequiredService<InstructorData>()));
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<AssessmentData>(s, dbPathAssessment));
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<TermData>(s, dbPathTerm, s.GetRequiredService<CourseData>()));

            return builder.Build();
        }
    }
}