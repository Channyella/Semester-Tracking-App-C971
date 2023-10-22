using C971_MobileApp.Models;
using Plugin.LocalNotification;

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
        StartDateToggle.IsToggled = course.StartDateNotifications;
        EndDateToggle.IsToggled = course.EndDateNotifications;
        StartDate.Date = course.StartDateNotifier.Date;
        StartTimeAlert.Time = course.StartDateNotifier.TimeOfDay;
        EndDate.Date = course.EndDateNotifier.Date;
        EndTimeAlert.Time = course.EndDateNotifier.TimeOfDay;
	}
    public AddEditNotifications(Term term)
    {
        Term = term;
        InitializeComponent();
    }
    public AddEditNotifications(Assessment assessment)
    {
        Assessment = assessment;
        InitializeComponent();
        StartDateToggle.IsToggled = assessment.StartDateNotifications;
        EndDateToggle.IsToggled = assessment.EndDateNotifications;
        StartDate.Date = assessment.StartDateNotifier.Date;
        StartTimeAlert.Time = assessment.StartDateNotifier.TimeOfDay;
        EndDate.Date = assessment.EndDateNotifier.Date;
        EndTimeAlert.Time = assessment.EndDateNotifier.TimeOfDay;
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
        if (StartDateToggle.IsToggled)
        {
            NotificationRequest endRequest = App.CourseData.SetEndNotifications(Course);
            await LocalNotificationCenter.Current.Show(endRequest);
        }
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
        if (StartDateToggle.IsToggled)
        {
            NotificationRequest endRequest = App.TermData.SetEndNotifications(Term);
            await LocalNotificationCenter.Current.Show(endRequest);
        }
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
        if (StartDateToggle.IsToggled)
        {
            NotificationRequest endRequest = App.AssessmentData.SetEndNotifications(Assessment);
            await LocalNotificationCenter.Current.Show(endRequest);
        }
    }
    private async void SetNotifications(object sender, EventArgs e)
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
        await Navigation.PopAsync();

    }
}