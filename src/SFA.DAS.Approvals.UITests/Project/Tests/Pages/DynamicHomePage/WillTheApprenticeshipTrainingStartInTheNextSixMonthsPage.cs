using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
   public class WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Will the apprenticeship training start in the next 6 months?";

        private static By ClickYesContinue => By.Id("will-apprenticeship-training-start-button");

        public AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage YesWillTrainingStartInSixMonths()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            formCompletionHelper.Click(ClickYesContinue);
            return new AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage(context);
        }
    }
}
