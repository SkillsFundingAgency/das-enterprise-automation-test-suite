using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_SearchForACandidatePage(ScenarioContext context) : Manage_HeaderSectionBasePage(context)
    {
        protected override string PageTitle => "Search for a candidate";

        private static By FirstName => By.Id("SearchViewModel_FirstName");

        private static By LastName => By.Id("SearchViewModel_LastName");

        private static By NoCandidateInfo => By.CssSelector(".form-group");

        private static By CandidateAddress => By.CssSelector(".candidate-address");

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
            pageInteractionHelper.VerifyText(CandidateAddress, FAADataHelper.NewPostCode);
        }
    }
}
