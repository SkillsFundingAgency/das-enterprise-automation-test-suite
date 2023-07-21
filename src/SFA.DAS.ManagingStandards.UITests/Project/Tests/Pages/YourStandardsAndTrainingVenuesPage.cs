namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class YourStandardsAndTrainingVenuesPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Your standards and training venues";

    public YourStandardsAndTrainingVenuesPage(ScenarioContext context) : base(context) { }

    public TrainingVenuesPage AccessTrainingLocations()
    {
        formCompletionHelper.ClickLinkByText("Training venues");
        return new TrainingVenuesPage(context);
    }

    public ManageTheStandardsYouDeliverPage AccessStandards()
    {
        formCompletionHelper.ClickLinkByText("The standards you deliver");
        return new ManageTheStandardsYouDeliverPage(context);
    }

    public TrainingProviderOverviewPage AccessProviderOverview()
    {
        formCompletionHelper.ClickLinkByText("Provider overview");
        return new TrainingProviderOverviewPage(context);
    }
}

