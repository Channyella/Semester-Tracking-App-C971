using C971_MobileApp.Models;
using C971_MobileApp.Data;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace C971_MobileApp;

public partial class Instructors : ContentPage
{
	List<Instructor> instructorList = App.InstructorData.GetInstructors();
	public ObservableCollection<Instructor> InstructorData { get; set; } = new();

	public Instructors()
	{
		InitializeComponent();
	}

	// Sends user to the Add Instructor page to fill out information
	public void AddInstructor(object sender, EventArgs e)
	{
		Button button = (Button)sender;

		Navigation.PushAsync(new AddInstructor());
	}
	// Deletes user from the SQLite Database
	public void DeleteInstructor(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		App.InstructorData.DeleteInstructor((int)button.BindingContext);
		RefreshInstructors();
	}

	// Sends user to the Edit Instructor Page but also passes the Id.
	public void EditInstructor(object sender, EventArgs e)
	{
		Button button = (Button)sender;

		int buttonId = (int)button.BindingContext;

		Navigation.PushAsync(new EditInstructor(buttonId));
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
}