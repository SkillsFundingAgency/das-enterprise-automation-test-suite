using System.Collections.Generic;
using System.IO;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload
{
    public class CreateCsvFileHelper
    {
        private static string CsvHeader => "CohortRef,AgreementID,ULN,FamilyName,GivenNames,DateOfBirth,EmailAddress,StdCode,StartDate,EndDate,TotalPrice,EPAOrgID,ProviderRef,RecognisePriorLearning,DurationReducedBy,PriceReducedBy";

        public void CreateCsvFile(List<BulkUploadApprenticeDetails> apprenticeDetailsList, string fileLocation)
        {
            using (StreamWriter sw = File.CreateText(fileLocation))
            {
                sw.WriteLine(CsvHeader);

                foreach (var apprentice in apprenticeDetailsList)
                {
                    sw.WriteLine($"{apprentice.CohortRef},{apprentice.AgreementId},{apprentice.ULN},{apprentice.FamilyName}," +
                        $"{apprentice.GivenNames},{apprentice.DateOfBirth},{apprentice.EmailAddress}," +
                        $"{apprentice.StdCode},{apprentice.StartDate},{apprentice.EndDate}," +
                        $"{apprentice.TotalPrice},{apprentice.EPAOrgID},{apprentice.ProviderRef}," +
                        $"{apprentice.RecognisePriorLearning}, {apprentice.DurationReducedBy}, {apprentice.PriceReducedBy}");
                }
            }
        }
    }
}
