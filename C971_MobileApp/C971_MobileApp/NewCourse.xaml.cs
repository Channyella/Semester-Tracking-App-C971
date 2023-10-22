using C971_MobileApp.Models;
using Plugin.LocalNotification;
using System.Collections.ObjectModel;
using static C971_MobileApp.Models.Course;

namespace C971_MobileApp;

public partial class NewCourse : ContentPage
{
	public int InstructorId { get; set; }
	public Instructor Instructor { get; set; }
    public ObservableCollection<Instructor> InstructorList { get; set; } = new();
    public ObservableCollection<string> StatusNames { get; set; } = GetStatusList();

    public NewCourse(int InstructorId)
	{
		this.InstructorId = InstructorId;
		InitializeComponent();
        List<Instructor> instructorList = App.InstructorData.GetInstructors();
        foreach (Instructor instructor in instructorList )
        {
            InstructorList.Add(instructor);
        }
        Instructor = InstructorList.Single(instructor => instructor.Id == InstructorId);
        InstructorName.SelectedItem = Instructor;
    }
    public NewCourse()
    {
        InitializeComponent();
        InstructorName.SelectedItem = Instructor;
        List<Instructor> instructorList = App.InstructorData.GetInstructors();
        foreach (Instructor instructor in instructorList)
        {
            InstructorList.Add(instructor);
        }
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
        if (string.IsNullOrWhiteSpace(Name.Text))
        {
            await DisplayAlert("Invalid", "Name is required.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(Description.Text))
        {
            await DisplayAlert("Invalid", "Description is required.", "OK");
            return;
        }
        if (EndDate.Date < StartDate.Date)
        {
            await DisplayAlert("Invalid", "The end date must come before start date.", "OK");
            return;
        }
        if (StatusPicker.SelectedItem == null)
        {
            await DisplayAlert("Invalid", "Must have a status selected.", "OK");
            return;
        }
        if (InstructorName.SelectedItem == null) 
        {
            await DisplayAlert("Invalid", "Must have an instructor selected.", "OK");
            return;
        }
        App.CourseData.AddCourse(new Course
        {
            Name = Name.Text,
            Description = Description.Text,
            StartDate = StartDate.Date,
            EndDate = EndDate.Date,
            InstructorId = this.InstructorId,
            Status = Course.GetStatusFromName(StatusPicker.Items[StatusPicker.SelectedIndex])
        }) ;
        await Navigation.PopAsync();
    }

}