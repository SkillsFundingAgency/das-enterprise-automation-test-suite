using System;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Finance;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.PayeSchemes;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class EmployerAccountHomepage : PaneTabsPage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "global-nav-links")] private IWebElement _menuNavbar;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Home\')]")] private IWebElement _homeButton;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Your team\')]")] private IWebElement _yourTeamButton;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Your organisations\')]")] private IWebElement _yourOrganizationsButton;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'PAYE schemes\')]")] private IWebElement _payeSchemesPage;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Apprentices\')]")] private IWebElement _apprenticesPage;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Finance\')]")] private IWebElement _financePage;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'More\')]")] private IWebElement _moreLink;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Your organisations and agreements\')]")]
        private IWebElement _yourOrganizationsAndAgreementsPage;
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"success-summary\"]//h1")] private IWebElement _notificationElement;
        [FindsBy(How = How.Id, Using = "company-Name")] private IWebElement _accountName;
        private By _RecruitmentPage = By.XPath("//a[contains(text(), \'Recruitment\')]");

        public EmployerAccountHomepage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _menuNavbar.Displayed;
        }

        internal EmployerAccountHomepage OpenHomePage()
        {
            _formCompletionHelper.ClickElement(_homeButton);
            return this;
        }

        internal YourTeamPage OpenYourTeamPage()
        {
            _formCompletionHelper.ClickElement(_yourTeamButton);
            return new YourTeamPage(_context);
        }

        internal PayeSchemePage OpenPayeSchemesPage()
        {
            _formCompletionHelper.ClickElement(_payeSchemesPage);
            return new PayeSchemePage(_context);
        }

        internal YourOrganizationsBasePage OpenOrganizationsBasePage()
        {
            _formCompletionHelper.ClickElement(_yourOrganizationsButton);
            return new YourOrganizationsBasePage(_context);
        }

        internal OrganizationsAndAgreementsBasePage OpenOrganizationsAndAgreementsBasePage()
        {
            _formCompletionHelper.ClickElement(_yourOrganizationsAndAgreementsPage);
            return new OrganizationsAndAgreementsBasePage(_context);
        }

        internal string GetNotification()
        {
            return _notificationElement.Text;
        }

        internal string GetAccountName()
        {
            return _accountName.Text;
        }

        internal ApprenticesBasePage OpenApprenticesPage()
        {
            _formCompletionHelper.ClickElement(_apprenticesPage);
            return new ApprenticesBasePage(_context);
        }

        internal FinanceBasePage OpenFinancePage()
        {
            _formCompletionHelper.ClickElement(_financePage);
            return new FinanceBasePage(_context);
        }

        internal RecruitmentPage OpenRecruitmentPage()
        {
            _formCompletionHelper.ClickElement(_RecruitmentPage);
            return new RecruitmentPage(_context);
        }

        internal bool IsMoreLinkPresent()
        {
            try
            {
                return _moreLink.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal void ClickMoreLink()
        {
            _formCompletionHelper.ClickElement(_moreLink);
        }
    }
}