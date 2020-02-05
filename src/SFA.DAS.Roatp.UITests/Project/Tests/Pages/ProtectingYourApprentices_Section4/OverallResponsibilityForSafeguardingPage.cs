using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.ProtectingYourApprentices_Section4
{
    public class OverallResponsibilityForSafeguardingPage : RoatpBasePage
    {
        protected override string PageTitle => "Tell us who has overall responsibility for safeguarding in your organisation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FullName => By.Id("PYA-45");

        private By Email => By.Id("PYA-46");

        private By ContactNumber => By.Id("PYA-47");

        public OverallResponsibilityForSafeguardingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public PreventDutyPage EnterDetailsOfSafeguardingPerson()
        {
            formCompletionHelper.EnterText(FullName, applydataHelpers.FullName);
            formCompletionHelper.EnterText(Email, applydataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, applydataHelpers.ContactNumber);
            Continue();
            return new PreventDutyPage(_context);
        }
    }
}
