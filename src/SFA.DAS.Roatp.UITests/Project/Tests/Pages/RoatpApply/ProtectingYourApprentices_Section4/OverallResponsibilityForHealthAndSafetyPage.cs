using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class OverallResponsibilityForHealthAndSafetyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who has overall responsibility for health and safety in your organisation";

        private static By FullName => By.Id("PYA-55");

        private static By Email => By.Id("PYA-56");

        private static By ContactNumber => By.Id("PYA-57");

        public OverallResponsibilityForHealthAndSafetyPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterDetailsOfHealthAndSafetyPerson()
        {
            formCompletionHelper.EnterText(FullName, RoatpApplyDataHelpers.FullName);
            formCompletionHelper.EnterText(Email, RoatpApplyDataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, RoatpApplyDataHelpers.ContactNumber);
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}