using System;
using System.Collections.Generic;
using System.IO;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class BulkUploadDataHelper
    {
        public void CreateBulkUploadFile(List<ApprenticeDetails> apprenticeDetailsList, string fileLocation)
        {
            using (StreamWriter sw = File.CreateText(fileLocation))
            {
                sw.WriteLine("CohortRef,ULN,FamilyName,GivenNames,DateOfBirth,StdCode,StartDate,EndDate,TotalPrice,EPAOrgID,ProviderRef,EmailAddress,AgreementId");
                foreach (var apprentice in apprenticeDetailsList)
                {
                    sw.WriteLine($"{apprentice.CohortRef},{apprentice.ULN},{apprentice.FamilyName}," +
                        $"{apprentice.GivenNames},{apprentice.DateOfBirth.ToString("yyyy-MM-dd")},{apprentice.StdCode}," +
                        $"{apprentice.StartDate.ToString("yyyy-MM-dd")},{apprentice.EndDate.ToString("yyyy-MM")}," +
                        $"{apprentice.TotalPrice},{apprentice.EPAOrgID},{apprentice.ProviderRef}," + 
                        $"{apprentice.EmailAddress},{apprentice.AgreementId}");
                }                
            }
        }
    }

    public class ApprenticeDetails
    {
        public ApprenticeDetails(int courseCode) => StdCode = courseCode;

        public string CohortRef { get; set; }
        public string ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StdCode { get; internal set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TotalPrice { get; set; }
        public string EPAOrgID { get; } = "EPA0001";
        public string ProviderRef { get; set; }
        public string EmailAddress { get; set; }
        public string AgreementId { get; set; }


    }
}
