using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TermsConditionsMakingApplicationPage : RoatpBasePage
    {
        protected override string PageTitle => "Do you agree to the terms and conditions of making an application?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SignOutButton => By.LinkText("Sign out");

        private By YesButton => By.Id("ConditionsAccepted-Yes");

        private By NoButton => By.Id("ConditionsAccepted-No");

        public TermsConditionsMakingApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterUkprnPage AcceptAndContinue()
        {
            SelectRadioOptionByForAttribute("ConditionsAccepted-Yes");
            Continue();
            return new EnterUkprnPage(_context);
        }

        public void ClickSignout()
        {
            formCompletionHelper.ClickElement(SignOutButton);
        }
    }
}
