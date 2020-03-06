using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using SFA.DAS.RAA.DataGenerator;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();
        protected override string Linktext => "Home";
        private readonly RegexHelper _regexHelper;
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly VacancyTitleDatahelper _vacancyTitleDataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly RAAV2DataHelper _raaV2DataHelper;


        #region Locators
        private By PublicAccountIdLocator => By.CssSelector(".heading-secondary");
        private By SucessSummary => By.CssSelector(".success-summary");
        private By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        private By StartAddingApprenticesNowTaskLink => By.LinkText("Start adding apprentices now");
        protected By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected By YourFinancesLink => By.LinkText("Your finances");

        #endregion

        #region DynamicHomePanel
        protected By ContinueSettingUpAnApprenticeship => By.Id("call-to-action-continue-setting-up-an-apprenticeship");

        protected By ContinueTo => By.LinkText("Continue");

        protected By StartNowButton => By.LinkText("Start now");

        private By AdvertPanel => By.ClassName("dashboard-section");

        private By VacancyDetails => By.ClassName("responsive");
        private By ContinueCreatingNewVacancy => By.LinkText("Continue creating your vacancy");
        private By GotoYourVacancyDashboard => By.LinkText("Go to your vacancy dashboard");
        private By ReviewYourVacancy => By.LinkText("Review your vacancy");
        private By applicationsLink => By.CssSelector(".govuk-link");
        private By AddApprenticeDetails => By.LinkText("Add apprentice details");
        #endregion


        internal HomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _regexHelper = context.Get<RegexHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _raaV2DataHelper = context.Get<RAAV2DataHelper>();
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

        public string ConfirmVacancyDetails(string status)
        {
            string vacancyStatus = null;
            List<IWebElement> HomePagePanels = _pageInteractionHelper.FindElements(AdvertPanel);
            foreach (var panel in HomePagePanels)
            {
                if (panel.Text.Contains("Your apprenticeship advert"))
                {
                    var Table = _pageInteractionHelper.FindElement(VacancyDetails);
                    var rows = Table.FindElements(By.TagName("tr"));
                    int i = 0;
                    _pageInteractionHelper.VerifyText(rows[i].Text, _vacancyTitleDataHelper.VacancyTitle);
                    switch (status)
                    {
                        case "Saved as draft":
                            vacancyStatus = _pageInteractionHelper.GetText(rows[i + 1]);
                            break;

                        case "PENDING REVIEW":
                            _pageInteractionHelper.VerifyText(rows[i + 1].Text, "Closing date " + (_raaV2DataHelper.VacancyClosing).ToString("dd MMM yyyy"));
                            vacancyStatus = _pageInteractionHelper.GetText(rows[i + 2]);
                            _pageInteractionHelper.VerifyText(rows[i + 3].Text, "Applications No applications yet");
                            break;

                        case "REJECTED":
                            vacancyStatus = _pageInteractionHelper.GetText(rows[i + 1]);
                            break;

                        case "LIVE":
                            vacancyStatus = _pageInteractionHelper.GetText(rows[i + 1]);
                            _pageInteractionHelper.VerifyText(rows[i + 2].Text, "Closing date " +(_raaV2DataHelper.VacancyClosing).ToString("dd MMM yyyy"));
                            _pageInteractionHelper.VerifyText(rows[i + 3].Text, "Applications 0 applications");
                            bool buttonDisplayed = _pageInteractionHelper.IsElementDisplayed(AddApprenticeDetails);
                            _pageInteractionHelper.VerifyText(buttonDisplayed.ToString(), "true");                            
                            break;

                        case "CLOSED":
                            vacancyStatus = _pageInteractionHelper.GetText(rows[i + 1]);
                            _pageInteractionHelper.VerifyText(rows[i + 2].Text, (_raaV2DataHelper.VacancyClosing).ToString());
                            break;
                    }
                }
                break;
            }
            return vacancyStatus;
        }

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

                case "0 applications":
                    foreach (var link in links)
                    {
                        if (link.Text.Contains("applications"))
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