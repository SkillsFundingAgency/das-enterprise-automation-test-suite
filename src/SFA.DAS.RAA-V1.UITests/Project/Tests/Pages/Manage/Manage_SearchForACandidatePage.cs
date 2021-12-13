using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_SearchForACandidatePage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Search for a candidate";

        #region Helpers and Context
        private readonly FAADataHelper _faaDataHelper;
        #endregion

        private By FirstName => By.Id("SearchViewModel_FirstName");

        private By LastName => By.Id("SearchViewModel_LastName");

        private By NoCandidateInfo => By.CssSelector(".form-group");

        private By CandidateAddress => By.CssSelector(".candidate-address");

        public Manage_SearchForACandidatePage(ScenarioContext context) : base(context) => _faaDataHelper = context.Get<FAADataHelper>();

        public Manage_SearchForACandidatePage Search()
        {
            var (_, _, firstname, lastname) = objectContext.GetFAALogin();
            formCompletionHelper.EnterText(FirstName, firstname);
            formCompletionHelper.EnterText(LastName, lastname);
            formCompletionHelper.ClickButtonByText("Search");
            pageInteractionHelper.WaitforURLToChange("/search");
            return this;
        }

        public Manage_SearchForACandidatePage VerifyCandidateDeletion()
        {

            pageInteractionHelper.VerifyText(NoCandidateInfo, "check the spelling of first and last names");
            return this;
        }

        public Manage_MyApplicationsPage ViewApplications()
        {
            List<IWebElement> filteredRows = pageInteractionHelper.GetLinks("Select candidate");
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(filteredRows));
            return new Manage_MyApplicationsPage(context);
        }

        public void VerifyUpdatedCandidateDetails()
        {
            pageInteractionHelper.VerifyText(CandidateAddress, _faaDataHelper.NewPostCode);
        }
    }
}
