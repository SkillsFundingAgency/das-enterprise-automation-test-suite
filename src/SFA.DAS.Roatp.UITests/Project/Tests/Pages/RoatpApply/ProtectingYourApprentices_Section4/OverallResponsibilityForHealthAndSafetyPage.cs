using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class OverallResponsibilityForHealthAndSafetyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who has overall responsibility for health and safety in your organisation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FullName => By.Id("PYA-55");

        private By Email => By.Id("PYA-56");

        private By ContactNumber => By.Id("PYA-57");

        public OverallResponsibilityForHealthAndSafetyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterDetailsOfHealthAndSafetyPerson()
        {
            formCompletionHelper.EnterText(FullName, applydataHelpers.FullName);
            formCompletionHelper.EnterText(Email, applydataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, applydataHelpers.ContactNumber);
            Continue();
            return new ApplicationOverviewPage(_context);
        }

    }
}
