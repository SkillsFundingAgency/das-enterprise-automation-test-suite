using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;

public class ProviderAddStandardStepsHelper
{
    private readonly ProviderStepsHelper _providerStepsHelper;

    public ProviderAddStandardStepsHelper(ScenarioContext context) => _providerStepsHelper = new ProviderStepsHelper(context);

    public ProviderManageTheStandardsYouDeliverPage GoToManageStandardPage()
    {
        return _providerStepsHelper.GoToProviderHomePage().GoToYourStandardsAndTrainingVenues().ClickOnTheStandardsYouDeliverLink();
    }

    public ProviderManageTheStandardsYouDeliverPage AddStandard(ProviderManageTheStandardsYouDeliverPage page, bool firstStandard)
    {
        var a = page.ClickAddAStandardLink();

        var b = firstStandard ? a.AddFirstStandard() : a.AddStandard();

        return b.ConfirmStandard()
            .AddContactInfo()
            .SelectOptionAtEmployerLocation()
            .SelectOptionICanDeliverAnywhereInEngland()
            .SaveStandard();
    }

}

