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
            await DisplayAlert("Invalid", "Name is required.", "OK");
            return;
        }
        if (EndDate.Date < StartDate.Date)
        {
            await DisplayAlert("Invalid", "End date must be after start date.", "OK");
            return;
        }
        Term TermInfo = App.TermData.AddTerm(new Term
        {
            Name = Name.Text,
            StartDate = StartDate.Date,
            EndDate = EndDate.Date,
            Active = ActiveSwitch.IsToggled
        }) ;
        await Navigation.PopAsync();
    }

}