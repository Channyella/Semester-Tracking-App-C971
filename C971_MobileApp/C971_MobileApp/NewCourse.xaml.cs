using C971_MobileApp.Models;
using static C971_MobileApp.Models.Course;

namespace C971_MobileApp;

public partial class NewCourse : ContentPage
{
	public int InstructorId { get; set; }
	public Instructor Instructor { get; set; }
	public NewCourse(int InstructorId)
	{
		this.InstructorId = InstructorId;
		InitializeComponent();
		Instructor = App.InstructorData.GetInstructorById(this.InstructorId);
		InstructorName.Text = Instructor.Name;
	}

	public DatePicker SelectedStartDate = new DatePicker
	{
		Date = DateTime.Now
	};

    public DatePicker SelectedEndDate = new DatePicker
    {
        Date = DateTime.Now
    };

    public async void AddCourseButton(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Description.Text))
        {
            await DisplayAlert("Invalid", "There are blank fields. Please fill in before continuing.", "Okay");
            return;
        }
         Course courseInfo = App.CourseData.AddCourse(new Course
            {
                Name = Name.Text,
                Description = Description.Text,
                StartDate = StartDate.Date,
                EndDate = EndDate.Date,
                InstructorId = this.InstructorId
            }) ;
        await Navigation.PushAsync(new ViewInstructorCourses(this.InstructorId));
    }

}