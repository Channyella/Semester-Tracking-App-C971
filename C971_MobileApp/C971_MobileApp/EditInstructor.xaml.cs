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
        App.InstructorData.EditInstructor(new Instructor
        {
            Id = this.InstructorId,
            Name = Name.Text,
            Email = Email.Text,
            PhoneNumber = PhoneNumber.Text,
        });

        Navigation.PushAsync(new Instructors());
    }
}