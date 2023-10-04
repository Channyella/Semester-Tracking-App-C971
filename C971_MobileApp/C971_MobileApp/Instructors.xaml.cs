using C971_MobileApp.Models;
using C971_MobileApp.Data;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace C971_MobileApp;

public partial class Instructors : ContentPage
{
	public ObservableCollection<Instructor> InstructorData { get; set; } = new();

	public Instructors()
	{
		InitializeComponent();
	}

	public void AddInstructor(object sender, EventArgs e)
	{
		Button button = (Button)sender;

		Navigation.PushAsync(new AddInstructor());
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<Instructor> instructorList = App.InstructorData.GetInstructors();
        foreach (Instructor instructor in instructorList)
        {
            InstructorData.Add(instructor);
        }
    }
}