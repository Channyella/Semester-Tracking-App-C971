using C971_MobileApp.Models;
using System.Collections.ObjectModel;

namespace C971_MobileApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Course> CourseList  { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            RefreshCourses();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshCourses();
        }
        public void ViewCourse(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int buttonId = (int)button.BindingContext;

            Navigation.PushAsync(new CoursePage(buttonId));
        }
        public void EditCourse(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;

            int buttonId = (int)button.BindingContext;

            Navigation.PushAsync(new EditCourse(buttonId));
        }
        public void DeleteCourse(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            App.CourseData.DeleteCourse((int)button.BindingContext);
            RefreshCourses();
        }
        private void RefreshCourses()
        {
            CourseList.Clear();
            Term activeTerm = App.TermData.GetActiveTerm();
            if (activeTerm != null)
            {
                List<Course> courseList = App.CourseData.GetActiveCoursesByActiveTerm(activeTerm);
                foreach (Course course in courseList)
                {
                    CourseList.Add(course);
                }
            }
        }

    }
}