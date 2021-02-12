using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideReceivedDetailsPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "We have received your details";
        protected override By PageHeader => By.XPath("//h1[text()='We have received your details']");

        #region Locators
        private readonly ScenarioContext _context;
        private By CaseIdSummary => By.CssSelector(".panel-gds p");
        private By ReturnToEasLink => By.CssSelector(".submission-message a");
        #endregion

        public ProvideReceivedDetailsPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public ApplicationCompletePage ReturnToEasPage()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                TestContext.Progress.WriteLine($"CaseId Summary: {pageInteractionHelper.GetText(CaseIdSummary)}");
                formCompletionHelper.ClickElement(ReturnToEasLink);
            });

            return new ApplicationCompletePage(_context);
        }
    }
}