using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin
{
    public class ResultsFoundPage : RoatpAdminBasePage
    {
        protected override string PageTitle => $"found for";

        private By OnBoardingStatus => By.XPath("//span[text()='On-boarding']");

        private By ActiveStatus => By.XPath("//span[text()='Active']");

        private By ProviderType => By.XPath("(//dd[@class='govuk-summary-list__value'])[4]");

        private By OrganisationType => By.XPath("(//dd[@class='govuk-summary-list__value'])[5]");

        private By ApplicationDeterminedDate => By.XPath("(//dd[@class='govuk-summary-list__value'])[11]");

        private By RefineSearch => By.LinkText("Refine search");

        private string MainAndEmployerStatus => "ON-BOARDING";

        private string SupportingStatus => "ACTIVE";

        private string ApplicationDetermineDate => "30 Nov 1980";

        public ResultsFoundPage(ScenarioContext context) : base(context) { }

        public void VerifyProvideType(string providerType) => pageInteractionHelper.VerifyText(ProviderType, providerType);

        public void VerifyOrganisationType() => pageInteractionHelper.VerifyText(OrganisationType, objectContext.GetOrganisationType());

        public void VerifyApplicationDeterminedDate() => pageInteractionHelper.VerifyText(ApplicationDeterminedDate, DateTime.Now.ToString("dd MMM yyyy"));

        public void VerifyApplicationDeterminedDateNotUpdated() => pageInteractionHelper.VerifyText(ApplicationDeterminedDate, ApplicationDetermineDate);

        public SearchPage GoToSearchPage()
        {
            Back();
            return new SearchPage(context);
        }

        public ChangeLegalNamePage ClickChangeLegalNameLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-legal-name"));
            return new ChangeLegalNamePage(context);
        }

        public ChangeUkprnPage ClickChangeUkprnLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-ukprn"));
            return new ChangeUkprnPage(context);
        }

        public ChangeStatusPage ClickChangeStatusLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-status"));
            return new ChangeStatusPage(context);
        }

        public ChangeProviderTypePage ClickChangeProviderTypeLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-provider-type"));
            return new ChangeProviderTypePage(context);
        }

        public ChangeOrganisationTypePage ClickChangeOrganisationTypeLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-organisation-type"));
            return new ChangeOrganisationTypePage(context);
        }

        public ChangeTradingNamePage ClickChangeTradingNameLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-trading-name"));
            return new ChangeTradingNamePage(context);
        }

        public ChangeCompanyNumberPage ClickChangeCompanyNumberLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-company-number"));
            return new ChangeCompanyNumberPage(context);
        }

        public ChangeCharityRegistrationNumberPage ClickChangeCharityNumberLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-charity-registration-number"));
            return new ChangeCharityRegistrationNumberPage(context);
        }

        public ChangeApplicationDateDeterminedPage ClickChangeApplicationDateDeterminedLink()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("change-application-date-determined"));
            return new ChangeApplicationDateDeterminedPage(context);
        }

        public bool VerifyMultipleMatchingResults() => VerifyElement(RefineSearch);

        public void VerifyOneProviderNameResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"1 result found for '{objectContext.GetProviderName()}'");

        public void VerifyOneProviderUkprnResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"1 result found for '{objectContext.GetUkprn()}'");

        public void VerifyNoProviderUkprnResultFound() => pageInteractionHelper.VerifyText(PageHeader, $"No results found for '{objectContext.GetUkprn()}'");

        public ResultsFoundPage VerifyProviderStatusAsOnBoarding()
        {
            pageInteractionHelper.VerifyText(OnBoardingStatus, MainAndEmployerStatus);

            return this;
        }

        public ResultsFoundPage VerifyProviderStatusAsActive()
        {
            pageInteractionHelper.VerifyText(ActiveStatus, SupportingStatus);

            return this;
        }
    }
}