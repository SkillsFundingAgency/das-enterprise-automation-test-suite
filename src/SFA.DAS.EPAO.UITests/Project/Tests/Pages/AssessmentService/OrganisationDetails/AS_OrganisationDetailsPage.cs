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
        #endregion

        #region Locators
        private By ContactNameChangeLink => By.XPath("//a[@href='/Organisation/SelectOrChangeContactName']");
        private By PhoneNumberChangeLink => By.XPath("//a[@href='/Organisation/ChangePhoneNumber']");
        private By AddressChangeLink => By.XPath("//a[@href='/Organisation/ChangeAddress']");
        private By EmailChangeLink => By.XPath("//a[@href='/Organisation/ChangeEmail']");
        private By WebsiteChangeLink => By.XPath("//a[@href='/Organisation/ChangeWebsite']");
        #endregion

        public AS_OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_ChangeContactNamePage ClickContactNameChangeLink()
        {
            _formCompletionHelper.ClickLinkByText(ContactNameChangeLink, "Change");
            return new AS_ChangeContactNamePage(_context);
        }

        public AS_ChangePhoneNumberPage ClickPhoneNumberChangeLink()
        {
            _formCompletionHelper.ClickLinkByText(PhoneNumberChangeLink, "Change");
            return new AS_ChangePhoneNumberPage(_context);
        }

        public AS_ChangeAddressPage ClickAddressChangeLink()
        {
            _formCompletionHelper.ClickLinkByText(AddressChangeLink, "Change");
            return new AS_ChangeAddressPage(_context);
        }

        public AS_ChangeEmailPage ClickEmailChangeLink()
        {
            _formCompletionHelper.ClickLinkByText(EmailChangeLink, "Change");
            return new AS_ChangeEmailPage(_context);
        }

        public AS_ChangeWebsitePage ClickWebsiteChangeLink()
        {
            _formCompletionHelper.ClickLinkByText(WebsiteChangeLink, "Change");
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
