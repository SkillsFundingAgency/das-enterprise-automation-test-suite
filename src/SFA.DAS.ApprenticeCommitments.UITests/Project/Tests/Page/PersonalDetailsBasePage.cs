using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class PersonalDetailsBasePage : ApprenticeCommitmentsBasePage
    {
        private static By FirstName => By.CssSelector("input#FirstName");
        private static By LastName => By.CssSelector("input#LastName");
        private static By DateOfBirth_Day => By.CssSelector("input#DateOfBirth_Day");
        private static By DateOfBirth_Month => By.CssSelector("input#DateOfBirth_Month");
        private static By DateOfBirth_Year => By.CssSelector("input#DateOfBirth_Year");

        public PersonalDetailsBasePage(ScenarioContext context) : base(context) { }

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

        protected void EnterApprenticeDetails(string firstName, string lastName, int? day, int? month, int? year)
        {
            formCompletionHelper.EnterText(FirstName, firstName);
            objectContext.SetFirstName(firstName);
            formCompletionHelper.EnterText(LastName, lastName);
            objectContext.SetLastName(lastName);

            if (day != null)
                formCompletionHelper.EnterText(DateOfBirth_Day, day ?? 1);

            if (month != null)
                formCompletionHelper.EnterText(DateOfBirth_Month, month ?? 1);

            if (year != null)
                formCompletionHelper.EnterText(DateOfBirth_Year, year ?? 1991);

            Continue();
        }

        private string UpdatedNewName(string name) => $"New{name}";

        private string UpdatedInvalidFirstName() => SetFirstName("InvalidFName");

        private string UpdatedInvalidLastName() => SetLastName("InvalidLName");

        private string SetFirstName(string name) { objectContext.SetFirstName(name); return name; }

        private string SetLastName(string name) { objectContext.SetLastName(name); return name; }

        private string GetFirstName() => objectContext.GetFirstName();

        private string GetLastName() => objectContext.GetLastName();

        private DateTime GetDateOfBirth() => objectContext.GetDateOfBirth();
    }
}
