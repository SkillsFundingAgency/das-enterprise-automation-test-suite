using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class FireItUpHomePage : CampaingnsPage
    {
        protected override string PageTitle => "APPRENTICESHIPS";

        protected override By PageHeader => By.CssSelector(".fiu-homepage-banner__heading");

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
        
        private By Parent => By.CssSelector("a[href*='parents']");
        
        private By Interests => By.CssSelector("a[href*='industries']");

        private By RegisterInterest => By.CssSelector("a[href*='register-interest']");

        private By TheCalling => By.CssSelector("#homepage-thecalling-banner-link");

        private By FiuHomePageCard1 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Find an apprenticeship')]");
        private By FiuHomePageCard2 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'What are the benefits for me?')]");

        private By FiuHomePageCard3 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Funding an apprenticeship')]");

        private By FiuHomePageCard4 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Find apprenticeship training')]");
        #endregion

        public FireItUpHomePage(ScenarioContext context) : base(context) => _context = context;
        
        public FireItUpHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
            {
                formCompletionHelper.ClickElement(CookieButton);
                formCompletionHelper.ClickElement(CloseCookieButton);
            }
            return new FireItUpHomePage(_context);
        }

        public RegisterInterestPage NavigateToRegisterInterest()
        {
            formCompletionHelper.ClickElement(RegisterInterest);
            return new RegisterInterestPage(_context);
        }

        public ParentHubPage NavigateToParentHubPage()
        {
            formCompletionHelper.ClickElement(Parent);
            return new ParentHubPage(_context);
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
        public FireItUpHomePage VerifyFiuHomePageCard1()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard1, HomePageFiuCard1Heading);
            return new FireItUpHomePage(_context);
        }

        public FireItUpHomePage VerifyFiuHomePageCard2()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard2, HomePageFiuCard2Heading);
            return new FireItUpHomePage(_context);
        }

        public FireItUpHomePage VerifyFiuHomePageCard3()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard3, HomePageFiuCard3Heading);
            return new FireItUpHomePage(_context);
        }
        public FireItUpHomePage VerifyFiuHomePageCard4()
        {
            pageInteractionHelper.VerifyText(FiuHomePageCard4, HomePageFiuCard4Heading);
            return new FireItUpHomePage(_context);
        }

    }
}
