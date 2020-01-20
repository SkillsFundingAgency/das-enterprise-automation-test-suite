using TechTalk.SpecFlow;
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

        public AS_OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public AS_ChangeContactNamePage ClickContactNameChangeLink()
        {
            ClickLinkByHref("SelectOrChangeContactName");
            return new AS_ChangeContactNamePage(_context);
        }

        public AS_ChangePhoneNumberPage ClickPhoneNumberChangeLink()
        {
            ClickLinkByHref("ChangePhoneNumber");
            return new AS_ChangePhoneNumberPage(_context);
        }

        public AS_ChangeAddressPage ClickAddressChangeLink()
        {
            ClickLinkByHref("ChangeAddress");
            return new AS_ChangeAddressPage(_context);
        }

        public AS_ChangeEmailPage ClickEmailChangeLink()
        {
            ClickLinkByHref("ChangeEmail");
            return new AS_ChangeEmailPage(_context);
        }

        public AS_ChangeWebsitePage ClickWebsiteChangeLink()
        {
            ClickLinkByHref("ChangeWebsite");
            return new AS_ChangeWebsitePage(_context);
        }

        private void ClickLinkByHref(string href) => _formCompletionHelper.ClickElement(_pageInteractionHelper.GetLinkByHref(href), false);
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
