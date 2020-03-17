using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();
        protected override string Linktext => "Home";

        private readonly RegexHelper _regexHelper;
        private readonly ScenarioContext _context;

        #region Locators
        private By PublicAccountIdLocator => By.CssSelector(".heading-secondary");
        private By SucessSummary => By.CssSelector(".success-summary");
        private By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        private By StartAddingApprenticesNowTaskLink => By.LinkText("Start adding apprentices now");
        protected By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected By YourFinancesLink => By.LinkText("Your finances");   
        #endregion

        protected By ContinueSettingUpAnApprenticeship => By.Id("call-to-action-continue-setting-up-an-apprenticeship");

        protected By ContinueTo => By.LinkText("Continue");

        protected By StartNowButton => By.LinkText("Start now");

        internal HomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _regexHelper = context.Get<RegexHelper>();
        }

        public HomePage(ScenarioContext context) : this(context, false) { }

        public void VerifySucessSummary()
        {
            pageInteractionHelper.VerifyText(SucessSummary, "All agreements signed");
        }

        public string AccountId()
        {
            return _regexHelper.GetAccountId(pageInteractionHelper.GetUrl());
        }

        public string PublicAccountId()
        {
            return _regexHelper.GetPublicAccountId(pageInteractionHelper.GetText(PublicAccountIdLocator));
        }

        public AboutYourAgreementPage ClickAcceptYourAgreementLinkInHomePagePanel()
        {
            formCompletionHelper.Click(AcceptYourAgreementLink);
            return new AboutYourAgreementPage(_context);
        }

        public DoYouNeedToCreateAnAdvertBasePage ContinueToCreateAdvert()
        {
            formCompletionHelper.ClickElement(ContinueTo);
            return new DoYouNeedToCreateAnAdvertBasePage(_context);
        }
        private IWebElement GetDetails(string headerName)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(headerName))
                {
                        return row.FindElement(TData);
                }
            }
                throw new NotFoundException($"{headerName} not found");
        }

        //private IWebElement GetTitle(string title)
        //{
        //    foreach (var row in pageInteractionHelper.FindElements(TRows))
        //    {
        //        if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(title))
        //        {
        //            return row.FindElement(TData);
        //        }
        //    }
        //    throw new NotFoundException($"{title} not found");
        //}

        //private IWebElement GetClosingDate(string closingDate)
        //{
        //    foreach (var row in pageInteractionHelper.FindElements(TRows))
        //    {
        //        if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(closingDate))
        //        {
        //            return row.FindElement(TData);
        //        }
        //    }
        //    throw new NotFoundException($"{closingDate} not found");
        //}

        //private IWebElement GetApplications(string applications)
        //{
        //    foreach (var row in pageInteractionHelper.FindElements(TRows))
        //    {
        //        if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(applications))
        //        {
        //            return row.FindElement(TData);
        //        }
        //    }
        //    throw new NotFoundException($"{applications} not found");
        //}

        private void ConfirmVacancyTitleAndStatus(string status)
        {
            string vacancyStatus = GetDetails("Status").Text.ToString(); 
            _pageInteractionHelper.VerifyText(GetDetails("Title").Text.ToString(), _vacancyTitleDataHelper.VacancyTitle);
            _pageInteractionHelper.VerifyText(vacancyStatus, status);
        }

        private void ConfirmSubmittedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            _pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), _raaV2DataHelper.VacancyClosing.ToString("dd MMM yyyy"));
            _pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
        }

        private void ConfirmRejectedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
        }

        private void ConfirmLiveVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            _pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), _raaV2DataHelper.VacancyClosing.ToString("dd MMM yyyy"));
            _pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
        }

        private void ConfirmClosedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            _pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), DateTime.Today.ToString("dd MMMM yyyy"));
            _pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
        }

        //private void VerifyClosingDate(string closingDate)
        //{
        //    _pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), closingDate);
        //}

        //private void VerifyApplicationLink()
        //{
        //    _pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
        //}

            public 

        public void ClicktheButtonOnAdvertPage(string button)
        {

            List<IWebElement> links = _pageInteractionHelper.FindElements(applicationsLink);
            switch (button)
            {
                case "Continue creating your vacancy":
                    _formCompletionHelper.Click(ContinueCreatingNewVacancy);
                    break;
                case "Go to your vacancy dashboard":
                    _formCompletionHelper.Click(GotoYourVacancyDashboard);
                    break;

                case "Review your vacancy":
                    _formCompletionHelper.Click(ReviewYourVacancy);
                    break;

                case "application":
                    foreach(var link in links)
                    {
                        if(link.Text.Contains("application"))
                        {
                            link.Click();
                            break;
                        }
                    }
                    break;
            }
        }
        public void VerifyReserveFundingPanel() => pageInteractionHelper.VerifyText(ContinueSettingUpAnApprenticeship, "Continue setting up an apprenticeship");
        
        public void VerifyStartAddingApprenticesNowTaskLink() => VerifyPage(StartAddingApprenticesNowTaskLink);
    }
}