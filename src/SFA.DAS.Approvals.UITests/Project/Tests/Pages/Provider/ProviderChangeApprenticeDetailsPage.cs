using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChangeApprenticeDetailsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Change apprentice details";

        private static By DoYouWantToRequestChangesOptions => By.XPath("(//input[@class='govuk-radios__input'])[1]");
        private static By FinishButton => By.XPath("(//button[@type='submit'])[2]");

        internal ProviderApprenticeDetailsPage ConfirmRequestToFixILRMismatch()
        {
            javaScriptHelper.ClickElement(DoYouWantToRequestChangesOptions);
            formCompletionHelper.ClickElement(FinishButton);
            return new ProviderApprenticeDetailsPage(context);
        }
    }
}