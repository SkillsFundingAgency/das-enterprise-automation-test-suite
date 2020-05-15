using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : InterimYourOrganisationsAndAgreementsPage
    {
        protected override string PageTitle => "About your agreement";

        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.CssSelector("input[value='Continue to your agreement']");


        public AboutYourAgreementPage(ScenarioContext context) : base(context, false) => _context = context;

        public SignAgreementPage ClickContinueToYourAgreementButtonInAboutYourAgreementPage()
        {
            Continue();
            return new SignAgreementPage(_context);
        }
    }
}