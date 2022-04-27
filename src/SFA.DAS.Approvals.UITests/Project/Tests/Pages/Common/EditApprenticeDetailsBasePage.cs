using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprenticeDetailsBasePage : EditApprentinceNameDobAndReferenceBasePage
    {
        private By TrainingCost => By.CssSelector("#Cost, #cost");

        protected By TrainingCourseContainer => By.CssSelector("#trainingCourse");

        private By EmailField => By.CssSelector("#Email,#email");

        private By ReadOnyEmailField => By.CssSelector(".das-definition-list > dd#email,dd#Email");

        private By ReadOnlyTrainingCost => By.CssSelector(".das-definition-list > dd#cost");

        private By ReadOnlyTrainingCourse => By.CssSelector(".das-definition-list > dd#trainingName");

        protected EditApprenticeDetailsBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public void VerifyCourseAndCostAreReadOnly()
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(ReadOnlyTrainingCost),
                () => VerifyPage(ReadOnlyTrainingCourse)
            });
        }
        public void VerifyReadOnlyEmail() => VerifyElement(ReadOnyEmailField, GetApprenticeEmail());

        public string GetSelectedCourse() => formCompletionHelper.GetSelectedOption(TrainingCourseContainer);

        public void EditCostCourseAndReference(string reference)
        {
            EditCourse();

            EditCost();
            
            EditApprenticeNameDobAndReference(reference);
        }

        protected abstract void EditCourse();

        protected void EditEmail()
        {
            AddValidEmail();
            Update();
        }

        protected void AddValidEmail() => formCompletionHelper.EnterText(EmailField, GetApprenticeEmail());

        private string GetApprenticeEmail() => apprenticeDataHelper.ApprenticeEmail;

        private void EditCost() => formCompletionHelper.EnterText(TrainingCost, "2" + editedApprenticeDataHelper.TrainingCost);
    }
}