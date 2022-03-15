using System;
using System.Collections.Generic;
using System.IO;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class BulkUploadValidationDataHelper
    {
        public void CreateBulkUploadFileToValidate(List<ApprenticeDetail> apprenticeDetailsList, string fileLocation)
        {
            using (StreamWriter sw = File.CreateText(fileLocation))
            {
                sw.WriteLine("CohortRef,ULN,FamilyName,GivenNames,DateOfBirth,StdCode,StartDate,EndDate,TotalPrice,EPAOrgID,ProviderRef,EmailAddress,AgreementId");
                foreach (var apprentice in apprenticeDetailsList)
                {
                    sw.WriteLine($"{apprentice.CohortRef},{apprentice.ULN},{apprentice.FamilyName}," +
                        $"{apprentice.GivenNames},{apprentice.DateOfBirth},{apprentice.StdCode}," +
                        $"{apprentice.StartDate},{apprentice.EndDate}," +
                        $"{apprentice.TotalPrice},{apprentice.EPAOrgID},{apprentice.ProviderRef}," +
                        $"{apprentice.EmailAddress},{apprentice.AgreementId}");
                }
            }
        }
    }

    public class ApprenticeDetail
    {
        public ApprenticeDetail(string courseCode) => StdCode = courseCode;

        public string CohortRef { get; set; }
        public string ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public string DateOfBirth { get; set; }
        public string StdCode { get; internal set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TotalPrice { get; set; }
        public string EPAOrgID { get; } = "EPA0001";
        public string ProviderRef { get; set; }
        public string EmailAddress { get; set; }
        public string AgreementId { get; set; }
    }
}
