using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class OverallResponsibilityForSafeguardingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who has overall responsibility for safeguarding in your organisation";

        private By FullName => By.Id("PYA-45");

        private By Email => By.Id("PYA-46");

        private By ContactNumber => By.Id("PYA-47");

        public OverallResponsibilityForSafeguardingPage(ScenarioContext context) : base(context) => VerifyPage();

        public PreventDutyPage EnterDetailsOfSafeguardingPerson()
        {
            formCompletionHelper.EnterText(FullName, applydataHelpers.FullName);
            formCompletionHelper.EnterText(Email, applydataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, applydataHelpers.ContactNumber);
            Continue();
            return new PreventDutyPage(context);
        }
    }
}
