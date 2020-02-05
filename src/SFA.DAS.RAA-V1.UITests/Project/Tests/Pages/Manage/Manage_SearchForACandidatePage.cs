using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_SearchForACandidatePage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Search for a candidate";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FAADataHelper _dataHelper;
        #endregion
        private By FirstName => By.Id("SearchViewModel_FirstName");

        private By LastName => By.Id("SearchViewModel_LastName");

        private By NoCandidateInfo = By.XPath("//div [@class ='form-group']/ul");

        public Manage_SearchForACandidatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<FAADataHelper>();
        }

        public Manage_SearchForACandidatePage Search()
        {
            formCompletionHelper.EnterText(FirstName, "He");
            formCompletionHelper.EnterText(LastName, "Ch");
            formCompletionHelper.ClickButtonByText("Search");
            pageInteractionHelper.WaitforURLToChange("/search");
            return this;
        }

        public Manage_SearchForACandidatePage SearchNewCandidate()
        {
            formCompletionHelper.EnterText(FirstName,_dataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, _dataHelper.LastName);
            formCompletionHelper.ClickButtonByText("Search");
            pageInteractionHelper.WaitforURLToChange("/search");
            return this;
        }

        public Manage_SearchForACandidatePage SearchDeletedCandidate()
        {
            formCompletionHelper.EnterText(FirstName, _dataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, _dataHelper.LastName);
            formCompletionHelper.ClickButtonByText("Search");
            pageInteractionHelper.WaitforURLToChange("/search");
            pageInteractionHelper.VerifyText(NoCandidateInfo, "check the spelling of first and last names");
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
