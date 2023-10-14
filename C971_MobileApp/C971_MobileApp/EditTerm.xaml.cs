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
    }
    public void EditTermButton(object sender, EventArgs e)
    {
        App.TermData.EditTerm(new Term
        {
            Id = this.TermId,
            Name = Name.Text,
            StartDate = StartDate.Date,
            EndDate = EndDate.Date,
        });

        Navigation.PushAsync(new Terms());
    }
}