using C971_MobileApp.Data;

namespace C971_MobileApp
{
    public partial class App : Application
    {
        public static InstructorData InstructorData { get; set; }
        public static AssessmentData AssessmentData { get; set; }
        public static CourseData CourseData { get; set; }
        public static TermData TermData { get; set; }

        public App(InstructorData instructorData, AssessmentData assessmentData, CourseData courseData, TermData termData)
        {
            InitializeComponent();

            MainPage = new AppShell();

            InstructorData = instructorData;
            AssessmentData = assessmentData;
            CourseData = courseData;
            TermData = termData;
        }
    }
}