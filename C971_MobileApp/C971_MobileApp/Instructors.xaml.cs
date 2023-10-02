using C971_MobileApp.Models;
using C971_MobileApp.Data;
using System.Collections.ObjectModel;

namespace C971_MobileApp;

public partial class Instructors : ContentPage
{
	public InstructorData database = new();
	public ObservableCollection<Instructor> InstructorData { get; set; } = new();

	public Instructors()
	{
		InitializeComponent();

		foreach(Instructor instructor in database.instructorsList)
		{
			InstructorData.Add(instructor);
		}

	}
}