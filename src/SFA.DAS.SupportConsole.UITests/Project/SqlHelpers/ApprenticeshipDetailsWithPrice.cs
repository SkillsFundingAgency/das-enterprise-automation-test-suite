using System;

namespace SFA.DAS.SupportConsole.UITests.Project.SqlHelpers
{
    public class ApprenticeshipDetailsWithPrice
    {
        public int AgreementStatus { get; set; }
        public int PaymentStatus { get; set; }
        public string ULN { get; set; }
        public string Email { get; set; }
        public string ProviderName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirthAsString { get; set; }
        public string CohortReference { get; set; }
        public string EmployerReference { get; set; }
        public string LegalEntityName { get; set; }
        public string UKPRN { get; set; }
        public string TrainingName { get; set; }
        public string TrainingCode { get; set; }
        public string ConfirmationStatusDescription { get; set; }
        public string StartDateAsString { get; set; }
        public string EndDateAsString { get; set; }
        public int Cost { get; set; }

        public DateTime? StartDate { get
            {
                return GetDate(StartDateAsString);
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return GetDate(EndDateAsString);
            }
        }

        public DateTime? DateOfBirth
        {
            get
            {
                return GetDate(DateOfBirthAsString);
            }
        }

        private DateTime? GetDate(string dateAsString)
        {
            if (!string.IsNullOrWhiteSpace(dateAsString))
            {
                return DateTime.Parse(dateAsString);
            }

            return null;
        }
    }
}
