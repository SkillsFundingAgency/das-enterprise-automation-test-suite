namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderAddStandardSteps(ScenarioContext context)
{

    //this step is used to add test data (standard) to the provider. Should not be used in the regression tests
    [Then(@"provider can add standards to its list of standards offered")]
    public void ProviderCanAddStandardsToItsListOfStandardsOffered()
    {
        var _providerManageTheStandardsYouDeliverPage = new ManagingStandardsProviderHomePage(context).NavigateToYourStandardsAndTrainingVenuesPage().AccessStandards();

        for (int i = 0; i < 1; i++)
        {
            _providerManageTheStandardsYouDeliverPage = AddStandard(_providerManageTheStandardsYouDeliverPage);
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

