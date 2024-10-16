using DnsClient;
using OpenQA.Selenium;
using Polly;
using SFA.DAS.FAT.UITests.Project;
using SFA.DAS.FAT.UITests.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class WeHaveveSharedThisWithTrainingProvidersPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "We've shared this with training providers";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        private static By ManageYourTrainingRequest => By.LinkText("Manage your training requests");

        public FindApprenticeshipTrainingAndManageRequestsPage ReturnToRequestPage()
        {
            formCompletionHelper.Click(ManageYourTrainingRequest);

            return new(context);
        }
    }

    public class FindApprenticeshipTrainingAndManageRequestsPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "Find apprenticeship training and manage requests";

        public TrainingRequestDetailPage SelectActiveRequest()
        {
            string trainingRequestName = objectContext.GetTrainingCourseName();

            formCompletionHelper.Click(By.LinkText(trainingRequestName));

            return new(context, trainingRequestName);
        }
    }

    public class TrainingRequestDetailPage : FATBasePage
    {
        protected override string PageTitle => trainingRequestName;

        protected override bool DoVerifyPage => false;

        private static string trainingRequestName;

        private static By CancelRequest => By.LinkText("cancel your request");

        public TrainingRequestDetailPage(ScenarioContext context, string requestName) : base(context)
        {
            trainingRequestName = requestName;

            VerifyPage();
        }

        public CancelYourRequestPage CancelYourRequest()
        {
            formCompletionHelper.Click(CancelRequest);

            return new(context);
        }
    }


    public class CancelYourRequestPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "Cancel your request";

        private static By CancelButton => By.CssSelector("#main-content button.govuk-button[type='submit']");

        public WeCancelledYourRequestPage SubmitCancelRequest()
        {
            formCompletionHelper.Click(CancelButton);

            return new(context);
        }
    }

    public class WeCancelledYourRequestPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "We've cancelled your request";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
    }
}