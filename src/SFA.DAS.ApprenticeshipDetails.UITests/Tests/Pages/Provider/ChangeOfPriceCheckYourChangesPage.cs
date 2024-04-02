using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider
{
    public class ChangeOfPriceCheckYourChangesPage : ChangePriceNegotiationAmountsPage
    {
        #region Helpers and Context

        private string _pageTitle;

        #endregion Helpers and Context

        protected override string PageTitle => _pageTitle;
        private static By SendButton => By.Id("buttonSubmitChangeOfPrice");
        private static By EmployerDoesNotNeedToApproveHeading => By.XPath("//h2[contains(text(),'The employer does not need to approve this change as the price has not increased')]");
        private static By GoBackToEditChangesLink => By.Id("linkGoBackToEdit");
        private static By ChangeTrainingPriceLink => By.Id("linkTrainingprice");
        private static By ChangeEndPointAssessmentPriceLink => By.Id("linkEndPointAssessmentPrice");
        private static By ChangeEffectiveFromDateLink => By.Id("linkEffectiveFromDate");
        private static By ChangeReasonForChangeLink => By.Id("linkReasonForChange");

        public ChangeOfPriceCheckYourChangesPage(ScenarioContext context, bool isAutoApprove = false): base(context, false)
        {

            void SetPageTitle() => _pageTitle = isAutoApprove ? "Check your price changes" : "Check your changes before sending to the employer";

            SetPageTitle();

            VerifyPage(() => SetPageTitle());
        }

        public ProviderApprenticeDetailsPage ClickSendButton()
        {
            formCompletionHelper.Click(SendButton);
            return new ProviderApprenticeDetailsPage(context);
        }

        public ChangeOfPriceCheckYourChangesPage ValidateEmployerDoesNotNeedToApproveRequestHeadingDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EmployerDoesNotNeedToApproveHeading));
            return this;
        }

    }
}
