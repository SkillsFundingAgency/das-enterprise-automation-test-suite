using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticeDetailsPage : EditApprenticeDetailsBasePage
    {
        protected override string PageTitle => _pageTitle;

        #region Helpers and Context
        private readonly string _pageTitle;
        #endregion

        private By EditDateOfBirthDay => By.Id("BirthDay");
        private By EditDateOfBirthMonth => By.Id("BirthMonth");
        private By EditDateOfBirthYear => By.Id("BirthYear");
        private By EditTrainingCost => By.Id("Cost");
        private By EditEmployerReference => By.Id("Reference");
        private By EditContinueButtonPersonalDetailsPage => By.XPath("//button[contains(text(),'Continue')]");
        private By EditContinueButtonTrainingDetailsPage => By.XPath("//button[text()='Save']");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox(string identifier) => By.CssSelector(identifier);
        private By EditDeliveryModelLink => By.CssSelector("button[name='ChangeDeliveryModel']");
        private By DeliveryModelLabel => By.XPath("//*[@id='editApprenticeship']/div[7]/p[2]");

        public EditApprenticeDetailsPage(ScenarioContext context) : base(context, false)
        {
            _pageTitle = DeterminePageTitle();
            VerifyPage();
        }

        private string DeterminePageTitle()
        {
            var title = pageInteractionHelper.GetUrl().Contains("/unapproved/") 
                ? "Edit personal details" 
                : "Edit apprentice details";

            return title;
        }

        public ApproveApprenticeDetailsPage EditApprenticePreApprovalAndSubmit()
        {
            EditApprenticeNameDobAndReference(editedApprenticeDataHelper.EmployerReference);
            return new ApproveApprenticeDetailsPage(context);
        }

        public ConfirmChangesPage EditCourseDates()
        {
            AddValidStartDate();
            AddValidEndDate();
            Update();
            return ConfirmChangesPage();
        }

        protected override void EditCourse() => ClickEditCourseLink().EmployerSelectsAStandardForEditApprenticeDetailsPath();

        public ConfirmApprenticeDeletionPage SelectDeleteApprentice()
        {
           base.formCompletionHelper.ClickElement(DeleteButton);
            return new ConfirmApprenticeDeletionPage(context);
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

        public AfterEditApproveApprenticeDetailsPage ContinueToAddValidApprenticeDetails()
        {
            AddValidEmail();

            formCompletionHelper.EnterText(EditDateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(EditDateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(EditDateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);
            formCompletionHelper.ClickElement(EditContinueButtonPersonalDetailsPage);

            AddValidEndDate();
            
            formCompletionHelper.EnterText(EditTrainingCost, apprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EditEmployerReference, apprenticeDataHelper.EmployerReference);
            formCompletionHelper.ClickElement(EditContinueButtonTrainingDetailsPage);
            return new AfterEditApproveApprenticeDetailsPage(context);
        }

        public ConfirmChangesPage ContinueToAddValidEmailDetails()
        {
            EditEmail();
            return ConfirmChangesPage();
        }

        internal List<IWebElement> GetAllEditableBoxes()
        {
            return pageInteractionHelper.FindElements(InputBox("input[type='text']"))
                .Concat(pageInteractionHelper.FindElements(InputBox("input[type='number']"))).ToList();
        }

        private EditApprenticeDetailsPage AddValidStartDate()
        {
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseDataHelper.CourseStartDate.Year);
            return this;
        }

        private EditApprenticeDetailsPage AddValidEndDate()
        {
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            return this;
        }

        private ConfirmChangesPage ConfirmChangesPage() => new ConfirmChangesPage(context);

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

        public EditApprenticeDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
        {
            string expected = deliveryModel;
            string actual = GetDeliveryModel();
            Assert.IsTrue(actual.Contains(deliveryModel), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
            return this;
        }

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModelLabel);

        public EditApprenticeDetailsPage ValidateDeliveryModelNotDisplayed()
        {
            string actual = GetDeliveryModel();
            if (actual.Contains("Regular") || actual.Contains("Flexi-job agency") || actual.Contains("Portable flexi-job"))
            {
                throw new Exception("Apprentice details page references delivery model");
            }
            else return this;
        }
    }
}