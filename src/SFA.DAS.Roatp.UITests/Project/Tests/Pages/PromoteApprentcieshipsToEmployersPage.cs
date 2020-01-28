using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class PromoteApprentcieshipsToEmployersPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation promote apprenticeships to employers?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

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
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.OrganisationPromoteApprenticeships);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
