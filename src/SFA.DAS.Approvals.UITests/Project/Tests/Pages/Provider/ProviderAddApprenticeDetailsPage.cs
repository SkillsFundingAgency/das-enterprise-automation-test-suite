using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Add apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading, .govuk-heading-xl");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");
        private By Uln => By.Id("Uln");
        private By AddButton => By.CssSelector("#addApprenticeship > button");

        public ProviderAddApprenticeDetailsPage(ScenarioContext context) : base(context)  { }

        internal ProviderApproveApprenticeDetailsPage SubmitValidApprenticeDetails()
        {
            bool rpl = false;

            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());

            ClickStartMonth();

            EnterStartDate(apprenticeCourseDataHelper.CourseStartDate);

            if (!loginCredentialsHelper.IsLevy && !objectContext.IsProviderMakesReservationForNonLevyEmployers()) EnterStartDate(DateTime.Now);

            EnterEndDate(apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            if (Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateMonth)) > 7 & Int32.Parse(pageInteractionHelper.GetTextFromValueAttributeOfAnElement(StartDateYear)) > 2021) rpl = true;

            formCompletionHelper.ClickElement(AddButton);

            if (rpl) new ProviderRPLPage(context).SelectNoAndContinue();

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private new void EnterApprenticeMandatoryValidDetails()
        {
            EnterApprenticeName();

            if (tags.Contains("aslistedemployer")) return;

            EnterApprenticeEmail();
        }

        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(context);
        }

        internal ProviderBeforeYouStartBulkUploadPage SelectBulkUpload()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderBeforeYouStartBulkUploadPage(context);
        }
    }
}