using C971_MobileApp.Models;

namespace C971_MobileApp;

public partial class EditCourse : ContentPage
{
	private int CourseId { get; set; }
	public Course Course { get; set; }
	public Instructor Instructor { get; set; }
	public EditCourse(int courseId)
	{
		this.CourseId = courseId;
		InitializeComponent();
		Course = App.CourseData.GetCourseById(courseId);
		Name.Text = Course.Name;
		Description.Text = Course.Description;
		StartDate.Date = Course.StartDate;
		EndDate.Date = Course.EndDate;
		InstructorName.Text = (App.InstructorData.GetInstructorById(Course.InstructorId).Name);
	}
	public void EditCourseButton(object sender, EventArgs e)
	{
		App.CourseData.EditCourse(new Course
		{
			Id = this.CourseId,
			Name = Name.Text,
			Description = Description.Text,
			StartDate = StartDate.Date,
			EndDate = EndDate.Date,
			InstructorId = Course.InstructorId,
		});

		Navigation.PushAsync(new ViewInstructorCourses(Course.InstructorId));
	}
}