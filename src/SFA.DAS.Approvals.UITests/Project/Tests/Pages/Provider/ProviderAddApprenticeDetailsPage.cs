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
        private readonly bool  _isFlexiPaymentPilotProvider;

        private readonly bool _isFlexiPaymentPilotLearner;
        protected override string PageTitle => "Add apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading, .govuk-heading-xl");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");
        private static By DeliveryModelLabel => By.XPath("//*[@id='addApprenticeship']/div[2]/dl/div[3]/dt");
        private static By DeliveryModelType => By.XPath("//*[@id='addApprenticeship']/div[2]/dl/div[3]/dd[1]");
        private static By EditDeliverModelLink => By.Name("ChangeDeliveryModel");
        private static By Uln => By.Id("Uln");

        public ProviderAddApprenticeDetailsPage(ScenarioContext context, bool isFlexiPaymentPilotLearner = false) : base(context) 
        {
            _isFlexiPaymentPilotProvider = tags.Contains("flexi-payments");
            _isFlexiPaymentPilotLearner = isFlexiPaymentPilotLearner;
        }

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetails(bool isFlexiPaymentPilotLearner = false)
        {
            SubmitValidPersonalDetails();
            SubmitValidTrainingDetails();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private void SubmitValidTrainingDetails()
        {
            if (objectContext.HasStartDate()) EnterTrainingStartDate(objectContext.GetStartDate());
            else EnterTrainingStartDate(apprenticeCourseDataHelper.CourseStartDate);


            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers()) EnterStartDate(DateTime.Now);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);
            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(ContinueButton);

            if (rpl)
                new ProviderRPLPage(context).SelectYesAndContinue().EnterRPLDataAndContinue();
            else
                new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();
        }

        private void SubmitValidPersonalDetails()
        {
            if (objectContext.HasUlnForOLTD()) formCompletionHelper.EnterText(Uln, objectContext.GetUlnForOLTD());
            else formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());

            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            //if (_isFlexiPaymentPilotProvider) AddFlexiPaymentsPilotSelection(isFlexiPaymentPilotLearner);

            if (objectContext.HasUlnForOLTD()) formCompletionHelper.EnterText(Uln, objectContext.GetUlnForOLTD());
            else formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());
        }

        internal ProviderOverlappingTrainingDateThereMayBeProblemPage SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails()
        {
            SubmitValidPersonalDetails();

            EnterStartDate(objectContext.HasStartDate() ? objectContext.GetStartDate() : apprenticeCourseDataHelper.CourseStartDate);
            EnterStartDate(objectContext.GetStartDate());

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(ContinueButton);

            return new ProviderOverlappingTrainingDateThereMayBeProblemPage(context);
        }

        internal ProviderApproveApprenticeDetailsPage SubmitNullTrainingDetails()
        {
            SubmitValidPersonalDetails();
            formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private void AddFlexiPaymentsPilotSelection(bool isFlexiPaymentPilotLearner)
        {
            if (isFlexiPaymentPilotLearner) SelectRadioOptionByForAttribute("IsOnFlexiPaymentPilot");
            else SelectRadioOptionByForAttribute("IsOnFlexiPaymentPilot-no");
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
    }
}