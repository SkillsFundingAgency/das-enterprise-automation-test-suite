using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class ResponsibleForManagingRelationshipsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who's responsible for managing relationships with employers";

        private static By FullName => By.Id("RTE-22-1");

        private static By Email => By.Id("RTE-22-2");

        private static By ContactNumber => By.Id("RTE-22-3");

        public ResponsibleForManagingRelationshipsPage(ScenarioContext context) : base(context) => VerifyPage();

        public PromoteApprentcieshipsToEmployersPage EnterDetailsOfIndividualForManagingRelationshipsWithEmployersAndContinue()
        {
            formCompletionHelper.EnterText(FullName, RoatpApplyDataHelpers.FullName);
            formCompletionHelper.EnterText(Email, RoatpApplyDataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, RoatpApplyDataHelpers.ContactNumber);
            Continue();
            return new PromoteApprentcieshipsToEmployersPage(context);
        }
    }
}
