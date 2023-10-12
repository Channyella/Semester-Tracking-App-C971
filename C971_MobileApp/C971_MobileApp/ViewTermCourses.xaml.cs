using C971_MobileApp.Models;

namespace C971_MobileApp;

public partial class ViewTermCourses : ContentPage
{
	public int TermId { get; set; }
	public Term Term { get; set; }
	public ViewTermCourses(int termId)
	{
		TermId = termId;
		InitializeComponent();
	}
	public ViewTermCourses()
	{
        InitializeComponent();
    }
}