using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_SearchForACandidatePage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Search for a candidate";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        private By FirstName => By.Id("SearchViewModel_FirstName");

        private By LastName => By.Id("SearchViewModel_LastName");

        public Manage_SearchForACandidatePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public Manage_SearchForACandidatePage Search()
        {
            formCompletionHelper.EnterText(FirstName, "He");
            formCompletionHelper.EnterText(LastName, "Ch");
            formCompletionHelper.ClickButtonByText("Search");
            pageInteractionHelper.WaitforURLToChange("/search");
            return this;
        }

        public Manage_MyApplicationsPage ViewApplications()
        {
            List<IWebElement> filteredRows = pageInteractionHelper.GetLinks("Select candidate");
            formCompletionHelper.ClickElement(() => raadataHelper.GetRandomElementFromListOfElements(filteredRows));
            return new Manage_MyApplicationsPage(_context);
        }
    }
}
