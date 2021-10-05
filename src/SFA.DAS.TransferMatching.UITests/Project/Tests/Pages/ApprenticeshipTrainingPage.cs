using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApprenticeshipTrainingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Apprenticeship training";

        private readonly ScenarioContext _context;

        private By JobRoleSelector => By.CssSelector("#SelectedStandardId");

        private By NoOfApprenticeSelector => By.CssSelector("#opportunity-application-apprentices");

        private By StartMonth => By.CssSelector("#opportunity-application-start-month");

        private By StartYear => By.CssSelector("#opportunity-application-start-year");

        private By PanelEstimateSelector => By.CssSelector("#panel-estimate");

        private By AmountEstimateSelector => By.CssSelector("#panel-estimate #field-estimate");

        protected override By ContinueButton => By.CssSelector("#opportunity-criteria-continue");

        public ApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public CreateATransfersApplicationPage EnterAppTrainingDetailsAndContinue()
        {
            EnterDetails(); Continue(); 

            return new CreateATransfersApplicationPage(_context);
        }

        public ApprenticeshipTrainingPage EnterAmountMoreThanAvailableFunding()
        {
            SetCourseCost();

            tMDataHelper.NoOfApprentice = ((objectContext.GetPledgeAmount() / tMDataHelper.Cost) + 1);

            formCompletionHelper.EnterText(NoOfApprenticeSelector, tMDataHelper.NoOfApprentice);

            Continue();

            return this;
        }

        private void SetCourseCost()
        {
            tMDataHelper.NoOfApprentice = 1;

            EnterDetails();

            tMDataHelper.Cost = regexHelper.GetAmount(pageInteractionHelper.GetText(AmountEstimateSelector));
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

            VerifyPage(PanelEstimateSelector, "your apprenticeship training will cost:", RetryAction);
        }
    }
}