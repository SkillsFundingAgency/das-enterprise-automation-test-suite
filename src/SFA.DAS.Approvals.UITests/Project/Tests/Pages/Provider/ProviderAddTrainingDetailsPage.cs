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
        protected override By PageHeader => By.CssSelector(".das-show > h1");
        protected override string PageTitle => "Add training details";
        protected override By ContinueButton => By.XPath("//button[text()='Add']");
        private By DeliveryModelLabel => By.XPath("//p[text()='Apprenticeship delivery model']");
        private By DeliveryModelType => By.XPath("//p[text()='Apprenticeship delivery model'] // following-sibling :: p");
        private By EditDeliverModelLink => By.Name("ChangeDeliveryModel");

        public ProviderAddTrainingDetailsPage(ScenarioContext context) : base(context) { }

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeTrainingDetails()
        {
            ClickStartMonth();

            if (objectContext.HasStartDate()) EnterStartDate(objectContext.GetStartDate());
            else  EnterStartDate(apprenticeCourseDataHelper.CourseStartDate);

            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers()) EnterStartDate(DateTime.Now);

            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(ContinueButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        internal ProviderOverlappingTrainingDateThereMayBeProblemPage SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails()
        {
            ClickStartMonth();
     
            EnterStartDate(objectContext.GetStartDate());

            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(ContinueButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderOverlappingTrainingDateThereMayBeProblemPage(context);
        }



        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(context);
        }

        internal ProviderBeforeYouStartBulkUploadPage SelectBulkUpload()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderBeforeYouStartBulkUploadPage(context);
        }

        private bool CheckRPLCondition(bool rpl = false)
        {
            var year = Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear));
            if (Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth)) > 7 & year == 2022) rpl = true;
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
    }
}
