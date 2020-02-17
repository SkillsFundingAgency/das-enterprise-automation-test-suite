using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TermsConditionsMakingApplicationPage : RoatpBasePage
    {
        protected override string PageTitle => "Do you accept the conditions of acceptance for the RoATP?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SignOutButton => By.LinkText("Sign out");

        public TermsConditionsMakingApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage AcceptAndContinue()
        {
            SelectRadioOptionByForAttribute("ConditionsAccepted-Yes");
            Continue();
            return new ApplicationOverviewPage(_context);
        }

        public NotAcceptTermsConditionsPage DoNotAcceptTermsConditions()
        {
            SelectRadioOptionByForAttribute("ConditionsAccepted-No");
            Continue();
            return new NotAcceptTermsConditionsPage(_context);
        }

        public void ClickSignout()
        {
            formCompletionHelper.ClickElement(SignOutButton);
        }
    }
}
