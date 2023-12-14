using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ConfirmYourRolesAbstractPage : ApprenticeCommitmentsBasePage
    {
        protected override By ContinueButton => By.CssSelector("#roles-responsibilities-confirm");

        public ConfirmYourRolesAbstractPage(ScenarioContext context) : base(context, false) => VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");

        protected void SelectCheckBoxAndContinue()
        {
            SelectCheckBoxByText("I confirm I have read the roles and responsibilities.");
            Continue();
        }

        protected void ClickContinueAndVerifyErrorSummaryBoxAndErrorFieldText()
        {
            Continue();

            VerifyErrorSummaryTitle();

            MultipleVerifyPage(
            [
                () => VerifyPage(ErrorSummaryText,"Please confirm that you have read the roles and responsibilities"),
                () => VerifyPage(FieldValidtionError,"Please confirm that you have read the roles and responsibilities")
            ]);
        }
    }
}
