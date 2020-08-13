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
                sw.WriteLine("CohortRef,ULN,FamilyName,GivenNames,DateOfBirth,ProgType,FworkCode,PwayCode,StdCode,StartDate,EndDate,TotalPrice,EPAOrgID,ProviderRef");
                foreach (var apprentice in apprenticeDetailsList)
                {
                    sw.WriteLine($"{apprentice.CohortRef},{apprentice.ULN},{apprentice.FamilyName}," +
                        $"{apprentice.GivenNames},{apprentice.DateOfBirth.ToString("yyyy-MM-dd")},{apprentice.ProgType}," +
                        $"{apprentice.FworkCode},{apprentice.PwayCode},{apprentice.StdCode},{apprentice.StartDate.Year}-{apprentice.StartDate.Month.ToString("d2")}," +
                        $"{apprentice.EndDate.Year}-{apprentice.EndDate.Month.ToString("d2")},{apprentice.TotalPrice},{apprentice.EPAOrgID},{apprentice.ProviderRef}");
                }                
            }
        }
    }

    public class ApprenticeDetails
    {
        public string CohortRef { get; set; }
        public string ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ProgType { get; internal set; } = null;
        public int? FworkCode { get; internal set; } = null;
        public int? PwayCode { get; internal set; } = null;
        public int? StdCode { get; internal set; } = null;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TotalPrice { get; set; }
        public string EPAOrgID { get; } = "EPA0001";
        public string ProviderRef { get; set; }

        public ApprenticeDetails(CourseType courseType)
        {
            switch (courseType)
            {
                case CourseType.Framework:
                    //ProgType = 2;
                    //FworkCode = 407;
                    //PwayCode = 1;
                    ProgType = 25;
                    StdCode = 91;
                    break;
                case CourseType.Standard:
                    ProgType = 25;
                    StdCode = 57;
                    break;
                default:
                    break;
            }
        }
    }
}
