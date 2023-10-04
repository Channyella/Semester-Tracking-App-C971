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

		foreach(Instructor instructor in App.InstructorData.GetInstructors())
		{
			InstructorData.Add(instructor);
		}
	}

	public void AddInstructor(object sender, EventArgs e)
	{
		Button button = (Button)sender;

		Navigation.PushAsync(new AddInstructor());
	}
}