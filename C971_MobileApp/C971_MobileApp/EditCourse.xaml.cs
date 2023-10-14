using C971_MobileApp.Models;
using System.Collections.ObjectModel;

namespace C971_MobileApp;

public partial class EditCourse : ContentPage
{
	private int CourseId { get; set; }
	public Course Course { get; set; }
	public Instructor Instructor { get; set; }
    public ObservableCollection<Instructor> InstructorList { get; set; } = new();
    public EditCourse(int courseId)
	{
		this.CourseId = courseId;
		InitializeComponent();
		Course = App.CourseData.GetCourseById(courseId);
		Name.Text = Course.Name;
		Description.Text = Course.Description;
		StartDate.Date = Course.StartDate;
		EndDate.Date = Course.EndDate;
        List<Instructor> instructorList = App.InstructorData.GetInstructors();
        foreach (Instructor instructor in instructorList)
        {
            InstructorList.Add(instructor);
        }
        Instructor = InstructorList.Single(instructor => instructor.Id == Course.InstructorId);
        InstructorName.SelectedItem = Instructor;
		ActiveSwitch.IsToggled = Course.Status;
	}
	public async void EditCourseButton(object sender, EventArgs e)
	{
		App.CourseData.EditCourse(new Course
		{
			Id = this.CourseId,
			Name = Name.Text,
			Description = Description.Text,
			StartDate = StartDate.Date,
			EndDate = EndDate.Date,
			InstructorId = Course.InstructorId,
            Status = ActiveSwitch.IsToggled,
        });
		await Navigation.PopAsync();
	}
}