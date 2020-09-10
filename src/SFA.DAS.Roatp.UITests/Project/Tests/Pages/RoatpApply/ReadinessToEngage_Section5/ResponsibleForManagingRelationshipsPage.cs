using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class ResponsibleForManagingRelationshipsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who's responsible for managing relationships with employers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FullName => By.Id("RTE-22-1");

        private By Email => By.Id("RTE-22-2");

        private By ContactNumber => By.Id("RTE-22-3");

        public ResponsibleForManagingRelationshipsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public PromoteApprentcieshipsToEmployersPage EnterDetailsOfIndividualForManagingRelationshipsWithEmployersAndContinue()
        {
            formCompletionHelper.EnterText(FullName, applydataHelpers.FullName);
            formCompletionHelper.EnterText(Email, applydataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, applydataHelpers.ContactNumber);
            Continue();
            return new PromoteApprentcieshipsToEmployersPage(_context);
        }
    }
}
