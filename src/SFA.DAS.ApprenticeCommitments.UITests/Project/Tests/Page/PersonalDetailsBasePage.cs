using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class PersonalDetailsBasePage : ApprenticeCommitmentsBasePage
    {
        private By FirstName => By.CssSelector("input#FirstName");
        private By LastName => By.CssSelector("input#LastName");
        private By DateOfBirth_Day => By.CssSelector("input#DateOfBirth_Day");
        private By DateOfBirth_Month => By.CssSelector("input#DateOfBirth_Month");
        private By DateOfBirth_Year => By.CssSelector("input#DateOfBirth_Year");

        public PersonalDetailsBasePage(ScenarioContext context) : base(context) { }

        public (string isDayDisabled, string isMonthDisabled, string isYearDisabled) IsDateOfBirthDisabled()
            => (IsDateOfBirthDisabled(DateOfBirth_Day), IsDateOfBirthDisabled(DateOfBirth_Month), IsDateOfBirthDisabled(DateOfBirth_Year));

        protected void UpdateApprenticeName() => EnterApprenticeDetails(UpdatedNewName(GetFirstName()), UpdatedNewName(GetLastName()), null, null, null);

        protected void EnterValidApprenticeDetails()
            => EnterApprenticeDetails(GetFirstName(), GetLastName(), GetDateOfBirth().Day, GetDateOfBirth().Month, GetDateOfBirth().Year);

        protected void EnterValidApprenticeDetails(string firstName, string lastName)
            => EnterApprenticeDetails(firstName, lastName, GetDateOfBirth().Day, GetDateOfBirth().Month, GetDateOfBirth().Year);

        protected (string firstName, string lastName) EnterInValidApprenticeDetails()
        {
            var firstName = GetFirstName(); var lastName = GetLastName(); var dob = GetDateOfBirth();
            EnterApprenticeDetails(UpdatedInvalidFirstName(), UpdatedInvalidLastName(), dob.Day, dob.Month, dob.Year);
            return (firstName, lastName);
        }

        protected void EnterApprenticeDetails(string firstname, string lastname, int? day, int? month, int? year)
        {
            formCompletionHelper.EnterText(FirstName, firstname);
            formCompletionHelper.EnterText(LastName, lastname);

            if (day != null)
                formCompletionHelper.EnterText(DateOfBirth_Day, day ?? 1);

            if (month != null)
                formCompletionHelper.EnterText(DateOfBirth_Month, month ?? 1);

            if (year != null)
                formCompletionHelper.EnterText(DateOfBirth_Year, year ?? 1991);

            Continue();
        }

        private string UpdatedNewName(string name) => $"New{name}";

        private string UpdatedInvalidFirstName() => SetFirstName(UpdatedInvalidName(GetFirstName()));

        private string UpdatedInvalidLastName() => SetLastName(UpdatedInvalidName(GetLastName()));

        private string UpdatedInvalidName(string name) => $"Invalid_{name}";

        private string SetFirstName(string name) { objectContext.SetFirstName(name); return name; }

        private string SetLastName(string name) { objectContext.SetLastName(name); return name; }

        private string GetFirstName() => objectContext.GetFirstName();

        private string GetLastName() => objectContext.GetLastName();

        private DateTime GetDateOfBirth() => objectContext.GetDateOfBirth();

        private string IsDateOfBirthDisabled(By by) => pageInteractionHelper.FindElement(by).GetAttribute(AttributeHelper.Disabled);
    }
}
