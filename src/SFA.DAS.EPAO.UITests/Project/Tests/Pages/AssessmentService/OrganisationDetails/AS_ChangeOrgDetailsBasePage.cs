using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public abstract class AS_ChangeOrgDetailsBasePage : EPAO_BasePage
    {
        private readonly ScenarioContext _context;

        private By ViewOrganisationDetailsLink => By.LinkText("View organisation details");

        public AS_ChangeOrgDetailsBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public AS_OrganisationDetailsPage ClickViewOrganisationDetailsLink()
        {
            formCompletionHelper.Click(ViewOrganisationDetailsLink);
            return new AS_OrganisationDetailsPage(_context);
        }
    }
}
