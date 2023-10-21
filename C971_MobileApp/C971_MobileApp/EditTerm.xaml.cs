using C971_MobileApp.Models;

namespace C971_MobileApp;

public partial class EditTerm : ContentPage
{
	public int TermId { get; set; }
	public Term Term { get; set; }

    public EditTerm(int termId)
    {
        this.TermId = termId;
        InitializeComponent();
        Term = App.TermData.GetTermById(this.TermId);
        Name.Text = Term.Name;
        StartDate.Date = Term.StartDate;
        EndDate.Date = Term.EndDate;
        ActiveSwitch.IsToggled = Term.Active;
    }
    public async void EditTermButton(object sender, EventArgs e)
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
        App.TermData.EditTerm(new Term
        {
            Id = this.TermId,
            Name = Name.Text,
            StartDate = StartDate.Date,
            EndDate = EndDate.Date,
            Active = ActiveSwitch.IsToggled
        }); ;

        await Navigation.PopAsync();
    }
}