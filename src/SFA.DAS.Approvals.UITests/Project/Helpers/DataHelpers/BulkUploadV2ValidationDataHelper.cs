using System;
using System.Collections.Generic;
using System.IO;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class BulkUploadV2ValidationDataHelper
    {
        public void CreateBulkUploadFileToValidate(List<ApprenticeDetailsV2> apprenticeDetailsList, string fileLocation)
        {
            using (StreamWriter sw = File.CreateText(fileLocation))
            {
                sw.WriteLine("CohortRef,AgreementID,ULN,FamilyName,GivenNames,DateOfBirth,EmailAddress,StdCode,StartDate,EndDate,TotalPrice,EPAOrgID,ProviderRef");
                foreach (var apprentice in apprenticeDetailsList)
                {
                    sw.WriteLine($"{apprentice.CohortRef},{apprentice.AgreementId},{apprentice.ULN},{apprentice.FamilyName}," +
                        $"{apprentice.GivenNames},{apprentice.DateOfBirth},{apprentice.EmailAddress},{apprentice.StdCode}," +
                        $"{apprentice.StartDate},{apprentice.EndDate},{apprentice.TotalPrice},{apprentice.EPAOrgID},{apprentice.ProviderRef}");
                }
            }
        }
    }
}
