using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;

public class WeHaveSharedThisWithTrainingProvidersPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "We've shared this with training providers";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

    private static By ManageYourTrainingRequest => By.LinkText("Manage your training requests");

    public FindApprenticeshipTrainingAndManageRequestsPage ReturnToRequestPage()
    {
        formCompletionHelper.Click(ManageYourTrainingRequest);

        return new(context);
    }
}