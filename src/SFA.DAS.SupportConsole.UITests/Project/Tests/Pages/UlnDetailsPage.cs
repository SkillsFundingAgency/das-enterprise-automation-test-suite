using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.SupportConsole.UITests.Project.SqlHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class UlnDetailsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => config.UlnName;

        #region Locators
        private By ApprenticeNameSelector => By.CssSelector(".column-three-quarters.column__double-padding-left.column__border-left .grid-row .column-full .heading-large");

        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        #endregion
        public UlnDetailsPage(ScenarioContext context) : base(context) 
        { 
            VerifyApprenticeNameHeading();
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        private void VerifyApprenticeNameHeading()
        {
            pageInteractionHelper.VerifyText(ApprenticeNameSelector, PageTitle);
        }

        

        public void VerifyUlnDetailsPageHeaders()
        {
            var apprenticeDetails = _commitmentsSqlDataHelper.GetApprenticeshipDetails(config.Uln, config.CohortRef);
            // VerifyPage();
            VerifyHeaderAndValue("Agreement status", GetAgreementStatusText(apprenticeDetails.AgreementStatus));
            VerifyHeaderAndValue("Payment status",GetPaymentStatusText(apprenticeDetails.PaymentStatus, apprenticeDetails.StartDate), "td strong");
            VerifyHeaderAndValue("Unique learner number", apprenticeDetails.ULN);
            VerifyHeaderAndValue("Email address", apprenticeDetails.Email);
            VerifyHeaderAndValue("Training provider", apprenticeDetails.ProviderName);
            VerifyHeaderAndValue("Name", $"{apprenticeDetails.FirstName} {apprenticeDetails.LastName}");
            VerifyHeaderAndValue("Date of birth", ToGdsFormatWithSpaceSeperator(apprenticeDetails.DateOfBirth));
            VerifyHeaderAndValue("Cohort reference", apprenticeDetails.CohortReference);
            VerifyHeaderAndValue("Employer reference", apprenticeDetails.EmployerReference);
            VerifyHeaderAndValue("Legal entity", apprenticeDetails.LegalEntityName);
            VerifyHeaderAndValue("UKPRN", apprenticeDetails.UKPRN);
            VerifyHeaderAndValue("Apprenticeship training course", apprenticeDetails.TrainingName);
            VerifyHeaderAndValue("Apprenticeship code", apprenticeDetails.TrainingCode);
            VerifyHeaderAndValue("Apprentice confirmation", apprenticeDetails.ConfirmationStatusDescription);
            VerifyHeaderAndValue("AS training start date", ToGdsFormatWithoutDay(apprenticeDetails.StartDate));
            VerifyHeaderAndValue("AS training end date", ToGdsFormatWithoutDay(apprenticeDetails.EndDate));
            VerifyHeaderAndValue("Current training cost", ToGdsCurrencyFormat(apprenticeDetails.Cost));
            if (apprenticeDetails.PaymentStatus == 3 && apprenticeDetails.MadeRedundant.HasValue)
            {
                VerifyHeaderAndValue("Made redundant",  apprenticeDetails.MadeRedundant.Value ? "Yes" : "No");
            }
            if (apprenticeDetails.PaymentStatus == 4)
            {
                VerifyHeaderAndValue("Completion payment month", ToGdsFormatWithoutDay(apprenticeDetails.CompletionDate));
            }
            if (apprenticeDetails.PaymentStatus == 3)
            {
                VerifyHeaderAndValue("Stopped date", ToGdsFormatWithoutDay(apprenticeDetails.StopDate));
            }
            if (apprenticeDetails.PaymentStatus == 2)
            {
                VerifyHeaderAndValue("Paused date", ToGdsFormatWithoutDay(apprenticeDetails.PauseDate));
            }
            if (apprenticeDetails.TrainingCourseVersionConfirmed.HasValue && apprenticeDetails.TrainingCourseVersionConfirmed.Value)
            {
                VerifyHeaderAndValue("Version", apprenticeDetails.TrainingCourseVersion);
            }
            VerifyHeaderAndValue("Option", string.IsNullOrWhiteSpace(apprenticeDetails.TrainingCourseOption) ? "To be confirmed" : apprenticeDetails.TrainingCourseOption);
        }

        private string GetPaymentStatusText(int paymentStatus, DateTime? startDate)
        {
            var isStartDateInFuture = startDate.HasValue && startDate.Value > new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

            switch (paymentStatus)
            {
                case 0:
                    return "Approval needed";
                case 1:
                    return isStartDateInFuture ? "Waiting to start" : "LIVE";
                case 2:
                    return "PAUSED";
                case 3:
                    return "STOPPED";
                case 4:
                    return "COMPLETED";
                case 5:
                    return "DELETED";
                default:
                    break;
            }

            return string.Empty;
        }

        private void VerifyHeaderAndValue(string headerText, string expectedValueFromDatabase, string valueCssSelector = "td")
        {
            var headerTextXpathQuery = $"//th[contains(text(),'{headerText}')]";
            var header = pageInteractionHelper.FindElement(By.XPath(headerTextXpathQuery));
            var parent = header.FindElement(By.XPath(".."));
            var value = parent.FindElement(By.CssSelector(valueCssSelector));
            pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(header), headerText);
            pageInteractionHelper.VerifyText(expectedValueFromDatabase, pageInteractionHelper.GetText(value));
        }

        private string GetAgreementStatusText(int agreementStatus)
        {
            switch (agreementStatus)
            {
                case 0:
                    return "Not agreed";
                case 1:
                    return "Employer agreed";
                case 2:
                    return "Provider agreed";
                case 3:
                    return "Both agreed";
                default:
                    break;
            }

            return string.Empty;
        }

        public string ToGdsFormatWithSpaceSeperator(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("dd MMMM yyyy") : string.Empty;
        }

        public string ToGdsFormatWithoutDay(DateTime? date)
        {
            return date.HasValue? date.Value.ToString("MMM yyyy") : string.Empty;
        }

        public string ToGdsCurrencyFormat(Decimal? value)
        {
            return value.HasValue ? string.Format(new System.Globalization.CultureInfo("en-GB", false), "{0:c0}", value) : string.Empty;
        }
    }
}