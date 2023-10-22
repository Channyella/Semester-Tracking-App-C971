using C971_MobileApp.Models;
using Plugin.LocalNotification;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace C971_MobileApp;

public partial class CoursePage : ContentPage
{
	public int CourseId { get; set; }
    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
    public Assessment Assessment { get; set; }

    public CoursePage(int courseId)
	{
		CourseId = courseId;
		InitializeComponent();
        Course = App.CourseData.GetCourseById(courseId);
        Name.Text = Course.Name;
        Description.Text = Course.Description;
        StartDate.Date = Course.StartDate;
        EndDate.Date = Course.EndDate;
        Instructor instructor = App.InstructorData.GetInstructorById(Course.InstructorId);
        InstructorName.Text = instructor.Name;
        InstructorEmail.Text = instructor.Email;
        InstructorPhoneNumber.Text = instructor.PhoneNumber;
        ActiveSwitch.IsToggled = Course.Status;
        EditCourseBtn.BindingContext = Course.Id;
        Notes.Text = Course.CourseNotes;
        StartDateNotifications.IsToggled = Course.StartDateNotifications;
        EndDateNotifications.IsToggled = Course.EndDateNotifications;
        Assessment OAObj = App.AssessmentData.GetAssessmentById(Course.ObjectiveAssessment);
        OAStartNotificationBtn.IsToggled = OAObj.StartDateNotifications;
        OAEndNotificationBtn.IsToggled = OAObj.EndDateNotifications;
        Assessment PAObj = App.AssessmentData.GetAssessmentById(Course.PerformanceAssessment);
        PAStartNotificationBtn.IsToggled = PAObj.StartDateNotifications;
        PAEndNotificationBtn.IsToggled = PAObj.EndDateNotifications;

        RefreshAssessments();

    }
    public void EditCourse(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        int buttonId = (int)button.BindingContext;

        Navigation.PushAsync(new EditTerm(buttonId));
    }
    public void EditCourseNotifications(object sender, EventArgs e)
    {
        Course thisCourse = this.Course;
        Navigation.PushAsync(new AddEditNotifications(thisCourse));
    }
    public void EditOANotifications(object sender, EventArgs e)
    {
        int OAId = this.Course.ObjectiveAssessment;
        Assessment OAObj = App.AssessmentData.GetAssessmentById(OAId);
        Navigation.PushAsync(new AddEditNotifications(OAObj));
    }
    public void EditPANotifications(object sender, EventArgs e)
    {
        int PAId = this.Course.PerformanceAssessment;
        Assessment PAObj = App.AssessmentData.GetAssessmentById(PAId);
        Navigation.PushAsync(new AddEditNotifications(PAObj));
    }
    public void ShareCourseNotes(object sender, EventArgs e)
    {
        DisplayAlert("Saved Notes", "Notes have been saved.","OK");
        Share.Default.RequestAsync(new ShareTextRequest(Notes.Text, "Share Course Notes"));
    }
    public void SaveNotes(object sender, EventArgs e)
    {
        Course.CourseNotes = Notes.Text;
        App.CourseData.EditCourse(Course);
    }

    public void EditOA(object sender, EventArgs e)
    {
        List<Assessment> assessmentList = App.AssessmentData.GetAllAssessments();
        if (assessmentList.Any(assessment => assessment.Id == Course.ObjectiveAssessment))
        {
            Assessment OA = assessmentList.Single(assessment => assessment.Id == Course.ObjectiveAssessment);
            Navigation.PushAsync(new AddEditAssessment(OA));
            return;
        }
        bool isOA = true;
        Navigation.PushAsync(new AddEditAssessment(Course, isOA));
    }
    public void EditPA(object sender, EventArgs e)
    {
        List<Assessment> assessmentList = App.AssessmentData.GetAllAssessments();
        if (assessmentList.Any(assessment => assessment.Id == Course.PerformanceAssessment))
        {
            Assessment PA = assessmentList.Single(assessment => assessment.Id == Course.PerformanceAssessment);
            Navigation.PushAsync(new AddEditAssessment(PA));
            return;
        }
        bool isOA = false;
        Navigation.PushAsync(new AddEditAssessment(Course, isOA));
    }

    public async void DeleteOA(object sender, EventArgs e)
    {
        bool deleteOA = await DisplayAlert("Delete OA", "Are you sure you want to delete this objective assessment?", "Yes", "No");
        if (deleteOA)
        {
            App.AssessmentData.DeleteAssessment(Course.ObjectiveAssessment);
            RefreshAssessments();
        }
    }
    public async void DeletePA(object sender, EventArgs e)
    {
        bool deletePA = await DisplayAlert("Delete PA", "Are you sure you want to delete this performance assessment?", "Yes", "No");
        if (deletePA)
        {
            App.AssessmentData.DeleteAssessment(Course.PerformanceAssessment);
            RefreshAssessments();
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshAssessments();
    }
    private void RefreshAssessments()
    {
        List<Assessment> assessmentList = App.AssessmentData.GetAllAssessments();
        if (assessmentList.Any(assessment => assessment.Id == Course.ObjectiveAssessment))
        {
            Assessment assessmentOA = assessmentList.Single(assessment => assessment.Id == Course.ObjectiveAssessment);
            ObjectiveAssessment.Text = assessmentOA.Name;
            StartDateOA.Text = assessmentOA.startDate.ToShortDateString();
            EndDateOA.Text = assessmentOA.endDate.ToShortDateString();
            DueDateOA.Text = assessmentOA.dueDate.ToShortDateString();
        } else
        {
            ObjectiveAssessment.Text = string.Empty;
            StartDateOA.Text = string.Empty; 
            EndDateOA.Text = string.Empty;
            DueDateOA.Text = string.Empty;
        }
        if (assessmentList.Any(assessment => assessment.Id == Course.PerformanceAssessment))
        {
            Assessment assessmentPA = assessmentList.Single(assessment => assessment.Id == Course.PerformanceAssessment);
            PerformanceAssessment.Text = assessmentPA.Name;
            StartDatePA.Text = assessmentPA.startDate.ToShortDateString();
            EndDatePA.Text = assessmentPA.endDate.ToShortDateString();
            DueDatePA.Text = assessmentPA.dueDate.ToShortDateString();
        } else
        {
            PerformanceAssessment.Text = string.Empty;
            StartDatePA.Text = string.Empty;
            EndDatePA.Text = string.Empty; 
            DueDatePA.Text = string.Empty;
        }

    }

}