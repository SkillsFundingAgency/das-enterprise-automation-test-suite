using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ResultsFoundPage : RoatpAdminBasePage
    {
        protected override string PageTitle => $"found for";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By OnBoardingStatus => By.XPath("//span[text()='On-boarding']");

        private By ActiveStatus => By.XPath("//span[text()='Active']");

        private By ProviderType => By.XPath("(//dd[@class='govuk-summary-list__value'])[4]");

        private By OrganisationType = By.XPath("(//dd[@class='govuk-summary-list__value'])[5]");

        private By RefineSearch => By.LinkText("Refine search");

        private string MainAndEmployerStatus => "ON-BOARDING";

        private string SupportingStatus => "ACTIVE";

        public ResultsFoundPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifyProvideType(string providerType) => pageInteractionHelper.VerifyText(ProviderType, providerType);

        public void VerifyOrganisationType() => pageInteractionHelper.VerifyText(OrganisationType, objectContext.GetOrganisationType());

        public RoatpAdminHomePage GetRoatpAdminHomePage()
        {
            Back();
            return new RoatpAdminHomePage(_context);
        }

        public ChangeLegalNamePage ClickChangeLegalNameLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-legal-name"));
            return new ChangeLegalNamePage(_context);
        }

        public ChangeUkprnPage ClickChangeUkprnLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-ukprn"));
            return new ChangeUkprnPage(_context);
        }

        public ChangeStatusPage ClickChangeStatusLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-status"));
            return new ChangeStatusPage(_context);
        }

        public ChangeProviderTypePage ClickChangeProviderTypeLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-provider-type"));
            return new ChangeProviderTypePage(_context);
        }

        public ChangeOrganisationTypePage ClickChangeOrganisationTypeLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-organisation-type"));
            return new ChangeOrganisationTypePage(_context);
        }

        public ChangeTradingNamePage ClickChangeTradingNameLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-trading-name"));
            return new ChangeTradingNamePage(_context);
        }

        public ChangeCompanyNumberPage ClickChangeCompanyNumberLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-company-number"));
            return new ChangeCompanyNumberPage(_context);
        }

        public ChangeCharityRegistrationNumberPage ClickChangeCharityNumberLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-charity-registration-number"));
            return new ChangeCharityRegistrationNumberPage(_context);
        }

        public ChangeApplicationDateDeterminedPage ClickChangeApplicationDateDeterminedLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-application-date-determined"));
            return new ChangeApplicationDateDeterminedPage(_context);
        }

        public bool VerifyMultipleMatchingResults() => pageInteractionHelper.VerifyPage(RefineSearch);

        public void VerifyOneProviderNameResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"1 result found for '{objectContext.GetProviderName()}'");

        public void VerifyOneProviderUkprnResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"1 result found for '{objectContext.GetUkprn()}'");

        public bool VerifyMainAndEmployerTypeStatus() => pageInteractionHelper.VerifyText(OnBoardingStatus, MainAndEmployerStatus);

        public bool VerifySupportingProviderTypeStatus() => pageInteractionHelper.VerifyText(ActiveStatus, SupportingStatus);
    }
}
