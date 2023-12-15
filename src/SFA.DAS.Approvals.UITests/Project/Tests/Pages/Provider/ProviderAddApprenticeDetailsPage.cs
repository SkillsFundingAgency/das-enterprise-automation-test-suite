using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsPage(ScenarioContext context, bool isFlexiPaymentPilotLearner = false) : AddAndEditApprenticeDetailsBasePage(context)
    {
        protected override string PageTitle => "Add apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading, .govuk-heading-xl");
        private static By AddButton => By.XPath("//button[contains(text(),'Add')]");
        private static By DeliveryModelLabel => By.Id("delivery-model-label");
        private static By DeliveryModelType => By.Id("delivery-model-value");
        private static By EditDeliverModelLink => By.Id("change-delivery-model-link");
        private static By Uln => By.Id("Uln");

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetails()
        {
            EnterUln();
            EnterApprenticeMandatoryValidDetails();
            EnterDob();

            SubmitValidTrainingDetails();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private void SubmitValidTrainingDetails()
        {
            EnterTrainingStartDate(apprenticeCourseDataHelper.CourseStartDate);

            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers() && !isFlexiPaymentPilotLearner) EnterStartDate(DateTime.Now);

            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            if (isFlexiPaymentPilotLearner) AddPlannedEndDateDay(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference(isFlexiPaymentPilotLearner);

            formCompletionHelper.ClickElement(AddButton);

            var page = new ProviderRPLPage(context);

            if (tags.IsAddRplDetails()) page.SelectYesAndContinue().EnterRPLDataAndContinue();

            else page.SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();
        }

        private void SubmitValidPersonalDetails()
        {
            EnterUln();

            EnterApprenticeMandatoryValidDetails();

            EnterDob();
        }

        internal ProviderOverlappingTrainingDateThereMayBeProblemPage SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails()
        {
            EnterUln(objectContext.GetUlnForOLTD());

            EnterApprenticeName();

            EnterApprenticeEmail($"NEW_{apprenticeDataHelper.ApprenticeEmail}");

            EnterDob();

            EnterStartDate(objectContext.GetStartDate());

            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(AddButton);

            return new ProviderOverlappingTrainingDateThereMayBeProblemPage(context);
        }

        internal ProviderApproveApprenticeDetailsPage SubmitNullTrainingDetails()
        {
            SubmitValidPersonalDetails();
            formCompletionHelper.ClickElement(AddButton);
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private new void EnterApprenticeMandatoryValidDetails()
        {
            EnterApprenticeName();

            if (tags.IsAsListedEmployer()) return;

            EnterApprenticeEmail();
        }

        private void EnterTrainingStartDate(DateTime date)
        {
            if (isFlexiPaymentPilotLearner)
            {
                ClickActualStartDateDay();
                EnterActualStartDate(date);
            }
            else
            {
                ClickStartMonth();
                EnterStartDate(date);
            }
        }

        public void ValidateFlexiJobContent() => DeliveryModelAssertions("Flexi-job agency");

        private void DeliveryModelAssertions(string delModelType)
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(DeliveryModelLabel);

            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel), "Delivery Model Label not displayed");
            StringAssert.StartsWith(delModelType, pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink), "Edit Delivery Model link not displayed");
        }

        private void EnterUln() => EnterUln(apprenticeDataHelper.ApprenticeULN);

        private void EnterUln(string uln) => formCompletionHelper.EnterText(Uln, uln);

        private void AddPlannedEndDateDay(DateTime dateTime) => formCompletionHelper.EnterText(EndDateDay, dateTime.Day);
    }
}