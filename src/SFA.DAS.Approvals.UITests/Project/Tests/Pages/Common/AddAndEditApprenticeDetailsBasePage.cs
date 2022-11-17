using System;
using System.Linq;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class AddAndEditApprenticeDetailsBasePage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By EmailField => By.Id("Email");
        private By DateOfBirthDay => By.Id("BirthDay");
        private By DateOfBirthMonth => By.Id("BirthMonth");
        private By DateOfBirthYear => By.Id("BirthYear");
        private By ActualStartDateDay => By.Id("ActualStartDay");
        public By ActualStartDateMonth => By.Id("ActualStartMonth");
        public By ActualStartDateYear => By.Id("ActualStartYear");
        public By StartDateMonth => By.Id("StartMonth");
        public By StartDateYear => By.Id("StartYear");
        private By EndDateMonth => By.Id("EndMonth");
        private By EndDateYear => By.Id("EndYear");
        private By EmploymentEndMonth => By.Id("EmploymentEndMonth");
        private By EmploymentEndYear => By.Id("EmploymentEndYear");
        private By TrainingCost => By.Id("Cost");
        private By EmploymentPrice => By.Id("EmploymentPrice");
        private By EmployerReference => By.Id("Reference");

        public AddAndEditApprenticeDetailsBasePage(ScenarioContext context) : base(context) { }

        protected void EnterTrainingCostAndEmpReference()
        {
            formCompletionHelper.EnterText(TrainingCost, apprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, apprenticeDataHelper.EmployerReference);

            if (tags.Contains("portableflexijob"))
                formCompletionHelper.EnterText(EmploymentPrice, apprenticeDataHelper.TrainingCost.ToInt() - 50);
        }

        protected void ClickStartMonth() => formCompletionHelper.ClickElement(StartDateMonth);

        protected void ClickActualStartDateDay() => formCompletionHelper.ClickElement(ActualStartDateDay);

        protected void EnterStartDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(StartDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(StartDateYear, dateTime.Year);
        }

        protected void EnterActualStartDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(ActualStartDateDay, dateTime.Day);
            formCompletionHelper.EnterText(ActualStartDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(ActualStartDateYear, dateTime.Year);
        }

        protected void EnterEndDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(EndDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(EndDateYear, dateTime.Year);

            if (tags.Contains("portableflexijob"))
            {
                formCompletionHelper.EnterText(EndDateYear, dateTime.Year + 2);
                formCompletionHelper.EnterText(EmploymentEndMonth, dateTime.Month);
                formCompletionHelper.EnterText(EmploymentEndYear, dateTime.Year + 1);
            }
        }

        protected void EnterApprenticeName()
        {
            formCompletionHelper.EnterText(FirstNameField, apprenticeDataHelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastNameField, apprenticeDataHelper.ApprenticeLastname);
        }

        protected void EnterApprenticeEmail() => formCompletionHelper.EnterText(EmailField, apprenticeDataHelper.ApprenticeEmail);

        protected void EnterApprenticeMandatoryValidDetails()
        {
            EnterApprenticeName();

            if (tags.Contains("aslistedemployer")) return;

            EnterApprenticeEmail();
        }

        protected void EnterDob()
        {
            formCompletionHelper.EnterText(DateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);
        }
    }
}
