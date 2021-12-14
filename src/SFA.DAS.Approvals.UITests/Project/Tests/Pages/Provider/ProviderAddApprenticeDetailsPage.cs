using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .govuk-fieldset__heading");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By EmailField => By.Id("Email");
        private By DateOfBirthDay => By.Id("BirthDay");
        private By DateOfBirthMonth => By.Id("BirthMonth");
        private By DateOfBirthYear => By.Id("BirthYear");
        private By Uln => By.Id("Uln");
        private By TrainingCourseContainer => By.Id("CourseCode");
        private By StartDateMonth => By.Id("StartMonth");
        private By StartDateYear => By.Id("StartYear");
        private By EndDateMonth => By.Id("EndMonth");
        private By EndDateYear => By.Id("EndYear");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By AddButton => By.CssSelector("#addApprenticeship > button");

        public ProviderAddApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();
            formCompletionHelper.EnterText(DateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);
            formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());
            formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, apprenticeCourseDataHelper.Course);
            formCompletionHelper.ClickElement(StartDateMonth);
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseDataHelper.CourseStartDate.Year);
            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers())
            {
                DateTime now = DateTime.Now;
                formCompletionHelper.EnterText(StartDateMonth, now.Month);
                formCompletionHelper.EnterText(StartDateYear, now.Year);
            }
            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            formCompletionHelper.EnterText(TrainingCost, apprenticeDataHelper.TrainingPrice);
            formCompletionHelper.EnterText(EmployerReference, apprenticeDataHelper.EmployerReference);
            formCompletionHelper.ClickElement(AddButton);

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(_context);
        }
        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectBulkUpload()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(_context);
        }
        private void EnterApprenticeMandatoryValidDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, apprenticeDataHelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastNameField, apprenticeDataHelper.ApprenticeLastname);

            if (tags.Contains("aslistedemployer")) return;

            formCompletionHelper.EnterText(EmailField, apprenticeDataHelper.ApprenticeEmail);
        }
    }
}