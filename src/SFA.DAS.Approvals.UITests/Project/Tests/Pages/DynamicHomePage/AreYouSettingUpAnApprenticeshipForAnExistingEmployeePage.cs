using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Are you setting up an apprenticeship for an existing employee?";

        private By ClickYesContinue => By.Id("apprentice-for-existing-employee-button");

        public AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage(ScenarioContext context) : base(context)  { }

        public SetUpAnApprenticeshipForAnExistingEmployeePage YesSetupForExistingEmployee()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            formCompletionHelper.Click(ClickYesContinue);
            return new SetUpAnApprenticeshipForAnExistingEmployeePage(context);
        }
    }
}