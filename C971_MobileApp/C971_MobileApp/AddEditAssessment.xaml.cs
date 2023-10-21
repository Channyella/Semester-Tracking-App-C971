using C971_MobileApp.Models;
using CommunityToolkit.Maui.Converters;
using Microsoft.VisualBasic;

namespace C971_MobileApp;

public partial class AddEditAssessment : ContentPage
{
	public Assessment Assessment { get; set; }
	public Course Course { get; set; }
	public bool isOA { get; set; }
    public DatePicker DueDate;
	public DatePicker SelectedEndDate;
    public AddEditAssessment(Course course, bool isOA)
	{
		Course = course;
		this.isOA = isOA;
        DueDate = new DatePicker
        {
            Date = course.EndDate.Date
        };
        SelectedEndDate = new DatePicker
        {
            Date = course.EndDate.Date
        };
        InitializeComponent();
        if (isOA)
        {
            assessmentType.Text = "Objective Assessment";
        }
        else
        {
            assessmentType.Text = "Performance Assessment";
        }
        EndDate.Date = SelectedEndDate.Date;
        DueDateField.Date = DueDate.Date;

    }
	public AddEditAssessment(Assessment assessment)
	{   this.Assessment = assessment;
		InitializeComponent();
		assessmentName.Text = assessment.Name;
		assessmentType.Text = assessment.TypeName == Models.Type.ObjectiveAssessment ? "Objective Assessment" : "Performance Assessment";
		StartDate.Date = assessment.startDate.Date;
		EndDate.Date = assessment.endDate.Date;
		DueDateField.Date = assessment.dueDate.Date;
	}
    public DatePicker SelectedStartDate = new DatePicker
    {
        Date = DateTime.Now
    };
 
	public async void EditAssessment(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(assessmentName.Text))
		{
			await DisplayAlert("Invalid", "Assessment Name is required.", "OK");
			return;
		}
        if (DueDateField.Date < StartDate.Date || EndDate.Date < StartDate.Date 
			|| DueDateField.Date < EndDate.Date )
        {
			await DisplayAlert("Invalid", "End date of assessment must be after the starting date. However, due to multiple attempt allowance, end date can be before or the same as due date.", "OK");
			return;
        }
		if (this.Assessment == null)
		{
            Assessment newAssessment = App.AssessmentData.AddAssessment(new Assessment
            {
                Name = assessmentName.Text,
                TypeName = isOA ? Models.Type.ObjectiveAssessment : Models.Type.PerformanceAssessment,
                startDate = StartDate.Date,
                endDate = EndDate.Date,
                dueDate = DueDateField.Date
            });
            if (isOA)
            {
                Course.ObjectiveAssessment = newAssessment.Id;
            }
            else
            {
                Course.PerformanceAssessment = newAssessment.Id;
            }
            App.CourseData.EditCourse(Course);
        }
        else
        {
            this.Assessment.Name = assessmentName.Text;
            this.Assessment.startDate = StartDate.Date;
            this.Assessment.endDate = EndDate.Date;
            this.Assessment.dueDate = DueDateField.Date;
            App.AssessmentData.EditAssessment(this.Assessment);
        }

        await Navigation.PopAsync();
	}
}
