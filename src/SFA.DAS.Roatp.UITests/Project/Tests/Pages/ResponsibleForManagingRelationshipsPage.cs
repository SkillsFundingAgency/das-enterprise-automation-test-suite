using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ResponsibleForManagingRelationshipsPage : RoatpBasePage
    {
        protected override string PageTitle => "Tell us who's responsible for managing relationships with employers";

        private By FullName => By.Id("RTE-22.1");
        private By Email => By.Id("RTE-22.2");
        private By ContactNumber => By.Id("RTE-22.3");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

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
    public class PromoteApprentcieshipsToEmployersPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation promote apprenticeships to employers?";

        private By LongTextArea => By.Id("RTE-23");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PromoteApprentcieshipsToEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage EnterTextRegardingOrganisationPromoteApprenticeshipsToEmployerAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.OrganisationPromoteApprenticeships));
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
