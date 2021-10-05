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
            EnterDetailsAndContinue();

            return new CreateATransfersApplicationPage(_context);
        }

        public ApprenticeshipTrainingPage EnterAmountMoreThanAvailableFunding()
        {
            tMDataHelper.NoOfApprentice = 1;

            EnterDetails();

            var estimatedAmount = regexHelper.GetAmount(pageInteractionHelper.GetText(AmountEstimateSelector));

            tMDataHelper.NoOfApprentice = ((objectContext.GetPledgeAmount() / estimatedAmount) + 1);

            EnterDetailsAndContinue();

            return this;
        }

        private void EnterDetails()
        {
            var startDate = tMDataHelper.CourseStartDate;

            formCompletionHelper.EnterText(JobRoleSelector, tMDataHelper.Course);
            formCompletionHelper.EnterText(NoOfApprenticeSelector, tMDataHelper.NoOfApprentice);
            formCompletionHelper.EnterText(StartMonth, startDate.ToString("MM"));
            formCompletionHelper.EnterText(StartYear, startDate.ToString("yyyy"));

            formCompletionHelper.Click(NoOfApprenticeSelector);

            VerifyPage(PanelEstimateSelector, "your apprenticeship training will cost:");

            SelectRadioOptionByText("No, show me apprenticeship training providers");
        }

        private void EnterDetailsAndContinue() { EnterDetails(); Continue(); }
    }
}