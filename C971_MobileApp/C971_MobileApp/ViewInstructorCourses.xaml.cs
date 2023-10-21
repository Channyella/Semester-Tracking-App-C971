using C971_MobileApp.Models;
using System.Collections.ObjectModel;

namespace C971_MobileApp;

public partial class ViewInstructorCourses : ContentPage
{
    public ObservableCollection<Course> CourseData { get; set; } = new();
	public int InstructorId { get; set; }
	public Instructor Instructor { get; set; }
    public ViewInstructorCourses(int instructorId)
	{
		this.InstructorId = instructorId;
		InitializeComponent();
		Instructor = App.InstructorData.GetInstructorById(instructorId);
        
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshCourses();
    }
    private void RefreshCourses()
    {
        CourseData.Clear();
        List<Course> courseList = App.CourseData.GetCoursesByInstructorId(InstructorId);
        foreach (Course course in courseList)
        {
            CourseData.Add(course);
        }
    }
    public void AddCourse(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        int buttonId = (int)button.BindingContext;

        Navigation.PushAsync(new NewCourse(buttonId));
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
    public async void DeleteCourse(object sender, EventArgs e)
    {
        bool deleteCourse = await DisplayAlert("Delete Course", "Are you sure that you want to delete this course?", "Yes", "No");
        if (deleteCourse)
        {
            ImageButton button = (ImageButton)sender;
            App.CourseData.DeleteCourse((int)button.BindingContext);
            RefreshCourses();
        }
    }

}