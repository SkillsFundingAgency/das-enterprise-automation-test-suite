using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.SupportConsole.UITests.Project.Helpers
{
    public class StepsHelper
    {
        private readonly ScenarioContext context;
        private readonly TabHelper _tabHelper;

        public StepsHelper(ScenarioContext context)
        {
            context = context;
            _tabHelper = context.Get<TabHelper>();
        }

        public SearchHomePage Tier1LoginToSupportConsole() => LoginToSupportConsole(context.GetUser<SupportConsoleTier1User>());
        
        public SearchHomePage Tier2LoginToSupportConsole() => LoginToSupportConsole(context.GetUser<SupportConsoleTier2User>());

        public ToolSupportHomePage ValidUserLogsinToSupportTools() => LoginToSupportTools(context.GetUser<SupportToolsUser>());

        public AccountOverviewPage SearchAndViewAccount() => new SearchHomePage(context).SearchByPublicAccountIdAndViewAccount();

        public UlnSearchResultsPage SearchForUln() => new AccountOverviewPage(context).ClickCommitmentsMenuLink().SearchForULN();

        public void SearchWithInvalidUln(bool WithSpecialChars)
        {
            var commitmentsSearchPage = new AccountOverviewPage(context).ClickCommitmentsMenuLink().SelectUlnSearchTypeRadioButton();

            Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), commitmentsSearchPage.UlnSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

            if (WithSpecialChars)
                commitmentsSearchPage.SearchWithInvalidULNWithSpecialChars();
            else
                commitmentsSearchPage.SearchWithInvalidULN();
        }

        public void SearchWithInvalidCohort(bool WithSpecialChars)
        {
            var commitmentsSearchPage = new AccountOverviewPage(context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

            VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);

            if (WithSpecialChars)
                commitmentsSearchPage.SearchWithInvalidCohortWithSpecialChars();
            else
                commitmentsSearchPage.SearchWithInvalidCohort();
        }

        public void SearchWithUnauthorisedCohortAccess()
        {
            var commitmentsSearchPage = new AccountOverviewPage(context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

            VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);
            
            commitmentsSearchPage.SearchWithUnauthorisedCohortAccess();
        }

        public CohortSummaryPage SearchForCohort() => new AccountOverviewPage(context).ClickCommitmentsMenuLink().SearchForCohort();

        void VerifyCohortSearchTextBoxHelpTextContent(CommitmentsSearchPage commitmentsSearchPage) => Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), commitmentsSearchPage.CohortSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

        private SearchHomePage LoginToSupportConsole(LoginUser loginUser)
        {
            new IdamsPage(context).LoginToAccess1Staff();

            return new SignInPage(context).SignInWithValidDetails(loginUser);
        }

        private ToolSupportHomePage LoginToSupportTools(LoginUser loginUser)
        {
            _tabHelper.GoToUrl(UrlConfig.SupportTools_BaseUrl);
            new IdamsPage(context).LoginToAccess1Staff();

            return new SignInPage(context).SignIntoToolSupportWithValidDetails(loginUser);
        }

       
    }
}