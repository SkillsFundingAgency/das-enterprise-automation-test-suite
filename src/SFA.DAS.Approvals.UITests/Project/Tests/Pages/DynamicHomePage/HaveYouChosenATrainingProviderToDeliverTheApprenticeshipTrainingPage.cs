using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Have you chosen a training provider to deliver the apprenticeship training?";

        private By ClickYesContinue => By.Id("have-you-chosen-a-training-provider-button");

        public HaveYouChosenATrainingProviderToDeliverTheApprenticeshipTrainingPage(ScenarioContext context) : base(context)  { }

        public WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage YesToTrainingProviderToDeliver()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            formCompletionHelper.Click(ClickYesContinue);
            return new WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage(context);
        }
    }
}