using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations
{
    public class EnterOrganisationDetails : BasePage
    {
        protected const string searchInputId = "searchTerm";
        [FindsBy(How = How.Id, Using = searchInputId)]
        protected IWebElement searchInput;

        public EnterOrganisationDetails(ScenarioContext context) : base(context)
        {
        }
    }

    public class SearchForYourOrganisationPage : EnterOrganisationDetails
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string searchButtoncss = "form > [type=\"submit\"]";
        [FindsBy(How = How.CssSelector, Using = searchButtoncss)] private IWebElement _searchButton;

        public SearchForYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(searchInput);
        }

        internal SearchForYourOrganisationPage SetOrganisationName(string name)
        {
            _formCompletionHelper.EnterText(searchInput, name);
            return this;
        }

        internal SelectYourOrganisationPage Continue()
        {
            _formCompletionHelper.ClickElement(_searchButton);
            return new SelectYourOrganisationPage(_context);
        }
    }
}