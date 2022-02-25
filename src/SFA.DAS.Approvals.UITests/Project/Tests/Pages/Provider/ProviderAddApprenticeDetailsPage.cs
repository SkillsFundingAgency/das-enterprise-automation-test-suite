using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsPage : AddApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Add apprentice details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By Uln => By.Id("Uln");

        private By AddButton => By.CssSelector("#addApprenticeship > button");

        public ProviderAddApprenticeDetailsPage(ScenarioContext context) : base(context)  { }

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            EnterDob();

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

        private void EnterApprenticeMandatoryValidDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, apprenticeDataHelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastNameField, apprenticeDataHelper.ApprenticeLastname);

            if (tags.Contains("aslistedemployer")) return;

            formCompletionHelper.EnterText(EmailField, apprenticeDataHelper.ApprenticeEmail);
        }

        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(context);
        }

        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectBulkUpload()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(context);
        }

        internal ProviderBeforeYouStartBulkUploadPage SelectBulkUploadV2()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderBeforeYouStartBulkUploadPage(context);
        }
    }
}