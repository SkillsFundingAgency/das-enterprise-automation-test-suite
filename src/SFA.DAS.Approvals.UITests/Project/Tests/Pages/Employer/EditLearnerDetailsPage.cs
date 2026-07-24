using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditLearnerDetailsPage(ScenarioContext context) : AddAndEditApprenticeDetailsBasePage(context)
    {
        private const string EditLearnerDetailsTitle = "Edit learner details";
        private const string EditApprenticeDetailsTitle = "Edit apprentice details";

        protected override string PageTitle => ResolvePageTitle();

        private string ResolvePageTitle()
        {
            var (isEditApprenticeDetailsPage, _) = pageInteractionHelper.CheckText(PageHeader, EditApprenticeDetailsTitle);

            return isEditApprenticeDetailsPage ? EditApprenticeDetailsTitle : EditLearnerDetailsTitle;
        }

        #region Helpers and Context
        #endregion

        private static By EditDateOfBirthDay => By.Id("BirthDay");
        private static By EditDateOfBirthMonth => By.Id("BirthMonth");
        private static By EditDateOfBirthYear => By.Id("BirthYear");
        private static By EditTrainingCost => By.Id("Cost");
        private static By EditEmployerReference => By.Id("Reference");
        private static By SaveButton => By.XPath("//button[text()='Save and continue']");
        private static By DeleteButton => By.LinkText("Delete");
        private static By FirstNameField => By.Name("FirstName");
        private static By LastNameField => By.Name("LastName");
        private static By InputBox(string identifier) => By.CssSelector(identifier);
        private By EditDeliveryModelLink => GetEditDeliveryModelLink();
        private By DeliveryModelValue => GetDeliveryModelValue();

        public ApproveLearnerDetailsPage EditApprenticePreApprovalAndSubmit()
        {
            EditApprenticeNameDobAndReference(editedApprenticeDataHelper.EmployerReference);
            return new ApproveLearnerDetailsPage(context);
        }

        public ConfirmChangesPage EditCourseDates()
        {
            AddValidStartDate();
            AddValidEndDate();
            Update();
            return ConfirmChangesPage();
        }

        public ConfirmLearnerDeletionPage SelectDeleteApprentice()
        {
            var learnerName = GetCurrentLearnerName();
            base.formCompletionHelper.ClickElement(DeleteButton);
            return new ConfirmLearnerDeletionPage(context, learnerName);
        }

        private string GetCurrentLearnerName()
        {
            var firstName = pageInteractionHelper.FindElement(FirstNameField)?.GetAttribute("value")?.Trim();
            var lastName = pageInteractionHelper.FindElement(LastNameField)?.GetAttribute("value")?.Trim();

            return $"{firstName} {lastName}".Trim();
        }

        public ConfirmChangesPage EditCourse(string larsCode)
        {
            EmployerClickEditCourseLink().EmployerSelectsAnotherCourse(larsCode);

            Update();

            return ConfirmChangesPage();
        }

        public ConfirmChangesPage EditCostCourseAndReference()
        {
            EditCostCourseAndReference(editedApprenticeDataHelper.EmployerReference);
            return ConfirmChangesPage();
        }

        public ConfirmChangesPage EditApprenticeNameDobAndReference()
        {
            EditApprenticeNameDobAndReference(editedApprenticeDataHelper.EmployerReference);
            return ConfirmChangesPage();
        }

        public ConfirmChangesPage EditApprenticeStartDateOutsideOfReservation()
        {
            var startDate = apprenticeCourseDataHelper.CourseStartDate.AddMonths(-3);
            EnterStartDate(startDate);

            return ConfirmChangesPage();
        }

        public AfterEditApproveLearnerDetailsPage ContinueToAddValidApprenticeDetails()
        {
            AddValidEmail();

            formCompletionHelper.EnterText(EditDateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(EditDateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(EditDateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);

            AddValidEndDate();

            formCompletionHelper.EnterText(EditTrainingCost, apprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EditEmployerReference, apprenticeDataHelper.EmployerReference);
            formCompletionHelper.ClickElement(SaveButton);
            return new AfterEditApproveLearnerDetailsPage(context);
        }

        public ConfirmChangesPage ContinueToAddValidEmailDetails()
        {
            EditEmail();
            return ConfirmChangesPage();
        }

        internal List<IWebElement> GetAllEditableBoxes()
        {
            return
            [
                .. pageInteractionHelper.FindElements(InputBox("input[type='text']"))
,
                .. pageInteractionHelper.FindElements(InputBox("input[type='number']")),
            ];
        }

        private EditLearnerDetailsPage AddValidStartDate()
        {
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseDataHelper.CourseStartDate.Year);
            return this;
        }

        private EditLearnerDetailsPage AddValidEndDate()
        {
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            return this;
        }

        private ConfirmChangesPage ConfirmChangesPage() => new(context);

        public SelectDeliveryModelPage ClickEditDeliveryModelLink()
        {
            formCompletionHelper.ClickElement(EditDeliveryModelLink);
            return new SelectDeliveryModelPage(context);
        }

        public ConfirmChangesPage ClickUpdateDetailsButtonAfterChange()
        {
            formCompletionHelper.ClickElement(UpdateDetailsButton);
            return new ConfirmChangesPage(context);
        }

        public EditLearnerDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
        {
            string expected = deliveryModel;
            string actual = GetDeliveryModel();
            Assert.IsTrue(actual.Contains(deliveryModel), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
            return this;
        }

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModelValue);

        public EditLearnerDetailsPage ValidateDeliveryModelNotDisplayed()
        {
            string actual = GetDeliveryModel();
            if (actual.Contains("Regular") || actual.Contains("Flexi-job agency") || actual.Contains("Portable flexi-job"))
            {
                throw new Exception("Apprentice details page references delivery model");
            }
            else return this;
        }

        public bool IsEditDeliveryModelLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditDeliveryModelLink);

        public bool ConfirmDeliveryModelLabelText(string deliveryModel)
        {
            if (pageInteractionHelper.VerifyText(DeliveryModelValue, deliveryModel) == true)
            {
                return true;
            }
            else return false;
        }

        public ConfirmApprenticeshipDeliveryModelPage ClickEditDeliveryModel()
        {
            formCompletionHelper.ClickElement(EditDeliveryModelLink);
            return new ConfirmApprenticeshipDeliveryModelPage(context);
        }

        public ApproveLearnerDetailsPage SaveEditedTrainingDetails()
        {
            formCompletionHelper.ClickElement(SaveButton);
            return new ApproveLearnerDetailsPage(context);
        }

        public EditLearnerDetailsPage ValidateTrainingCourseNotEditable()
        {
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(TrainingCourseEditLink), "Change Training Course Link is displayed");
            return this;
        }

        public EditLearnerDetailsPage ValidateMaxFundingBandForEditApprentice()
        {
            ValidateMaxFundingBand();
            return this;
        }

        public ApproveLearnerDetailsPage UpdateTotalApprenticeshipPrice()
        {
            formCompletionHelper.EnterText(EditTrainingCost, apprenticeDataHelper.TrainingPrice + 500);
            formCompletionHelper.ClickElement(SaveButton);
            return new ApproveLearnerDetailsPage(context);
        }

        private By GetEditDeliveryModelLink()
        {
            return pageInteractionHelper.GetUrl().Contains("/unapproved")
                ? By.Id("change-delivery-model-link")
                : By.CssSelector("button[name='ChangeDeliveryModel']");
        }

        private By GetDeliveryModelValue()
        {
            return pageInteractionHelper.GetUrl().Contains("/unapproved")
                ? By.Id("delivery-model-value")
                : By.XPath("//*[@id=\"editApprenticeship\"]/div[7]/p[2]");
        }
    }
}
