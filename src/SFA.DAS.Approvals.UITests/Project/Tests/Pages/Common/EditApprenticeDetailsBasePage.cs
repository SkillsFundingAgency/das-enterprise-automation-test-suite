using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprenticeDetailsBasePage : EditApprentinceNameDobAndReferenceBasePage
    {
        private By TrainingCost => By.CssSelector("#Cost, #cost");

        protected By TrainingCourseContainer => By.CssSelector("#trainingCourse");

        private By EmailField => By.CssSelector("#Email,#email");

        private By ReadOnyEmailField => By.CssSelector(".das-definition-list > dd#email,dd#Email");

        protected EditApprenticeDetailsBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }
        
        protected abstract void EditCourse();

        public void VerifyReadOnlyEmail() => VerifyElement(ReadOnyEmailField, GetApprenticeEmail());

        public string GetSelectedCourse() => formCompletionHelper.GetSelectedOption(TrainingCourseContainer);

        public void EditCostCourseAndReference(string reference)
        {
            EditCourse();

            EditCost();
            
            EditApprenticeNameDobAndReference(reference);
        }

        protected void EditEmail()
        {
            AddValidEmail();
            Update();
        }

        protected void AddValidEmail() => formCompletionHelper.EnterText(EmailField, GetApprenticeEmail());

        private string GetApprenticeEmail() => apprenticeDataHelper.ApprenticeEmail;

        private void EditCost() => formCompletionHelper.EnterText(TrainingCost, "2" + editedApprenticeDataHelper.TrainingPrice);
    }
}