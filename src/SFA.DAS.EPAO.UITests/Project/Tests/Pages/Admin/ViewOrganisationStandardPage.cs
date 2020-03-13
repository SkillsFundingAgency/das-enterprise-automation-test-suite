using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ViewOrganisationStandardPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "View organisation standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Summary => By.CssSelector(".govuk-summary-list__value");

        public ViewOrganisationStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ViewOrganisationStandardPage VerifyStandards()
        {
            VerifyPage(() => pageInteractionHelper.FindElements(Summary), ePAOAdminDataHelper.StandardsName);
            return new ViewOrganisationStandardPage(_context);
        }
    }
}
