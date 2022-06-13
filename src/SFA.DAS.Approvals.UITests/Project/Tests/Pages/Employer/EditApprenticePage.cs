using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticePage : EditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Edit apprentice details";

        private By EditDateOfBirthDay => By.Id("BirthDay");
        private By EditDateOfBirthMonth => By.Id("BirthMonth");
        private By EditDateOfBirthYear => By.Id("BirthYear");
        private By EditTrainingCost => By.Id("Cost");
        private By EditEmployerReference => By.Id("Reference");
        private By EditSaveAndContinueButton => By.CssSelector("#continue-button");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox(string identifier) => By.CssSelector(identifier);

        public EditApprenticePage(ScenarioContext context) : base(context) { }

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

            AddValidEndDate();
            
            formCompletionHelper.EnterText(EditTrainingCost, apprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EditEmployerReference, apprenticeDataHelper.EmployerReference);
            formCompletionHelper.ClickElement(EditSaveAndContinueButton);
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

        private EditApprenticePage AddValidStartDate()
        {
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseDataHelper.CourseStartDate.Year);
            return this;
        }

        private EditApprenticePage AddValidEndDate()
        {
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            return this;
        }

        private ConfirmChangesPage ConfirmChangesPage() => new ConfirmChangesPage(context);
    }
}