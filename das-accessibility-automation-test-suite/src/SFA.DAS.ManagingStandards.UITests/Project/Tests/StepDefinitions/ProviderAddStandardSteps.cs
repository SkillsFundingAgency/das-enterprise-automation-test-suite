using Polly;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderAddStandardSteps(ScenarioContext context)
{
    private ProviderHomePageStepsHelper providerHomePageStepsHelper;

    //this step is used to add test data (standard) to the provider. Should not be used in the regression tests
    [Then(@"provider can add standards to its list of standards offered")]
    public void ProviderCanAddStandardsToItsListOfStandardsOffered()
    {
        providerHomePageStepsHelper = new ProviderHomePageStepsHelper(context);

        var _providerManageTheStandardsYouDeliverPage = new ManagingStandardsProviderHomePage(context).NavigateToYourStandardsAndTrainingVenuesPage().AccessStandards();

        for (int i = 0; i < 500; i++)
        {
            _providerManageTheStandardsYouDeliverPage = AddStandard(_providerManageTheStandardsYouDeliverPage);
            
            if (i % 20 == 0) 
            {
                providerHomePageStepsHelper.GoToProviderHomePage(false);
                _providerManageTheStandardsYouDeliverPage = new ManagingStandardsProviderHomePage(context).NavigateToYourStandardsAndTrainingVenuesPage().AccessStandards();
            }
        }
    }

    private static ManageTheStandardsYouDeliverPage AddStandard(ManageTheStandardsYouDeliverPage page)
    {
        var a = page.AccessAddStandard().AddFirstStandard();

        var addAstandardPage = a.addAstandardPage;

        return addAstandardPage.YesStandardIsCorrectAndContinue()
            .Add_ContactInformation()
            .ConfirmAtAnEmployersLocation()
            .YesDeliverAnyWhereInEngland(a.standardName)
            .Save_NewStandard_Continue();
    }
}

