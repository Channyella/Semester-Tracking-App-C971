namespace C971_MobileApp;

public partial class AddEditAssessment : ContentPage
{
	public int Id { get; set; }
	public AddEditAssessment(int id)
	{
		Id = id;
		InitializeComponent();
	}
}