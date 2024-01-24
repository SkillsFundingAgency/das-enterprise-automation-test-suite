using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload
{
    public class BulkUploadApprenticeDetails
    {
        public BulkUploadApprenticeDetails() => EPAOrgID = "EPA0001";

        public BulkUploadApprenticeDetails(int courseCode, string agreementId, DateTime dateOfBirth, DateTime startDate, DateTime endDate) : this()
        {
            StdCode = $"{courseCode}";

            AgreementId = agreementId;

            DateOfBirth = dateOfBirth.ToString("yyyy-MM-dd");

            StartDate = startDate.ToString("yyyy-MM-dd");

            EndDate = endDate.ToString("yyyy-MM");

            RecognisePriorLearning = RPLDataHelper.RecognisePriorLearning;

            DurationReducedBy = RPLDataHelper.DurationReducedBy;

            PriceReducedBy = RPLDataHelper.PriceReducedBy;
        }

        public BulkUploadApprenticeDetails(ApprenticeDataHelper x, ApprenticeCourseDataHelper y, string agreementId) : this(int.Parse(y.CourseLarsCode), agreementId, x.ApprenticeDob, y.CourseStartDate, y.CourseEndDate)
        {
            ULN = RandomDataGenerator.GenerateRandomUln();
            FamilyName = x.ApprenticeLastname;
            GivenNames = x.ApprenticeFirstname;
            TotalPrice = x.TrainingCost;
            ProviderRef = x.EmployerReference;
            EmailAddress = x.ApprenticeEmail;
        }


        public string CohortRef { get; set; }
        public string ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public string FullName => $"{GivenNames} {FamilyName}";
        public string DateOfBirth { get; set; }
        public string StdCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TotalPrice { get; set; }
        public string EPAOrgID { get; set; }
        public string ProviderRef { get; set; }
        public string EmailAddress { get; set; }
        public string AgreementId { get; set; }
        public string RecognisePriorLearning { get; set; }
        public string DurationReducedBy { get; set; }
        public string PriceReducedBy { get; set; }

        public override string ToString()
        {
            return $"ApprenticeDetail - CohortRef: {CohortRef}, ULN: {ULN}, First Name: {GivenNames}, Last Name: {FamilyName}, Email address: {EmailAddress}";
        }
    }

    public class MapApprenticeDetails : BulkUploadApprenticeDetails
    {
        public MapApprenticeDetails()
        {

        }
        public string Category { get; set; }

        public string ErrorMessage { get; set; }
    }
}
