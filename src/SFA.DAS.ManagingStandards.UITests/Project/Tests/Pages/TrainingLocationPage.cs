namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingLocationPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Training locations";

    public TrainingLocationPage(ScenarioContext context) : base(context) { }

    public ReviewYourDetailsPage NavigateBackToReviewYourDetails()
    {
        formCompletionHelper.Click(BackLink);
        return new ReviewYourDetailsPage(context);
    }
}
