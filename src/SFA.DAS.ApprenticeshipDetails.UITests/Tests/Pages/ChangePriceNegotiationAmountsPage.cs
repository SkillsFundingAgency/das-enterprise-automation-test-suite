using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages
{
    public class ChangePriceNegotiationAmountsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Change the training price and/or the end-point assessment price";

        protected override By ContinueButton => By.Id("buttonSubmitForm");

        private static By TrainingPrice = By.Id("ApprenticeshipTrainingPrice");

        private static By EndpointAssessmentPrice = By.Id("ApprenticeshipEndPointAssessmentPrice");

        private static By EffectiveFromDate_Day = By.Id("EffectiveFromDate_Day");

        private static By EffectiveFromDate_Month = By.Id("EffectiveFromDate_Month");

        private static By EffectiveFromDate_Year = By.Id("EffectiveFromDate_Year");

        private static By ReasonPriceChange = By.Id("ReasonForChangeOfPrice");

        private static By ChangeTrainingAndOrEpaPriceErrorMessage = By.CssSelector("div[role=\"alert\"] li a[href=\"#\"]");


        public void EnterValidChangeOfPriceDetails()
        {
            formCompletionHelper.EnterText(TrainingPrice, 5000);
            formCompletionHelper.EnterText(EndpointAssessmentPrice, 1000);
            formCompletionHelper.EnterText(EffectiveFromDate_Day, 10);
            formCompletionHelper.EnterText(EffectiveFromDate_Month, 01);
            formCompletionHelper.EnterText(EffectiveFromDate_Year, 2024);
            formCompletionHelper.EnterText(ReasonPriceChange, "AutomationTest");

            formCompletionHelper.Click(ContinueButton);
        }

        public ChangePriceNegotiationAmountsPage ClickContinueButtonWithValidationErrors()
        {
            formCompletionHelper.Click(ContinueButton);
            return this;
        }

        public void ConfirmValidationErrorMessagesDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(pageInteractionHelper.GetText(ChangeTrainingAndOrEpaPriceErrorMessage), "");
            });
        }

    }

}
