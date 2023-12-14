using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApprenticeshipTrainingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Apprenticeship training";

        private static By JobRoleSelector => By.CssSelector("#SelectedStandardId");

        private static By NoOfApprenticeSelector => By.CssSelector("#opportunity-application-apprentices");

        private static By StartMonth => By.CssSelector("#opportunity-application-start-month");

        private static By StartYear => By.CssSelector("#opportunity-application-start-year");

        private static By PanelEstimateSelector => By.CssSelector("#panel-estimate");

        private static By AmountEstimateSelector => By.CssSelector("#panel-estimate #field-estimate");

        protected override By ContinueButton => By.CssSelector("#opportunity-criteria-continue");

        public ApprenticeshipTrainingPage(ScenarioContext context) : base(context) { }

        public CreateATransfersApplicationPage EnterAppTrainingDetailsAndContinue()
        {
            EnterDetails(); Continue();

            return new CreateATransfersApplicationPage(context);
        }

        public ApprenticeshipTrainingPage EnterAmountMoreThanAvailableFunding()
        {
            SetCourseCost();

            tMDataHelper.NoOfApprentice = ((GetPledgeDetail().Amount / tMDataHelper.Cost) + 1);

            formCompletionHelper.EnterText(NoOfApprenticeSelector, tMDataHelper.NoOfApprentice);

            Continue();

            return this;
        }

        private void SetCourseCost()
        {
            tMDataHelper.NoOfApprentice = 1;

            EnterDetails();

            tMDataHelper.Cost = RegexHelper.GetAmount(pageInteractionHelper.GetText(AmountEstimateSelector));
        }

        private void EnterDetails()
        {
            formCompletionHelper.EnterText(JobRoleSelector, tMDataHelper.Course);

            VerifyTrainingCost();

            SelectRadioOptionByText("No, show me apprenticeship training providers");
        }

        private void VerifyTrainingCost()
        {
            void RetryAction()
            {
                var startDate = tMDataHelper.CourseStartDate;
                formCompletionHelper.EnterText(NoOfApprenticeSelector, tMDataHelper.NoOfApprentice);
                formCompletionHelper.EnterText(StartMonth, startDate.ToString("MM"));
                formCompletionHelper.EnterText(StartYear, startDate.ToString("yyyy"));
                formCompletionHelper.Click(NoOfApprenticeSelector);
            }

            RetryAction();
            VerifyElement(PanelEstimateSelector, $"Estimated yearly cost for apprenticeship training:\r\n£{tMDataHelper.GetEstimatedCostOfTrainingForApplicationDetail()}", RetryAction);

        }
    }
}