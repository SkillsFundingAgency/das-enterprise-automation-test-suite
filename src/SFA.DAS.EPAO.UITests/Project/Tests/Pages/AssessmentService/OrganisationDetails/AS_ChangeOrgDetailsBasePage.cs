using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public abstract class AS_ChangeOrgDetailsBasePage : BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ViewOrganisationDetailsLink => By.LinkText("View organisation details");

        public AS_ChangeOrgDetailsBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public AS_OrganisationDetailsPage ClickViewOrganisationDetailsLink()
        {
            _formCompletionHelper.Click(ViewOrganisationDetailsLink);
            return new AS_OrganisationDetailsPage(_context);
        }
    }
}
