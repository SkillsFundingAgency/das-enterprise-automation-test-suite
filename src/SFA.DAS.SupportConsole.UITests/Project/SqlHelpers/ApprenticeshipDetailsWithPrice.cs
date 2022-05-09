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
        public bool? MadeRedundant { get; set; }
        public string CompletionDateAsString { get; set; }
        public string StopDateAsString { get; set; }
        public string PauseDateAsString { get; set; }
        public bool? TrainingCourseVersionConfirmed { get; set; }
        public string TrainingCourseVersion { get; set; }
        public string TrainingCourseOption { get; set; }

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

        public DateTime? CompletionDate
        {
            get
            {
                return GetDate(CompletionDateAsString);
            }
        }

        public DateTime? PauseDate
        {
            get
            {
                return GetDate(PauseDateAsString);
            }
        }

        public DateTime? StopDate
        {
            get
            {
                return GetDate(StopDateAsString);
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
