using C971_MobileApp.Models;
using Plugin.LocalNotification;
using System.ComponentModel;

namespace C971_MobileApp;

public partial class AddEditNotifications : ContentPage
{
    public Course Course { get; set; }
    public Term Term { get; set; }
    public Assessment Assessment { get; set; }

    public AddEditNotifications(Course course)
	{
        Course = course;
		InitializeComponent();
        if (course.StartDateNotifications || course.EndDateNotifications)
        {
            StartDateToggle.IsToggled = course.StartDateNotifications;
            EndDateToggle.IsToggled = course.EndDateNotifications;
            StartDate.Date = course.StartDateNotifier.Date;
            StartTimeAlert.Time = course.StartDateNotifier.TimeOfDay;
            EndDate.Date = course.EndDateNotifier.Date;
            EndTimeAlert.Time = course.EndDateNotifier.TimeOfDay;
            return;
        }
        StartDateToggle.IsToggled = false;
        EndDateToggle.IsToggled = false;
        StartDate.Date = DateTime.Now;
        StartTimeAlert.Time = DateTime.Now.TimeOfDay;
        EndDate.Date = DateTime.Now;
        EndTimeAlert.Time = DateTime.Now.TimeOfDay;
    }
    public AddEditNotifications(Term term)
    {
        Term = term;
        InitializeComponent();
        if (term.StartDateNotifications || term.EndDateNotifications)
        {
            StartDateToggle.IsToggled = term.StartDateNotifications;
            EndDateToggle.IsToggled = term.EndDateNotifications;
            StartDate.Date = term.StartDateNotifier.Date;
            StartTimeAlert.Time = term.StartDateNotifier.TimeOfDay;
            EndDate.Date = term.EndDateNotifier.Date;
            EndTimeAlert.Time = term.EndDateNotifier.TimeOfDay;
            return;
        }
        StartDateToggle.IsToggled = false;
        EndDateToggle.IsToggled = false;
        StartDate.Date = DateTime.Now;
        StartTimeAlert.Time = DateTime.Now.TimeOfDay;
        EndDate.Date = DateTime.Now;
        EndTimeAlert.Time = DateTime.Now.TimeOfDay;
    }
    public AddEditNotifications(Assessment assessment)
    {

        Assessment = assessment;
        InitializeComponent();
        if (assessment.StartDateNotifications || assessment.EndDateNotifications)
        {
            StartDateToggle.IsToggled = assessment.StartDateNotifications;
            EndDateToggle.IsToggled = assessment.EndDateNotifications;
            StartDate.Date = assessment.StartDateNotifier.Date;
            StartTimeAlert.Time = assessment.StartDateNotifier.TimeOfDay;
            EndDate.Date = assessment.EndDateNotifier.Date;
            EndTimeAlert.Time = assessment.EndDateNotifier.TimeOfDay;
            return;
        }
        StartDateToggle.IsToggled = false;
        EndDateToggle.IsToggled = false;
        StartDate.Date = DateTime.Now;
        StartTimeAlert.Time = DateTime.Now.TimeOfDay;
        EndDate.Date = DateTime.Now;
        EndTimeAlert.Time = DateTime.Now.TimeOfDay;
    }
    private async void SetCourseNotifications()
    {
        Course.StartDateNotifier = StartDate.Date + StartTimeAlert.Time;
        Course.EndDateNotifier = EndDate.Date + EndTimeAlert.Time;
        Course.StartDateNotifications = StartDateToggle.IsToggled;
        Course.EndDateNotifications = EndDateToggle.IsToggled;
        App.CourseData.EditCourse(Course);
        if (StartDateToggle.IsToggled)
        {
            NotificationRequest startRequest = App.CourseData.SetStartNotifications(Course);
            await LocalNotificationCenter.Current.Show(startRequest);
        }
        if (EndDateToggle.IsToggled)
        {
            NotificationRequest endRequest = App.CourseData.SetEndNotifications(Course);
            await LocalNotificationCenter.Current.Show(endRequest);
        }
        await Navigation.PopAsync();
    }
    private async void SetTermNotifications()
    {
        Term.StartDateNotifier = StartDate.Date + StartTimeAlert.Time;
        Term.EndDateNotifier = EndDate.Date + EndTimeAlert.Time;
        Term.StartDateNotifications = StartDateToggle.IsToggled;
        Term.EndDateNotifications = EndDateToggle.IsToggled;
        App.TermData.EditTerm(Term);
        if (StartDateToggle.IsToggled)
        {
            NotificationRequest startRequest = App.TermData.SetStartNotifications(Term);
            await LocalNotificationCenter.Current.Show(startRequest);
        }
        if (EndDateToggle.IsToggled)
        {
            NotificationRequest endRequest = App.TermData.SetEndNotifications(Term);
            await LocalNotificationCenter.Current.Show(endRequest);
        }
        await Navigation.PopAsync();
    }
    private async void SetAssessmentNotifications()
    {
        Assessment.StartDateNotifier = StartDate.Date + StartTimeAlert.Time;
        Assessment.EndDateNotifier = EndDate.Date + EndTimeAlert.Time;
        Assessment.StartDateNotifications = StartDateToggle.IsToggled;
        Assessment.EndDateNotifications = EndDateToggle.IsToggled;
        App.AssessmentData.EditAssessment(Assessment);
        if (StartDateToggle.IsToggled)
        {
            NotificationRequest startRequest = App.AssessmentData.SetStartNotifications(Assessment);
            await LocalNotificationCenter.Current.Show(startRequest);
        }
        if (EndDateToggle.IsToggled)
        {
            NotificationRequest endRequest = App.AssessmentData.SetEndNotifications(Assessment);
            await LocalNotificationCenter.Current.Show(endRequest);
        }
        await Navigation.PopAsync();
    }
    public void SetNotifications(object sender, EventArgs e)
    {
        if (Course != null)
        { 
           SetCourseNotifications();
        }
        else if(Term != null)
        {
            SetTermNotifications();
        }
        else if(Assessment != null)
        {
            SetAssessmentNotifications();
        }
    }
}