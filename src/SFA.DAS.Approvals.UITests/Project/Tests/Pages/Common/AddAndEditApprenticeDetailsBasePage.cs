using System;
using System.Linq;
using OpenQA.Selenium;
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
        private By StartDateMonth => By.Id("StartMonth");
        private By StartDateYear => By.Id("StartYear");
        private By EndDateMonth => By.Id("EndMonth");
        private By EndDateYear => By.Id("EndYear");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By DeliveryModelSection => By.XPath("//legend[contains(text(),'Delivery model')]");
        private By TrainingCourseEditLink => By.CssSelector("button[name='ChangeCourse']");
        private By DeliveryModelRadioLabel => RadioLabels;

        public AddAndEditApprenticeDetailsBasePage(ScenarioContext context) : base(context) { }

        protected void EnterTrainingCostAndEmpReference()
        {
            formCompletionHelper.EnterText(TrainingCost, apprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, apprenticeDataHelper.EmployerReference);
        }

        protected void ClickStartMonth() => formCompletionHelper.ClickElement(StartDateMonth);

        protected void EnterStartDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(StartDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(StartDateYear, dateTime.Year);
        }

        protected void EnterEndDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(EndDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(EndDateYear, dateTime.Year);
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

            if (pageInteractionHelper.IsElementDisplayed(DeliveryModelSection))
                formCompletionHelper.SelectRadioOptionByForAttribute(DeliveryModelRadioLabel, "DeliveryModelNormal");

            if (tags.Contains("aslistedemployer")) return;

            EnterApprenticeEmail();
        }

        protected void EnterDob()
        {
            formCompletionHelper.EnterText(DateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);
        }

        public SelectStandardPage ClickEditCourseLink()
        {
            formCompletionHelper.Click(TrainingCourseEditLink);
            return new SelectStandardPage(context);
        }
    }
}
