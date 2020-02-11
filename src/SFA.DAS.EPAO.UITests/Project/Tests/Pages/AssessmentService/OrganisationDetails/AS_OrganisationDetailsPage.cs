using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_OrganisationDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Organisation details";

        private readonly ScenarioContext _context;

        public AS_OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
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

        private void ClickLinkByHref(string href) => formCompletionHelper.ClickInterceptedElement(pageInteractionHelper.GetLinkByHref(href));
    }

    public class AS_ChangeOrganisationDetailsPage : EPAO_BasePage
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
