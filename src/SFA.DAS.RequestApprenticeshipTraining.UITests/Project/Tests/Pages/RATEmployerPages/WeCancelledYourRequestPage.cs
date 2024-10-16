using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;

public class WeCancelledYourRequestPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "We've cancelled your request";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
}