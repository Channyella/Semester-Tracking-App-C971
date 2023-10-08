namespace C971_MobileApp;

public partial class AddInstructor : ContentPage
{
	public AddInstructor()
	{
		InitializeComponent();
	}

	public async void AddInstructorButton(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Email.Text) || string.IsNullOrWhiteSpace(PhoneNumber.Text))
		{
		await DisplayAlert("Invalid", "There are blank fields. Please fill in before continuing.", "Cancel");
		}
		else
		{
			App.InstructorData.AddInstructor(new Instructor
			{
				Name = Name.Text,
				Email = Email.Text,
				PhoneNumber = PhoneNumber.Text,
			});
        }
        await Navigation.PushAsync(new Instructors());
    }
	
}