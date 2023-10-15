using C971_MobileApp.Models;
using System.Collections.ObjectModel;

namespace C971_MobileApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Term> TermData { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            List<Term> termData = App.TermData.GetAllTerms();
            foreach(Term term in termData)
            {
                TermData.Add(term);
            }
        }

    }
}