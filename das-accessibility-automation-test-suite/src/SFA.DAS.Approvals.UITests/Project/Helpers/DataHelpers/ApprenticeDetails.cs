using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class ApprenticeDetails
    {
        public string ULN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TotalPrice { get; set; }
        public string Category { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class MappedApprenticeDetails : ApprenticeDetails
    {
        public MappedApprenticeDetails(ApprenticeDetails apprenticeDetails)
        {
            ULN = apprenticeDetails.ULN;
            FirstName = apprenticeDetails.FirstName;
            LastName = apprenticeDetails.LastName;
            EmailAddress = apprenticeDetails.EmailAddress;
            DateOfBirth = ConvertToDate(apprenticeDetails.DateOfBirth);
            StartDate = ConvertToDate(apprenticeDetails.StartDate);
            EndDate = ConvertToDate(apprenticeDetails.EndDate);
            TotalPrice = apprenticeDetails.TotalPrice;
            Category = apprenticeDetails.Category;
            ErrorMessage = apprenticeDetails.ErrorMessage;
        }

        public new DateTime DateOfBirth { get; set; }
        public new DateTime StartDate { get; set; }
        public new DateTime EndDate { get; set; }

        private static DateTime ConvertToDate(string dateString) => DateTime.TryParse(dateString, out DateTime date) ? date : DateTime.MinValue;
    }
}
