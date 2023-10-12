using C971_MobileApp.Models;

namespace C971_MobileApp;

public partial class AddTerm : ContentPage
{

	public AddTerm()
	{
		InitializeComponent();
	}
    public DatePicker SelectedStartDate = new DatePicker
    {
        Date = DateTime.Now
    };

    public DatePicker SelectedEndDate = new DatePicker
    {
        Date = DateTime.Now
    };
    public async void AddTermButton(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Name.Text))
        {
            await DisplayAlert("Invalid", "There are blank fields. Please fill in before continuing.", "Okay");
            return;
        }
        Term TermInfo = App.TermData.AddTerm(new Term
        {
            Name = Name.Text,
            StartDate = StartDate.Date,
            EndDate = EndDate.Date,
        });
        await Navigation.PushAsync(new Terms());
    }

}