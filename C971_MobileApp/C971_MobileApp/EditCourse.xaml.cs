using C971_MobileApp.Models;
using System.Collections.ObjectModel;

namespace C971_MobileApp;

public partial class EditCourse : ContentPage
{
	private int CourseId { get; set; }
	public Course Course { get; set; }
	public Instructor Instructor { get; set; }
    public ObservableCollection<Instructor> InstructorList { get; set; } = new();
    public ObservableCollection<string> StatusNames { get; set; } = Course.GetStatusList();
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
		StatusPicker.SelectedIndex = StatusNames.IndexOf(Course.GetStatusName(Course.Status));
	}
	public async void EditCourseButton(object sender, EventArgs e)
	{
        if (string.IsNullOrWhiteSpace(Name.Text))
        {
            await DisplayAlert("Invalid", "Name is required.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(Description.Text))
        {
            await DisplayAlert("Invalid", "Description is required", "OK");
            return;
        }
        if (EndDate.Date < StartDate.Date)
        {
            await DisplayAlert("Invalid", "The end date must come before start date", "OK");
            return;
        }
        if (InstructorName.SelectedItem == null)
        {
            await DisplayAlert("Invalid", "Must have an instructor selected", "OK");
            return;
        }
        App.CourseData.EditCourse(new Course
		{
			Id = this.CourseId,
			Name = Name.Text,
			Description = Description.Text,
			StartDate = StartDate.Date,
			EndDate = EndDate.Date,
			InstructorId = Course.InstructorId,
            Status = Course.GetStatusFromName(StatusPicker.Items[StatusPicker.SelectedIndex])
        });
		await Navigation.PopAsync();
	}
}