using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangeWebsitePage : EPAO_BasePage
    {
        protected override string PageTitle => "Change website address";
        private readonly ScenarioContext _context;

        #region Locators
        private By WebsiteAddressTextBox => By.Id("WebsiteLink");
        #endregion

        public AS_ChangeWebsitePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ConfirmWebsiteAddressPage EnterRandomWebsiteAddressAndClickUpdate()
        {
            formCompletionHelper.EnterText(WebsiteAddressTextBox, dataHelper.RandomWebsiteAddress);
            Continue();
            return new AS_ConfirmWebsiteAddressPage(_context);
        }
    }

    public class AS_ConfirmWebsiteAddressPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm website address";
        private readonly ScenarioContext _context;

        public AS_ConfirmWebsiteAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WebsiteAddressUpdatedPage ClickConfirmButtonInConfirmWebsiteAddressPage()
        {
            Continue();
            return new AS_WebsiteAddressUpdatedPage(_context);
        }
    }

    public class AS_WebsiteAddressUpdatedPage : AS_ChangeOrgDetailsBasePage
    {
        protected override string PageTitle => "Website address updated";

        public AS_WebsiteAddressUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}