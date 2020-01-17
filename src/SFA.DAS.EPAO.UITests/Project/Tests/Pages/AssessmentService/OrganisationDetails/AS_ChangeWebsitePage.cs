using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangeWebsitePage : BasePage
    {
        protected override string PageTitle => "Change website address";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EPAODataHelper _ePAODataHelper;
        #endregion

        #region Locators
        private By WebsiteAddressTextBox => By.Id("WebsiteLink");
        #endregion

        public AS_ChangeWebsitePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _ePAODataHelper = context.Get<EPAODataHelper>();
            VerifyPage();
        }

        public AS_ConfirmWebsiteAddressPage EnterRandomWebsiteAddressAndClickUpdate()
        {
            _formCompletionHelper.EnterText(WebsiteAddressTextBox, _ePAODataHelper.GetRandomWebsiteAddress);
            Continue();
            return new AS_ConfirmWebsiteAddressPage(_context);
        }
    }

    public class AS_ConfirmWebsiteAddressPage : BasePage
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