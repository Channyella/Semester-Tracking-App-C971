namespace C971_MobileApp;

public partial class EditInstructor : ContentPage
{
    private int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
	public EditInstructor(int InstructorId)
	{
        this.InstructorId = InstructorId;
		InitializeComponent();
        Instructor = App.InstructorData.GetInstructorById(this.InstructorId);
        Name.Text = Instructor.Name;
        Email.Text = Instructor.Email;
        PhoneNumber.Text = Instructor.PhoneNumber;
	}
    public void EditInstructorButton(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            DisplayAlert("Error", "Name is required.", "OK");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            foreach(var error in emailValidator.Errors)
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
        App.InstructorData.EditInstructor(new Instructor
        {
            Id = this.InstructorId,
            Name = Name.Text,
            Email = Email.Text,
            PhoneNumber = PhoneNumber.Text,
        });

        Navigation.PopAsync();
    }
}