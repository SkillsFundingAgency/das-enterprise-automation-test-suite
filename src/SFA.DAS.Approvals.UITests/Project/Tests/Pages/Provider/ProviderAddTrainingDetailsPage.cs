using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddTrainingDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        private readonly bool _isFlexiPaymentPilotLearner;
        protected override By PageHeader => By.CssSelector("#draftApprenticeshipSection2 > h1");
        protected override string PageTitle => "Add training details";
        protected override By ContinueButton => AddButtonSelector;
        private static By DeliveryModelLabel => By.XPath("//p[text()='Apprenticeship delivery model']");
        private static By DeliveryModelType => By.XPath("//p[text()='Apprenticeship delivery model'] // following-sibling :: p");
        private static By EditDeliverModelLink => By.Name("ChangeDeliveryModel");

        public ProviderAddTrainingDetailsPage(ScenarioContext context, bool isFlexiPaymentPilotLearner) : base(context) => _isFlexiPaymentPilotLearner = isFlexiPaymentPilotLearner;

        internal ProviderApproveApprenticeDetailsPage SubmitValidTrainingDetails()
        {
            if (objectContext.HasStartDate()) EnterTrainingStartDate(objectContext.GetStartDate());
            else EnterTrainingStartDate(apprenticeCourseDataHelper.CourseStartDate);


            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers()) EnterStartDate(DateTime.Now);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);
            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(ContinueButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        internal ProviderApproveApprenticeDetailsPage SubmitNullTrainingDetails()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        internal ProviderOverlappingTrainingDateThereMayBeProblemPage SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails()
        {

            EnterStartDate(objectContext.HasStartDate() ? objectContext.GetStartDate() : apprenticeCourseDataHelper.CourseStartDate);
            EnterStartDate(objectContext.GetStartDate());

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(ContinueButton);

            return new ProviderOverlappingTrainingDateThereMayBeProblemPage(context);
        }

        private bool CheckRPLCondition(bool rpl = false)
        {
            var year = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(_isFlexiPaymentPilotLearner ? ActualStartDateYear : StartDateYear));
            var month = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(_isFlexiPaymentPilotLearner ? ActualStartDateMonth : StartDateMonth));

            if (month > 7 & year == 2022) rpl = true;
            if (year > 2022) rpl = true;
            return rpl;
        }

        public void ValidateFlexiJobContent() => DeliveryModelAssertions("Flexi-job agency");

        private void DeliveryModelAssertions(string delModelType)
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(DeliveryModelLabel);

            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DeliveryModelLabel), "Delivery Model Label not displayed");
            StringAssert.StartsWith(delModelType, pageInteractionHelper.GetText(DeliveryModelType), "Incorrect Delivery Model displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(EditDeliverModelLink), "Edit Delivery Model link not displayed");
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
    }
}