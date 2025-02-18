using C971_MobileApp.Models;
using C971_MobileApp.Data;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using static C971_MobileApp.Models.Course;

namespace C971_MobileApp;

public partial class Instructors : ContentPage
{
	public ObservableCollection<Instructor> InstructorData { get; set; } = new();

	public Instructors()
	{
		InitializeComponent();
	}

	// Sends user to the Add Instructor page to fill out information
	public void AddInstructor(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AddInstructor());
	}
	// Deletes user from the SQLite Database
	public async void DeleteInstructor(object sender, EventArgs e)
	{
        ImageButton button = (ImageButton)sender;
		int instructorId = (int)button.BindingContext;
		List<Course> courseList = App.CourseData.GetCoursesByInstructorId(instructorId);
		if (courseList.Count > 0)
		{
			await DisplayAlert("Cannot Delete Instructor", "Please delete courses or reassign them to different instructors before deleting this instructor.", "OK");
			return;
		}
        bool deleteInstructor = await DisplayAlert("Delete Instructor", "Are you sure that you want to delete this instructor?", "Yes", "No");
		if (deleteInstructor)
		{
			App.InstructorData.DeleteInstructor(instructorId);
			RefreshInstructors();
		}
	}

	// Sends user to the Edit Instructor Page but also passes the Id.
	public void EditInstructor(object sender, EventArgs e)
	{
		ImageButton button = (ImageButton)sender;

		int buttonId = (int)button.BindingContext;

		Navigation.PushAsync(new EditInstructor(buttonId));
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
        RefreshInstructors();
    }

    protected override void OnAppearing()
	{
		base.OnAppearing();
		RefreshInstructors();
	}

	private void RefreshInstructors()
	{
		InstructorData.Clear();
        List<Instructor> instructorList = App.InstructorData.GetInstructors();
        foreach (Instructor instructor in instructorList)
        {
            InstructorData.Add(instructor);
        }
    }

    private void ViewClass(object sender, EventArgs e)
    {
		Button button = (Button)sender;

        int buttonId = (int)button.BindingContext;

        Navigation.PushAsync(new ViewInstructorCourses(buttonId));
    }
}