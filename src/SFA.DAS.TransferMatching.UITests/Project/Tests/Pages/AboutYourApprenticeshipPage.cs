using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AboutYourApprenticeshipPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Provide more detail about your apprenticeship";

        private static By MoreDetailsSelector => By.CssSelector("#more-detail");

        protected override By ContinueButton => By.CssSelector("#opportunity-criteria-continue");

        public CreateATransfersApplicationPage EnterMoreDetailsAndContinue(string pledgeId)
        {
            formCompletionHelper.EnterText(MoreDetailsSelector, !string.IsNullOrEmpty(pledgeId) ? pledgeId : Helpers.TMDataHelper.ApprenticeshipMoreDetails);

            Continue();

            return new CreateATransfersApplicationPage(context);
        }
    }
}