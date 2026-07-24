using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ResumePymtToTrainingProviderPage(ScenarioContext context) : ChangeApprenticeStatus(context)
    {
        protected override string PageTitle => "Resume payments to training provider";
        private By ConfirmChangesButton => By.Id("submit-change-payments");

        public new PaymentsResumedConfirmationPage SelectResumePymtAndConfirm()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes, resume payments");
            formCompletionHelper.ClickElement(ConfirmChangesButton);
            return new (context);
        }
    }
}