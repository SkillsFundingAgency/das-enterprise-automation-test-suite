using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreateMyApprenticeshipAccountPage : PersonalDetailsBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "Create My apprenticeship account";

        private By ErrorSummaryTitle => By.Id("error-summary-title");
        private By LastNameError => By.XPath("(//div[@class='govuk-error-message']/ul/li)[1]");
        private By FirstNameError => By.XPath("(//div[@class='govuk-error-message']/ul/li)[2]");
        private By DOBError => By.XPath("(//div[@class='govuk-error-message']/ul/li)[3]");
        protected override By ContinueButton => By.CssSelector("#identity-assurance-btn");

        public CreateMyApprenticeshipAccountPage(ScenarioContext context) : base(context) => _context = context;

        public override List<string> AccountSettingList() => new List<string> { "Change your password", "Change your email address" };

        public List<string> GetAccountSettingMenuList()
        {
            ClickAccountSettings();
            return pageInteractionHelper.FindElements(NavigationSubLink).Select(x => x.Text).ToList();
        }

        public TermsOfUsePage ConfirmIdentityAndGoToTermsOfUsePage()
        {
            EnterValidApprenticeDetails();

            return new TermsOfUsePage(_context);
        }

        public CreateMyApprenticeshipAccountPage InvalidData(string firstname, string lastname, int? day, int? month, int? year)
        {
            EnterApprenticeDetails(firstname, lastname, day, month, year);
            return this;
        }

        public void VerifyErrorSummary()
        {
            pageInteractionHelper.VerifyText(ErrorSummaryTitle, "There is a problem");
            pageInteractionHelper.VerifyText(LastNameError, "Enter your last name");
            pageInteractionHelper.VerifyText(FirstNameError, "Enter your first name");
            pageInteractionHelper.VerifyText(DOBError, "Enter your date of birth");
        }
    }
}
