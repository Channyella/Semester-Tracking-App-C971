using C971_MobileApp.Models;

namespace C971_MobileApp;

public partial class CoursePage : ContentPage
{
	public int CourseId { get; set; }
    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
    public CoursePage(int courseId)
	{
		CourseId = courseId;
		InitializeComponent();
        Course = App.CourseData.GetCourseById(courseId);
        Name.Text = Course.Name;
        Description.Text = Course.Description;
        StartDate.Date = Course.StartDate;
        EndDate.Date = Course.EndDate;
        Instructor instructor = App.InstructorData.GetInstructorById(Course.InstructorId);
        InstructorName.Text = instructor.Name;
        InstructorEmail.Text = instructor.Email;
        InstructorPhoneNumber.Text = instructor.PhoneNumber;
        ActiveSwitch.IsToggled = Course.Status;
        EditCourseBtn.BindingContext = Course.Id;
        
    }
    public void EditCourse(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        int buttonId = (int)button.BindingContext;

        Navigation.PushAsync(new EditTerm(buttonId));
    }
}