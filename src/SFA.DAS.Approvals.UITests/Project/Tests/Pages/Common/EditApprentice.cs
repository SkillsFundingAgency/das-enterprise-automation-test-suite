using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprentice : EditApprenticePreApproval
    {
        private By TrainingCost => By.CssSelector("#Cost, #cost");

        private By TrainingCourseContainer => By.CssSelector("#trainingCourse");

        private By EmailField => By.CssSelector("#Email,#email");

        protected EditApprentice(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        protected abstract void SelectCourse();

        public string GetSelectedCourse() => formCompletionHelper.GetSelectedOption(TrainingCourseContainer);

        public void EditCostCourseAndReference(string reference)
        {
            EditCourse()
            .EditCost()
            .EditApprenticeNameDobAndReference(reference);
        }

        private EditApprentice EditCost()
        {
            formCompletionHelper.EnterText(TrainingCost, "2" + editedApprenticeDataHelper.TrainingPrice);
            return this;
        }

        protected EditApprentice EditCourse()
        {
            javaScriptHelper.SetTextUsingJavaScript(TrainingCourseContainer, "");
            SelectCourse();
            return this;
        }

        protected void EditEmail()
        {
            AddValidEmail();
            Update();
        }

        protected void AddValidEmail() => formCompletionHelper.EnterText(EmailField, apprenticeDataHelper.ApprenticeEmail);

    }
}