using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewApprenticeDetailsPage : ViewYourCohort
    {
        protected override string PageTitle
        {
            get
            {
                int noOfApprentice = TotalNoOfApprentices();
                return noOfApprentice < 2 ? "View apprentice details" : $"View {noOfApprentice} apprentices' details";
            }
        }

        private By InputBox => By.TagName("input");

        private static By CohortStatus => By.Id("cohortStatus");

        public ViewApprenticeDetailsPage(ScenarioContext context) : base(context) { }

        internal List<IWebElement> GetAllEditBoxes() => pageInteractionHelper.FindElements(InputBox);

        public void ValidateCohortStatus(string status) => pageInteractionHelper.VerifyText(CohortStatus, status);
    }
}
