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

        internal ProviderApproveApprenticeDetailsPage SubmitValidTrainingDetails(bool isPilotLearner = false)
        {
            EnterTrainingStartDate(isPilotLearner);

            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers()) EnterStartDate(DateTime.Now);

            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            bool rpl = CheckRPLCondition(false, isPilotLearner);

            formCompletionHelper.ClickElement(ContinueButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private bool CheckRPLCondition(bool rpl = false, bool isPilotLearner = false)
        {
            var year = isPilotLearner ? Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(ActualStartDateYear))
                : Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear));

            var month = isPilotLearner ? Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(ActualStartDateMonth))
                : Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth));

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

        private void EnterTrainingStartDate(bool isPilotLearner)
        {
            if (isPilotLearner)
            {
                ClickActualStartDateDay();
                EnterActualStartDate(apprenticeCourseDataHelper.CourseStartDate);
            }
            else
            {
                ClickStartMonth();
                EnterStartDate(apprenticeCourseDataHelper.CourseStartDate);
            }
        }
    }
}
