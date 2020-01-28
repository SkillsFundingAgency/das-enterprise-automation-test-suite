using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply
{
    public class AP_OrganisationDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Organisation details";
        private readonly ScenarioContext _context;

        #region Locators
        private By ContactDetailsLink => By.LinkText("Contact details");
        #endregion

        public AP_OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void ClickSubmitInApplicationOverviewPage()
        {
            Continue();
        }

        public AP_OD5_EnterContactDetailsPage ClickContactDetailsLinkInOrganisationDetailsPage()
        {
            formCompletionHelper.Click(ContactDetailsLink);
            return new AP_OD5_EnterContactDetailsPage(_context);
        }
    }
}
