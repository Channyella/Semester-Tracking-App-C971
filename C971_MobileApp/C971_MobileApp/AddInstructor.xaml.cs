namespace C971_MobileApp;

public partial class AddInstructor : ContentPage
{
	public AddInstructor()
	{
		InitializeComponent();
	}

	public void AddInstructorButton(object sender, EventArgs e)
	{
		App.InstructorData.AddInstructor(new Instructor
		{
			Name = Name.Text,
			Email = Email.Text,
			PhoneNumber = PhoneNumber.Text,
		});
        Button button = (Button)sender;

        Navigation.PushAsync(new Instructors());
    }
	
}