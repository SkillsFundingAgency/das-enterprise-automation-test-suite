using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeDetailsPage(ScenarioContext context, bool isFlexiPaymentPilotLearner = false) : ProviderEditApprenticeCoursePage(context)
    {
        protected override string PageTitle => "Edit apprentice details";
        private static By ChangeDeliveryModelLink => By.Name("ChangeDeliveryModel");
        private static By UpdateDetailsBtn => By.Id("continue-button");
        private static By DeliveryModelType => By.Id("delivery-model-value");
        private static By Uln => By.Id("Uln");
        private static By DeleteButton => By.LinkText("Delete");
        private static By InputBox => By.ClassName("govuk-input"); //By.TagName("input");
        private static By ActualStartDateDay => By.Id("ActualStartDay");
        public static By ActualStartDateMonth => By.Id("ActualStartMonth");
        public static By ActualStartDateYear => By.Id("ActualStartYear");
        private static By TrainingCost => By.Id("Cost");
        private static By TrainingPrice => By.Id("TrainingPrice");
        private static By EndPointAssessmentPrice => By.Id("EndPointAssessmentPrice");
        private static By EmployerReference => By.Id("Reference");
        private static By ChangeSimplifiedPaymentsPilotLink => By.Id("change-pilot-status-link");
        private static By SaveButton => By.XPath("//button[contains(text(),'Save')]");

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

        public ProviderApproveApprenticeDetailsPage EnterUlnAndSave(bool IsRplPageShown)
        {
            EnterUln();

            if (isFlexiPaymentPilotLearner)
            {
                AddActualStartDateDay(apprenticeCourseDataHelper.CourseStartDate);
                AddPlannedEndDateDay(apprenticeCourseDataHelper.CourseEndDate);
                AddTrainingPrice(apprenticeDataHelper.TrainingPrice);
                AddEndpointAssessmentPrice(apprenticeDataHelper.EndpointAssessmentPrice);
            }

            formCompletionHelper.ClickElement(SaveButton);

            if (IsRplPageShown) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).ContinueWithAlreadySelectedStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
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

        public ProviderApproveApprenticeDetailsPage SelectSaveAndUpdateRPLAsNo()
        {
            formCompletionHelper.ClickElement(SaveButton);

            new ProviderRPLPage(context).SelectNoAndContinue();

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

            formCompletionHelper.ClickElement(SaveButton);

            new ProviderRPLPage(context).SelectNoAndContinue();

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

        public ProviderApproveApprenticeDetailsPage ClickSave(bool IsRplPageShown)
        {
            formCompletionHelper.ClickElement(SaveButton);

            if (IsRplPageShown) new ProviderRPLPage(context).SelectNoAndContinue();

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
            var uln = apprenticeDataHelper.ApprenticeULN;

            if (objectContext.IsSameApprentice()) uln = context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().ToList().First().Item1.ApprenticeULN;

            EnterText(Uln, uln);
        }

        private void AddActualStartDateDay(DateTime dateTime) => formCompletionHelper.EnterText(ActualStartDateDay, dateTime.Day);

        private void AddPlannedEndDateDay(DateTime dateTime) => formCompletionHelper.EnterText(EndDateDay, dateTime.Day);

        private void EnterText(By by, string text) => formCompletionHelper.EnterText(by, text);

        public void AddTrainingPrice(string trainingPrice) => formCompletionHelper.EnterText(TrainingPrice, trainingPrice);

        public void AddEndpointAssessmentPrice(string epa) => formCompletionHelper.EnterText(EndPointAssessmentPrice, epa);
    }
}
