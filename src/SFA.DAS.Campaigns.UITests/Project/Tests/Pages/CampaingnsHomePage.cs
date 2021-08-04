using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class CampaingnsHomePage : CampaingnsPage
    {
        protected override string PageTitle => "APPRENTICES EMPLOYERS INFLUENCERS";

        protected override By PageHeader => By.CssSelector(".fiu-header");

        private string HomePageFiuCard1Heading => "Find an apprenticeship";

        private string HomePageFiuCard2Heading => "What are the benefits for me?";

        private string HomePageFiuCard3Heading => "Funding an apprenticeship";

        private string HomePageFiuCard4Heading => "Find apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Elements/object
        private By CookieButton => By.Id("fiu-cb-button-accept");

        private By CloseCookieButton => By.Id("fiu-cb-close");

        private By Apprentice => By.CssSelector("a[href*='apprentice']");

        private By Employer => By.CssSelector("a[href*='employers']");

        private By RegisterInterest => By.CssSelector("a[href*='register-interest']");

        private By FiuHomePageCard1 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Find an apprenticeship')]");

        private By FiuHomePageCard2 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'What are the benefits for me?')]");

        private By FiuHomePageCard3 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Funding an apprenticeship')]");

        private By FiuHomePageCard4 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Find apprenticeship training')]");
        #endregion

        public CampaingnsHomePage(ScenarioContext context) : base(context) => _context = context;
        
        public CampaingnsHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
            {
                formCompletionHelper.ClickElement(CookieButton);
                formCompletionHelper.ClickElement(CloseCookieButton);
            }
            return new CampaingnsHomePage(_context);
        }

        public RegisterInterestPage NavigateToRegisterInterest()
        {
            formCompletionHelper.ClickElement(RegisterInterest);
            return new RegisterInterestPage(_context);
        }

        public ApprenticeHubPage NavigateToApprenticeshipHubPage()
        {
            formCompletionHelper.ClickElement(Apprentice);
            return new ApprenticeHubPage(_context);
        }

        public EmployerHubPage NavigateToEmployerHubPage()
        {
            formCompletionHelper.ClickElement(Employer);
            return new EmployerHubPage(_context);
        }
        public CampaingnsHomePage VerifyFiuHomePageCard1()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard1, HomePageFiuCard1Heading);
            return new CampaingnsHomePage(_context);
        }

        public CampaingnsHomePage VerifyFiuHomePageCard2()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard2, HomePageFiuCard2Heading);
            return new CampaingnsHomePage(_context);
        }

        public CampaingnsHomePage VerifyFiuHomePageCard3()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard3, HomePageFiuCard3Heading);
            return new CampaingnsHomePage(_context);
        }
        public CampaingnsHomePage VerifyFiuHomePageCard4()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard4, HomePageFiuCard4Heading);
            return new CampaingnsHomePage(_context);
        }

    }
}
