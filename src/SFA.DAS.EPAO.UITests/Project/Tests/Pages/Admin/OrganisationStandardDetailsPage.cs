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
    }    
}