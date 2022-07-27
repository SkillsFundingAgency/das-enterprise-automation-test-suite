namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingLocationPage : VerifyBasePage
{
    protected override string PageTitle => "Training locations";

    public TrainingLocationPage(ScenarioContext context) : base(context) => VerifyPage();

    public ReviewYourDetailsPage NavigateBackToReviewYourDetails()
    {
        formCompletionHelper.Click(BackLink);
        return new ReviewYourDetailsPage(context);
    }

}
