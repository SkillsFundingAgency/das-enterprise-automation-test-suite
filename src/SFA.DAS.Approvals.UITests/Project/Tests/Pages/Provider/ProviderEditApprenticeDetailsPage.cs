using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeDetailsPage : ProviderEditApprenticeCoursePage
    {
        private readonly bool _isFlexiPaymentPilotLearner;
        protected override string PageTitle => "Edit apprentice details";
        private By ChangeDeliveryModelLink => By.Name("ChangeDeliveryModel");
        private By UpdateDetailsBtn => By.Id("continue-button");
        private By DeliveryModelType => By.Id("delivery-model-value");
        private By TrainingName => By.XPath("//*[@id='trainingName']");
        private By Uln => By.Id("Uln");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox => By.ClassName("govuk-input"); //By.TagName("input");
        private By ActualStartDateDay => By.Id("ActualStartDay");
        public By ActualStartDateMonth => By.Id("ActualStartMonth");
        public By ActualStartDateYear => By.Id("ActualStartYear");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By ChangeSimplifiedPaymentsPilotLink => By.Id("change-pilot-status-link");
        protected By SaveButton => By.XPath("//button[contains(text(),'Save')]");

        public ProviderEditApprenticeDetailsPage(ScenarioContext context, bool isFlexiPaymentPilotLearner = false) : base(context)
        {
            _isFlexiPaymentPilotLearner = isFlexiPaymentPilotLearner;
        }

        public SelectDeliveryModelPage ClickEditDeliveryModel()
        {
            formCompletionHelper.ClickElement(ChangeDeliveryModelLink);
            return new SelectDeliveryModelPage(context);
        }

        public ProviderConfirmChangesPage ClickUpdateDetails()
        {
            formCompletionHelper.ClickElement(UpdateDetailsBtn);
            return new ProviderConfirmChangesPage(context);
        }

        public ProviderEditApprenticeDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
        {
            string expected = deliveryModel;
            string actual = GetDeliveryModel();
            Assert.IsTrue(actual.Contains(expected), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
            return this;
        }

        public ProviderApproveApprenticeDetailsPage EnterUlnAndSave()
        {
            EnterUln();
            return CheckRPLConditionAndSave();
        }

        public ProviderApproveApprenticeDetailsPage EnterUlnAndTrainingStartEndDaysThenSave(int apprenticeNumber)
        {
            EnterUlnForFlexiPayments(apprenticeNumber);

            return CheckRPLConditionAndSave();
        }


        public SelectDeliveryModelPage EnterUlnAndSelectEditDeliveryModel()
        {
            EnterUln();
            formCompletionHelper.ClickElement(ChangeDeliveryModelLink);
            return new SelectDeliveryModelPage(context);
        }

        public ProviderEditApprenticeDetailsPage EditAllApprenticeDetailsExceptCourse()
        {
            formCompletionHelper.EnterText(FirstNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, editedApprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, editedApprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, editedApprenticeDataHelper.DateOfBirthYear);
            
            EnterUln();

            formCompletionHelper.ClickElement(StartDateMonth);
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseDataHelper.CourseStartDate.Year);
            if (loginCredentialsHelper.IsLevy == false)
            {
                DateTime now = DateTime.Now;
                formCompletionHelper.EnterText(StartDateMonth, now.Month);
                formCompletionHelper.EnterText(StartDateYear, now.Year);
            }
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            formCompletionHelper.EnterText(TrainingCost, "1" + editedApprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, editedApprenticeDataHelper.EmployerReference);

            return this;
        }

        public ProviderConfirmApprenticeDeletionPage DeleteApprentice()
        {
            formCompletionHelper.ClickElement(DeleteButton);
            return new ProviderConfirmApprenticeDeletionPage(context);
        }

        public ProviderEditApprenticeDetailsPage ValidateEditableTextBoxes(int numberOfExpectedTextBoxes)
        {
            GetAllEditBoxes();

            int numberOfTextBoxesDisplayed = GetAllEditBoxes().Count;

            if (numberOfTextBoxesDisplayed != numberOfExpectedTextBoxes)
                throw new Exception($"expected editable boxes were: [{numberOfExpectedTextBoxes}] actual editable boxes displayed are: [{numberOfTextBoxesDisplayed}]");
            else
                return this;
        }

        public ProviderApproveApprenticeDetailsPage CheckRPLConditionAndSave()
        {
            if (_isFlexiPaymentPilotLearner)
            {
                AddActualStartDateDay(apprenticeCourseDataHelper.CourseStartDate);
                AddPlannedEndDateDay(apprenticeCourseDataHelper.CourseEndDate);
            }

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage SelectSaveAndUpdateRPLAsNo()
        {
            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();
            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage EditCopApprenticeDetails()
        {
            formCompletionHelper.ClickElement(StartDateMonth);
            DateTime now = DateTime.Now;
            formCompletionHelper.EnterText(StartDateMonth, now.Month);
            formCompletionHelper.EnterText(StartDateYear, now.Year);
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            formCompletionHelper.EnterText(TrainingCost, "1" + editedApprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, editedApprenticeDataHelper.EmployerReference);

            bool rpl = CheckRPLCondition(false);

            formCompletionHelper.ClickElement(SaveButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ValidateTrainingCourseNotEditable()
        {
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(TrainingCourseEditLink), "Change Training Course Link is displayed");
            return this;
        }

        public ProviderOverlappingTrainingDateThereMayBeProblemPage ClickSaveWhenOltd()
        {
            formCompletionHelper.ClickElement(SaveButton);
            return new ProviderOverlappingTrainingDateThereMayBeProblemPage(context);
        }
        public ProviderEditApprenticeDetailsPage EditCost(int cost)
        {
            formCompletionHelper.EnterText(TrainingCost, cost);
            return this;
        }

        public ProviderEditApprenticeDetailsPage EditStartDate(string month, string year)
        {
            EnterText(StartDateMonth, month);
            EnterText(StartDateYear, year);
            return this;
        }

        public ProviderEditApprenticeDetailsPage EditEndDate(string month, string year)
        {
            EnterText(EndDateMonth, month);
            EnterText(EndDateYear, year);
            return this;
        }

        public ProviderConfirmApprenticeDeliveryModelPage SelectEditDeliveryModel()
        {
            formCompletionHelper.ClickElement(ChangeDeliveryModelLink);
            return new ProviderConfirmApprenticeDeliveryModelPage(context);
        }

        public ProviderApproveApprenticeDetailsPage ClickSave()
        {
            bool rpl = CheckRPLCondition(false);
            formCompletionHelper.ClickElement(SaveButton);
            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public SimplifiedPaymentsPilotPage ClickEditSimplifiedPaymentsPilotLink()
        {
            formCompletionHelper.ClickElement(ChangeSimplifiedPaymentsPilotLink);
            return new SimplifiedPaymentsPilotPage(context);
        }

        internal List<IWebElement> GetAllEditBoxes() => pageInteractionHelper.FindElements(InputBox);

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModelType);

        private void EnterUln()
        {
            var uln = apprenticeDataHelper.Uln();

            if (objectContext.IsSameApprentice() && apprenticeDataHelper.Ulns.Count == 1) uln = apprenticeDataHelper.Ulns.First();

            formCompletionHelper.EnterText(Uln, uln);
        }

        private void EnterUlnForFlexiPayments(int apprenticeNumber)
        {
            if (objectContext.KeyExists<string>($"ULN{apprenticeNumber}"))
                formCompletionHelper.EnterText(Uln, objectContext.Get($"ULN{apprenticeNumber}"));
            else
                formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());
        }

        private void AddActualStartDateDay(DateTime dateTime) => formCompletionHelper.EnterText(ActualStartDateDay, dateTime.Day);
        private void AddPlannedEndDateDay(DateTime dateTime) => formCompletionHelper.EnterText(EndDateDay, dateTime.Day);

        private bool CheckRPLCondition(bool rpl = false)
        {
            _ = int.TryParse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(_isFlexiPaymentPilotLearner ? ActualStartDateYear : StartDateYear), out int year);

            _ = int.TryParse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(_isFlexiPaymentPilotLearner ? ActualStartDateMonth : StartDateMonth), out int month);

            if (month > 7 & year == 2022) rpl = true;
            if (year > 2022) rpl = true;
            return rpl;
        }

        private void EnterText(By by, string text) => formCompletionHelper.EnterText(by, text);

    }
}
