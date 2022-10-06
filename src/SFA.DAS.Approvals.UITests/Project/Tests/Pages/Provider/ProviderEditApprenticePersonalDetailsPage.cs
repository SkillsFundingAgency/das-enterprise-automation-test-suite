using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticePersonalDetailsPage : ProviderEditApprenticeCoursePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private By Uln => By.Id("Uln");
        private By SaveButton => By.XPath("//button[text()='Save and continue']");
        private By DeleteButton => By.LinkText("Delete");
        private By InputBox => By.ClassName("govuk-input"); //By.TagName("input");

        public ProviderEditApprenticePersonalDetailsPage(ScenarioContext context) : base(context) { }

        public ProviderEditApprenticeTrainingDetailsPage EnterUlnAndSave()
        {
            EnterUln();

            formCompletionHelper.ClickElement(SaveButton);

            return new ProviderEditApprenticeTrainingDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage EditAllApprenticeDetailsExceptCourse()
        {
            formCompletionHelper.EnterText(FirstNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, editedApprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, editedApprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, editedApprenticeDataHelper.DateOfBirthYear);
            EnterUln();

            formCompletionHelper.ClickElement(SaveButton);          

            return new ProviderApproveApprenticeDetailsPage(context);
        }

       

        public ProviderConfirmApprenticeDeletionPage DeleteApprentice()
        {
            formCompletionHelper.ClickElement(DeleteButton);
            return new ProviderConfirmApprenticeDeletionPage(context);
        }

        public ProviderEditApprenticePersonalDetailsPage ValidateEditableTextBoxes(int numberOfExpectedTextBoxes)
        {
            GetAllEditBoxes();

            int numberOfTextBoxesDisplayed = GetAllEditBoxes().Count;

            if (numberOfTextBoxesDisplayed != numberOfExpectedTextBoxes)
                throw new Exception($"expected editable boxes were: [{numberOfExpectedTextBoxes}] actual editable boxes displayed are: [{numberOfTextBoxesDisplayed}]");
            else
                return this;
        }

        internal List<IWebElement> GetAllEditBoxes() => pageInteractionHelper.FindElements(InputBox);

        private void EnterUln()
        {
            var uln = apprenticeDataHelper.Uln();

            if (objectContext.IsSameApprentice() && apprenticeDataHelper.Ulns.Count == 1) uln = apprenticeDataHelper.Ulns.First();

            formCompletionHelper.EnterText(Uln, uln);
        }
    }
}