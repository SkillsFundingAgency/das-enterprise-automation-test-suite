using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class OverallResponsibilityForSafeguardingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who has overall responsibility for safeguarding in your organisation";

        private static By FullName => By.Id("PYA-45");

        private static By Email => By.Id("PYA-46");

        private static By ContactNumber => By.Id("PYA-47");

        public OverallResponsibilityForSafeguardingPage(ScenarioContext context) : base(context) => VerifyPage();

        public PreventDutyPage EnterDetailsOfSafeguardingPerson()
        {
            formCompletionHelper.EnterText(FullName, RoatpApplyDataHelpers.FullName);
            formCompletionHelper.EnterText(Email, RoatpApplyDataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, RoatpApplyDataHelpers.ContactNumber);
            Continue();
            return new PreventDutyPage(context);
        }
    }
}
