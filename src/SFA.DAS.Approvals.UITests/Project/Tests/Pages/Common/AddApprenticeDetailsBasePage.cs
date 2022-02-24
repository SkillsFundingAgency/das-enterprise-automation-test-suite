using System;
using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class AddApprenticeDetailsBasePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected By FirstNameField => By.Id("FirstName");
        protected By LastNameField => By.Id("LastName");
        protected By EmailField => By.Id("Email");
        protected By DateOfBirthDay => By.Id("BirthDay");
        protected By DateOfBirthMonth => By.Id("BirthMonth");
        protected By DateOfBirthYear => By.Id("BirthYear");
        protected By TrainingCourseContainer => By.Id("CourseCode");
        protected By StartDateMonth => By.Id("StartMonth");
        protected By StartDateYear => By.Id("StartYear");
        protected By EndDateMonth => By.Id("EndMonth");
        protected By EndDateYear => By.Id("EndYear");
        protected By TrainingCost => By.Id("Cost");
        protected By EmployerReference => By.Id("Reference");
        protected By DeliveryModelSection => By.XPath("//legend[contains(text(),'Delivery model')]");
        protected By DeliveryModelRadioLabel => RadioLabels;

        public AddApprenticeDetailsBasePage(ScenarioContext context) : base(context) { }

        protected void EnterApprenticeMandatoryValidDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, apprenticeDataHelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastNameField, apprenticeDataHelper.ApprenticeLastname);
            if (pageInteractionHelper.IsElementDisplayed(DeliveryModelSection))
                formCompletionHelper.SelectRadioOptionByForAttribute(DeliveryModelRadioLabel, "DeliveryModelNormal");

            if (tags.Contains("aslistedemployer")) return;

            formCompletionHelper.EnterText(EmailField, apprenticeDataHelper.ApprenticeEmail);
        }

        protected void EnterDob()
        {
            formCompletionHelper.EnterText(DateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);
        }
    }
}
