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
    public void DeleteTerm(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        App.TermData.DeleteTerm((int)button.BindingContext);
        RefreshTerms();
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
}