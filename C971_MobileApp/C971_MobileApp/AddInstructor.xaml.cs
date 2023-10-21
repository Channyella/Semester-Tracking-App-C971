namespace C971_MobileApp;

public partial class AddInstructor : ContentPage
{
	public AddInstructor()
	{
		InitializeComponent();
	}

	public void AddInstructorButton(object sender, EventArgs e)
	{
        if (nameValidator.IsNotValid)
        {
            DisplayAlert("Error", "Name is required.", "OK");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                DisplayAlert("Error", error.ToString(), "OK");
            }
            return;
        }
        if (phoneValidator.IsNotValid)
        {
            DisplayAlert("Error", "Phone number is required in correct format. XXX-XXX-XXXX", "OK");
            return;
        }
        {
			App.InstructorData.AddInstructor(new Instructor
			{
				Name = Name.Text,
				Email = Email.Text,
				PhoneNumber = PhoneNumber.Text,
			});
        }
        Navigation.PopAsync();
    }
	
}