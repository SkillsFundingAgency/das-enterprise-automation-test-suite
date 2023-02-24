using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        private readonly bool _isFlexiPaymentPilotLearner;
        protected override string PageTitle => "Add apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading, .govuk-heading-xl");
        protected By AddButton => By.XPath("//button[contains(text(),'Add')]");
        private static By DeliveryModelLabel => By.Id("delivery-model-label");
        private static By DeliveryModelType => By.Id("delivery-model-value");
        private static By EditDeliverModelLink => By.Id("change-delivery-model-link");
        private static By Uln => By.Id("Uln");

        public ProviderAddApprenticeDetailsPage(ScenarioContext context, bool isFlexiPaymentPilotLearner = false) : base(context) 
        {
            _isFlexiPaymentPilotLearner = isFlexiPaymentPilotLearner;
        }

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetails()
        {
            SubmitValidPersonalDetails();
            SubmitValidTrainingDetails();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetailsForFlexiPaymentsPilotProvider(int apprenticeNumber)
        {
            EnterUlnForFlexiPayments(apprenticeNumber);
            EnterApprenticeMandatoryValidDetails();
            EnterDob();

            SubmitValidTrainingDetails();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private void SubmitValidTrainingDetails()
        {
            if (objectContext.HasStartDate()) EnterTrainingStartDate(objectContext.GetStartDate());
            else EnterTrainingStartDate(apprenticeCourseDataHelper.CourseStartDate);


            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers() && !_isFlexiPaymentPilotLearner) EnterStartDate(DateTime.Now);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);
            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(AddButton);

            if (rpl)
                new ProviderRPLPage(context).SelectYesAndContinue().EnterRPLDataAndContinue();
            else
                new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();
        }

        public void SubmitValidPersonalDetails()
        {
            if (objectContext.HasUlnForOLTD()) formCompletionHelper.EnterText(Uln, objectContext.GetUlnForOLTD());
            else formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());

            EnterApprenticeMandatoryValidDetails();

            EnterDob();
        }

        internal ProviderOverlappingTrainingDateThereMayBeProblemPage SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails()
        {
            SubmitValidPersonalDetails();

            EnterStartDate(objectContext.HasStartDate() ? objectContext.GetStartDate() : apprenticeCourseDataHelper.CourseStartDate);
            EnterStartDate(objectContext.GetStartDate());

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

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

            if (tags.Contains("aslistedemployer")) return;

            EnterApprenticeEmail();
        }

        private bool CheckRPLCondition(bool rpl = false)
        {
            var year = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(_isFlexiPaymentPilotLearner ? ActualStartDateYear : StartDateYear));
            var month = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(_isFlexiPaymentPilotLearner ? ActualStartDateMonth : StartDateMonth));

            if (month > 7 & year == 2022) rpl = true;
            if (year > 2022) rpl = true;
            return rpl;
        }

        private void EnterTrainingStartDate(DateTime date)
        {
            if (_isFlexiPaymentPilotLearner)
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

        private void EnterUlnForFlexiPayments(int apprenticeNumber)
        {
            if (objectContext.KeyExists<string>($"ULN{apprenticeNumber}"))
                formCompletionHelper.EnterText(Uln, objectContext.Get($"ULN{apprenticeNumber}"));
            else
                formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());
        }
    }
}