using C971_MobileApp.Data;

namespace C971_MobileApp
{
    public partial class App : Application
    {
        public static InstructorData InstructorData { get; set; }
        public App(InstructorData instructorData)
        {
            InitializeComponent();

            MainPage = new AppShell();

            InstructorData = instructorData;
        }
    }
}