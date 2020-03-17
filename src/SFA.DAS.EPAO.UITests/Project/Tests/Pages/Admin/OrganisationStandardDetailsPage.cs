using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationStandardDetailsPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "View organisation standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EditStandardLink => By.CssSelector("[href *= '/edit-standard']");
        private By TRows => By.CssSelector(".govuk-summary-list__row");
        private By THeader => By.CssSelector(".govuk-summary-list__key");
        private By TData => By.CssSelector(".govuk-summary-list__value");

        public OrganisationStandardDetailsPage(ScenarioContext context) : base(context) 
        {
            _context = context;
            VerifyPage(); 
        }

        public OrganisationDetailsPage ReturnToOrganisationDetailsPage() => ReturnToOrganisationDetailsPage(() => formCompletionHelper.ClickLinkByText("Return to organisation"));

        public EditAnOrganisationStandardPage EditStandard()
        {
            formCompletionHelper.ClickElement(EditStandardLink);
            return new EditAnOrganisationStandardPage(_context);
        }

        public OrganisationStandardDetailsPage VerifyStandards()
        {
            pageInteractionHelper.VerifyText(GetData("Standard").Text, ePAOAdminDataHelper.StandardsName);
            return new OrganisationStandardDetailsPage(_context);
        }

        public OrganisationStandardDetailsPage VerifyOrgStandardsStatus(string status)
        {
            pageInteractionHelper.VerifyText(GetData("Status").Text, status);
            return new OrganisationStandardDetailsPage(_context);
        }

        private IWebElement GetData(string headerName)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text == headerName)
                {
                    return row.FindElement(TData);
                }
            }
            throw new NotFoundException($"{headerName} not found");
        }
    }    
}