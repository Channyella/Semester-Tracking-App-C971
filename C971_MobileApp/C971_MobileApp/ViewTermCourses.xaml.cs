using C971_MobileApp.Models;
using Microsoft.Maui;
using System.Collections;
using System.Collections.ObjectModel;

namespace C971_MobileApp;

public partial class ViewTermCourses : ContentPage
{
	public int TermId { get; set; }
	public Term Term { get; set; }
	public ObservableCollection<Course> CourseList { get; set; } = new();
	public ViewTermCourses(int termId)
	{
		TermId = termId;
		this.Term = App.TermData.GetTermById(TermId);
		InitializeComponent();
        RefreshCourses();
    }
	public void ViewCourse(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		int buttonId = (int)button.BindingContext;
		Navigation.PushAsync(new CoursePage(buttonId));
	}
	public async void SetCourse1Btn(object sender, EventArgs e)
	{
        if (Course1.SelectedItem == null)
        {
            await DisplayAlert("Error","Need to select a class to set first.", "OK");
            return;
        }
        bool changeCourse = await DisplayAlert("Setting New Course", "Did you mean to set a new course?", "Yes", "No");
        if (changeCourse)
        {
            Term.Course1 = ((Course)Course1.SelectedItem).Id;
            App.TermData.EditTerm(Term);
            RefreshCourses();
        }
        else
        {
            return;
        }
	}
    public async void SetCourse2Btn(object sender, EventArgs e)
    {
        if (Course2.SelectedItem == null)
        {
            await DisplayAlert("Error", "Need to select a class to set first.", "OK");
            return;
        }
        bool changeCourse = await DisplayAlert("Setting New Course", "Did you mean to set a new course?", "Yes", "No");
        if (changeCourse)
        {
            Term.Course2 = ((Course)Course2.SelectedItem).Id;
            App.TermData.EditTerm(Term);
            RefreshCourses();
        }
        else { return; }
    }
    public async void SetCourse3Btn(object sender, EventArgs e)
    {
        if (Course3.SelectedItem == null)
        {
            await DisplayAlert("Error", "Need to select a class to set first.", "OK");
            return;
        }
        bool changeCourse = await DisplayAlert("Setting New Course", "Did you mean to set a new course?", "Yes", "No");
        if (changeCourse)
        {
            Term.Course3 = ((Course)Course3.SelectedItem).Id;
            App.TermData.EditTerm(Term);
            RefreshCourses();
        }
        else { return; }
    }
    public async void SetCourse4Btn(object sender, EventArgs e)
    {
        if (Course4.SelectedItem == null)
        {
            await DisplayAlert("Error", "Need to select a class to set first.", "OK");
            return;
        }
        bool changeCourse = await DisplayAlert("Setting New Course", "Did you mean to set a new course?", "Yes", "No");
        if (changeCourse)
        {
            Term.Course4 = ((Course)Course4.SelectedItem).Id;
            App.TermData.EditTerm(Term);
            RefreshCourses();
        }
        else { return; }
    }
        public async void SetCourse5Btn(object sender, EventArgs e)
        {
        if (Course5.SelectedItem == null)
        {
            await DisplayAlert("Error", "Need to select a class to set first.", "OK");
            return;
        }
        bool changeCourse = await DisplayAlert("Setting New Course", "Did you mean to set a new course?", "Yes", "No");
        if (changeCourse)
        {
            Term.Course5 = ((Course)Course5.SelectedItem).Id;
            App.TermData.EditTerm(Term);
            RefreshCourses();
        }
        else { return; }
    }
    public async void SetCourse6Btn(object sender, EventArgs e)
    {
        if (Course6.SelectedItem == null)
        {
            await DisplayAlert("Error", "Need to select a class to set first.", "OK");
            return;
        }
        bool changeCourse = await DisplayAlert("Setting New Course", "Did you mean to set a new course?", "Yes", "No");
        if (changeCourse)
        {
            Term.Course6 = ((Course)Course6.SelectedItem).Id;
            App.TermData.EditTerm(Term);
            RefreshCourses();
        }
        else {  return; }
    }
    public void EditCourse(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        int buttonId = (int)button.BindingContext;
        Navigation.PushAsync(new EditCourse(buttonId));
    }
    public async void DeleteCourse(object sender, EventArgs e)
    {
        bool changeCourse = await DisplayAlert("Deleting Course", "Are you sure you want to delete this course?", "Yes", "No");
        if (changeCourse) 
        { 
        ImageButton button = (ImageButton)sender;
            if (button.BindingContext.GetType() != typeof(int))
            {
                await DisplayAlert("Invalid", "No class is set to remove.", "OK");
                return;
            }
        App.CourseData.DeleteCourse((int)button.BindingContext);
        RefreshCourses();
        }     
    }
    public void NewCourse(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewCourse());
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshCourses();
    }

    private void RefreshCourses()
    {
        CourseList.Clear();
        List<Course> courseList = App.CourseData.GetAllCourses();
        foreach (Course course in courseList)
        {
            CourseList.Add(course);
        }
        if (CourseList.Any(course => course.Id == Term.Course1))
        {
            Course course1 = CourseList.Single(course => course.Id == Term.Course1);
            Course1.SelectedItem = course1;
            StartDateCourse1.Text = course1.StartDate.ToShortDateString();
            EndDateCourse1.Text = course1.EndDate.ToShortDateString();
            ViewDetails1.BindingContext = course1.Id;
            EditCourse1.BindingContext = course1.Id;
            DeleteCourse1.BindingContext = course1.Id;
        }
        else
        {
            StartDateCourse1.Text = string.Empty;
            EndDateCourse1.Text = string.Empty;
        }

        if (CourseList.Any(course => course.Id == Term.Course2))
        {
            Course course2 = CourseList.Single(course => course.Id == Term.Course2);
            Course2.SelectedItem = course2;
            StartDateCourse2.Text = course2.StartDate.ToShortDateString();
            EndDateCourse2.Text = course2.EndDate.ToShortDateString();
            ViewDetails2.BindingContext = course2.Id;
            EditCourse2.BindingContext = course2.Id;
            DeleteCourse2.BindingContext = course2.Id;
        }
        else
        {
            StartDateCourse2.Text = string.Empty;
            EndDateCourse2.Text = string.Empty;
        }
        if (CourseList.Any(course => course.Id == Term.Course3))
        {
            Course course3 = CourseList.Single(course => course.Id == Term.Course3);
            Course3.SelectedItem = course3;
            StartDateCourse3.Text = course3.StartDate.ToShortDateString();
            EndDateCourse3.Text = course3.EndDate.ToShortDateString();
            ViewDetails3.BindingContext = course3.Id;
            EditCourse3.BindingContext = course3.Id;
            DeleteCourse3.BindingContext = course3.Id;
        }
        else
        {
            StartDateCourse3.Text = string.Empty;
            EndDateCourse3.Text = string.Empty;
        }
        if (CourseList.Any(course => course.Id == Term.Course4))
        {
            Course course4 = CourseList.Single(course => course.Id == Term.Course4);
            Course4.SelectedItem = course4;
            StartDateCourse4.Text = course4.StartDate.ToShortDateString();
            EndDateCourse4.Text = course4.EndDate.ToShortDateString();
            ViewDetails4.BindingContext = course4.Id;
            EditCourse4.BindingContext = course4.Id;
            DeleteCourse4.BindingContext = course4.Id;
        }
        else
        {
            StartDateCourse4.Text = string.Empty;
            EndDateCourse4.Text = string.Empty;
        }
        if (CourseList.Any(course => course.Id == Term.Course5))
        {
            Course course5 = CourseList.Single(course => course.Id == Term.Course5);
            Course5.SelectedItem = course5;
            StartDateCourse5.Text = course5.StartDate.ToShortDateString();
            EndDateCourse5.Text = course5.EndDate.ToShortDateString();
            ViewDetails5.BindingContext = course5.Id;
            EditCourse5.BindingContext = course5.Id;
            DeleteCourse5.BindingContext = course5.Id;
        }
        else
        {
            StartDateCourse5.Text = string.Empty;
            EndDateCourse5.Text = string.Empty;
        }
        if (CourseList.Any(course => course.Id == Term.Course6))
        {
            Course course6 = CourseList.Single(course => course.Id == Term.Course6);
            Course6.SelectedItem = course6;
            StartDateCourse6.Text = course6.StartDate.ToShortDateString();
            EndDateCourse6.Text = course6.EndDate.ToShortDateString();
            ViewDetails6.BindingContext = course6.Id;
            EditCourse6.BindingContext = course6.Id;
            DeleteCourse6.BindingContext = course6.Id;
        }
        else
        {
            StartDateCourse6.Text = string.Empty;
            EndDateCourse6.Text = string.Empty;
        }
    }
}