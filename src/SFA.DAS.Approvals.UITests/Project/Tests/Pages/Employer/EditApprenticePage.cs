using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EditApprenticePage(ScenarioContext context) : base(context) => _context = context;

        protected By CourseOption => By.CssSelector("#trainingCourse");
        private By EditDateOfBirthDay => By.Id("BirthDay");
        private By EditDateOfBirthMonth => By.Id("BirthMonth");
        private By EditDateOfBirthYear => By.Id("BirthYear");
        private By EditTrainingCost => By.Id("Cost");
        private By EditEmployerReference => By.Id("Reference");
        private By EditSaveAndContinueButton => By.Id("continue-button");
        private By DeleteButton => By.LinkText("Delete");
        //private By InputBox(string className) => By.ClassName(className); 
        private By InputBox(string identifier) => By.CssSelector(identifier);

        public ConfirmApprenticeDeletionPage SelectDeleteApprentice()
        {
           base.formCompletionHelper.ClickElement(DeleteButton);
            return new ConfirmApprenticeDeletionPage(_context);
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

        protected EditApprenticePage AddValidStartDate()
        {
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseDataHelper.CourseStartDate.Year);
            return this;
        }

        protected EditApprenticePage AddValidEndDate()
        {
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            return this;
        }

        protected override void SelectCourse() => formCompletionHelper.SelectFromDropDownByValue(CourseOption, editedApprenticeCourseDataHelper.EditedCourse);
        
        private ConfirmChangesPage ConfirmChangesPage() => new ConfirmChangesPage(_context);

        public AfterEditApproveApprenticeDetailsPage ContinueToAddValidApprenticeDetails()
        {
            formCompletionHelper.EnterText(EditDateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(EditDateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(EditDateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);

            AddValidEndDate();
            
            formCompletionHelper.EnterText(EditTrainingCost, apprenticeDataHelper.TrainingPrice);
            formCompletionHelper.EnterText(EditEmployerReference, apprenticeDataHelper.EmployerReference);
            formCompletionHelper.ClickElement(EditSaveAndContinueButton);
            return new AfterEditApproveApprenticeDetailsPage(_context);
        }

        internal List<IWebElement> GetAllEditableBoxes()
        {
            return pageInteractionHelper.FindElements(InputBox("input[type='text']"))
                .Concat(pageInteractionHelper.FindElements(InputBox("input[type='number']"))).ToList();
        }
    }
}