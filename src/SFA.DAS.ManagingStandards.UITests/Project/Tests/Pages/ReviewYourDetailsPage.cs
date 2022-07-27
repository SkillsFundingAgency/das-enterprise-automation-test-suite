namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ReviewYourDetailsPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Review your details";

    public ReviewYourDetailsPage(ScenarioContext context) : base(context) { }

    public TrainingLocationPage AccessTrainingLocations()
    {
        formCompletionHelper.ClickLinkByText("Training locations");
        return new TrainingLocationPage(context);
    }

    public ManageTheStandardsYouDeliverPage AccessStandards()
    {
        formCompletionHelper.ClickLinkByText("Standards");
        return new ManageTheStandardsYouDeliverPage(context);
    }

}

