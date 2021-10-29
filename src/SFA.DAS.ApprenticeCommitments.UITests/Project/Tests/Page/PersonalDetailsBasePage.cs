using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
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

        protected void UpdateApprenticeName() => EnterApprenticeDetails(UpdatedFirstName(), UpdatedLastName(), null, null, null);

        protected void EnterValidApprenticeDetails() 
            => EnterApprenticeDetails(GetFirstName(), GetLastName(), GetDateOfBirth().Day, GetDateOfBirth().Month, GetDateOfBirth().Year);

        protected void EnterApprenticeDetails(string firstname, string lastname, int? day, int? month, int? year)
        {
            formCompletionHelper.EnterText(FirstName, firstname);
            formCompletionHelper.EnterText(LastName, lastname);

            if (day != null)
            {
                formCompletionHelper.EnterText(DateOfBirth_Day, day ?? 0);
            }
            if (month != null)
            {
                formCompletionHelper.EnterText(DateOfBirth_Month, month ?? 0);
            }
            if (year != null)
            {
                formCompletionHelper.EnterText(DateOfBirth_Year, year ?? 0);
            }

            Continue();
        }

        private string UpdatedFirstName() { var name = $"New_{GetFirstName()}_TEST"; objectContext.SetFirstName(name); return name; }

        private string UpdatedLastName() { var name = $"New_{GetLastName()}TEST"; objectContext.SetLastName(name); return name; }

        private string GetFirstName() => objectContext.GetFirstName();

        private string GetLastName() => objectContext.GetLastName();

        private DateTime GetDateOfBirth() => objectContext.GetDateOfBirth();
    }
}
