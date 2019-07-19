using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class LegalAgreementPage : BasePage
    {
        private const string continuebtnid = "continue";
        [FindsBy(How = How.Id, Using = continuebtnid)] private IWebElement _continuebtn;

        public LegalAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal EmployerAccountHomepage Continue()
        {
            _formCompletionHelper.ClickElement(_continuebtn);
            return new EmployerAccountHomepage(context);
        }
    }
}