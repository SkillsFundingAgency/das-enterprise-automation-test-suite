using System.Collections.Generic;
using System.IO;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload
{
    public class CreateCsvFileHelper
    {
        private static string CsvHeader => "CohortRef,AgreementID,ULN,FamilyName,GivenNames,DateOfBirth,EmailAddress,StdCode,StartDate,EndDate,TotalPrice,EPAOrgID,ProviderRef";

        public void CreateCsvFile(List<ApprenticeDetails> apprenticeDetailsList, string fileLocation)
        {
            using (StreamWriter sw = File.CreateText(fileLocation))
            {
                sw.WriteLine(CsvHeader);

                foreach (var apprentice in apprenticeDetailsList)
                {
                    sw.WriteLine($"{apprentice.CohortRef},{apprentice.AgreementId},{apprentice.ULN},{apprentice.FamilyName}," +
                        $"{apprentice.GivenNames},{apprentice.DateOfBirth},{apprentice.EmailAddress}," +
                        $"{apprentice.StdCode},{apprentice.StartDate},{apprentice.EndDate}," +
                        $"{apprentice.TotalPrice},{apprentice.EPAOrgID},{apprentice.ProviderRef}");
                }
            }
        }
    }
}
