using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;

public class CancelYourRequestPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Cancel your request";

    private static By CancelButton => By.CssSelector("#main-content button.govuk-button[type='submit']");

    public WeCancelledYourRequestPage SubmitCancelRequest()
    {
        formCompletionHelper.Click(CancelButton);

        return new(context);
    }
}