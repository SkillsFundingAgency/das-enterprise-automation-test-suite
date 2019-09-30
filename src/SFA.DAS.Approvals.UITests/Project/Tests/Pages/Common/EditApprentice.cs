using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprentice : EditAppretinceNameDobAndReference
    {

        private By TrainingCost => By.Id("Cost");
        private By TrainingCourseContainer => By.CssSelector(".select2-container");

        public EditApprentice(ScenarioContext context) : base(context)
        {
        }

        protected abstract void SelectCourse();

        public void EditCostCourseAndReference(string reference)
        {
            EditCourse()
            .EditCost()
            .EditApprenticeNameDobAndReference(reference);
        }

        private EditApprentice EditCost()
        {
            formCompletionHelper.EnterText(TrainingCost, "2" + dataHelper.TrainingPrice);
            return this;
        }

        private EditApprentice EditCourse()
        {
            formCompletionHelper.ClickElement(TrainingCourseContainer);
            SelectCourse();
            formCompletionHelper.ClickElement(StartDateMonth);
            return this;
        }
    }
}