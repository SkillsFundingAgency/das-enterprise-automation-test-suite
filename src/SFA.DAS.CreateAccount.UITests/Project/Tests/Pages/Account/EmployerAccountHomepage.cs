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

        public EmployerAccountHomepage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool IsPagePresented()
        {
            return _menuNavbar.Displayed;
        }

        internal EmployerAccountHomepage OpenHomePage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _homeButton);
            return this;
        }

        internal YourTeamPage OpenYourTeamPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _yourTeamButton);
            return new YourTeamPage(WebBrowserDriver);
        }

        internal PayeSchemePage OpenPayeSchemesPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _payeSchemesPage);
            return new PayeSchemePage(WebBrowserDriver);
        }

        internal YourOrganizationsBasePage OpenOrganizationsBasePage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _yourOrganizationsButton);
            return new YourOrganizationsBasePage(WebBrowserDriver);
        }

        internal OrganizationsAndAgreementsBasePage OpenOrganizationsAndAgreementsBasePage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _yourOrganizationsAndAgreementsPage);
            return new OrganizationsAndAgreementsBasePage(WebBrowserDriver);
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
            formCompletionHelper.ClickElement(WebBrowserDriver, _apprenticesPage);
            return new ApprenticesBasePage(WebBrowserDriver);
        }

        internal FinanceBasePage OpenFinancePage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _financePage);
            return new FinanceBasePage(WebBrowserDriver);
        }

        internal RecruitmentPage OpenRecruitmentPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _RecruitmentPage);
            return new RecruitmentPage(WebBrowserDriver);
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
            formCompletionHelper.ClickElement(WebBrowserDriver, _moreLink);
        }
    }
}