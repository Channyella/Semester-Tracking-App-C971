using C971_MobileApp.Models;
using System.Collections.ObjectModel;

namespace C971_MobileApp;

public partial class Terms : ContentPage
{
	public Term Term { get; set; }
    public ObservableCollection<Term> TermData { get; set; } = new();
	public Terms()
	{
		InitializeComponent();
        RefreshTerms();
	}
	public void AddTermButton(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AddTerm());
	}
	public void ViewCourses(object sender, EventArgs e)
	{
		Button button = (Button)sender;

		int buttonId = (int)button.BindingContext;

		Navigation.PushAsync(new ViewTermCourses(buttonId));
	}
    public async void DeleteTerm(object sender, EventArgs e)
    {
        bool deleteTerm = await DisplayAlert("Delete Term", "Are you sure you want to delete this term?", "Yes", "No");
        if (deleteTerm)
        {
            ImageButton button = (ImageButton)sender;
            App.TermData.DeleteTerm((int)button.BindingContext);
            RefreshTerms();
        }
    }
    public void EditTerm(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;

        int buttonId = (int)button.BindingContext;

        Navigation.PushAsync(new EditTerm(buttonId));
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshTerms();
    }
    private void RefreshTerms()
    {   
            TermData.Clear();
            List<Term> termList = App.TermData.GetAllTerms();
            foreach (Term term in termList)
            {
                TermData.Add(term);
            }
    }
    public void OneActiveTermOnly (object sender, ToggledEventArgs e)
    {
        Switch switchEl = (Switch)sender;
        Term term = (Term)switchEl.BindingContext;
        if(e.Value)
        {
            App.TermData.ActivateTerm(term);
            foreach (Term currTerm in TermData)
            {
                currTerm.Active = (currTerm.Id == term.Id);
            }
            updateSwitches();
        } else
        {
            term.Active = false;
            App.TermData.EditTerm(term);
        }
    }

    private void updateSwitches()
    {
        IReadOnlyList<IVisualTreeElement> allDescendantsOfTermCollection = TermCollection.GetVisualTreeDescendants();
        IEnumerable<Switch> termSwitches = allDescendantsOfTermCollection.OfType<Switch>();
        foreach (Switch termSwitch in termSwitches) {
            Term term = (Term)termSwitch.BindingContext;
            termSwitch.IsToggled = term.Active;
        }
    }
}