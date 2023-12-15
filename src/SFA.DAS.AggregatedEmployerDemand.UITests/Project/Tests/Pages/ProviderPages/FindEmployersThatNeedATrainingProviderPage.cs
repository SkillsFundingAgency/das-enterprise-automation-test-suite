namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;

public class FindEmployersThatNeedATrainingProviderPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "Find employers that need a training provider";

    private static By FindEmployersThatNeedATrainingProviderLink => By.LinkText("Find employers that need a training provider");

    public FindEmployersThatNeedATrainingProviderPage ViewFindEmployersThatNeedATrainingProvider()
    {
        formCompletionHelper.ClickElement(FindEmployersThatNeedATrainingProviderLink);
        return new FindEmployersThatNeedATrainingProviderPage(context);
    }

    public WhichEmployersAreYouInterestedInPage ViewWhichEmployerNeedsATrainingProvider()
    {
        /*Select the First ViewEmployers Link*/
        formCompletionHelper.ClickLinkByText("View employers");

        return new WhichEmployersAreYouInterestedInPage(context);
    }
}
