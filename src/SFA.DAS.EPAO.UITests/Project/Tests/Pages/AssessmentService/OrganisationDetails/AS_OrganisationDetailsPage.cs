using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_OrganisationDetailsPage : BasePage
    {
        protected override string PageTitle => "Organisation details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By ContactNameChangeLink => By.CssSelector("a[href='/Organisation/SelectOrChangeContactName']");
        private By PhoneNumberChangeLink => By.CssSelector("a[href='/Organisation/ChangePhoneNumber']");
        private By AddressChangeLink => By.CssSelector("a[href='/Organisation/ChangeAddress']");
        private By EmailChangeLink => By.CssSelector("a[href='/Organisation/ChangeEmail']");
        private By WebsiteChangeLink => By.CssSelector("a[href='/Organisation/ChangeWebsite']");
        #endregion

        public AS_OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public AS_ChangeContactNamePage ClickContactNameChangeLink()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(ContactNameChangeLink));
            return new AS_ChangeContactNamePage(_context);
        }

        public AS_ChangePhoneNumberPage ClickPhoneNumberChangeLink()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(PhoneNumberChangeLink));
            return new AS_ChangePhoneNumberPage(_context);
        }

        public AS_ChangeAddressPage ClickAddressChangeLink()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(AddressChangeLink));
            return new AS_ChangeAddressPage(_context);
        }

        public AS_ChangeEmailPage ClickEmailChangeLink()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(EmailChangeLink));
            return new AS_ChangeEmailPage(_context);
        }

        public AS_ChangeWebsitePage ClickWebsiteChangeLink()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(WebsiteChangeLink));
            return new AS_ChangeWebsitePage(_context);
        }
    }

    public class AS_ChangeOrganisationDetailsPage : BasePage
    {
        protected override string PageTitle => "Change organisation details";
        private readonly ScenarioContext _context;

        public AS_ChangeOrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_OrganisationDetailsPage ClickAccessButton()
        {
            Continue();
            return new AS_OrganisationDetailsPage(_context);
        }
    }
}
