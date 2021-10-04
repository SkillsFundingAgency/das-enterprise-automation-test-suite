using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TransferMatchingSqlDataHelper : SqlDbHelper
    {
        public TransferMatchingSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        public void DeletePledge(string pledgeId) => ExecuteSqlCommand($"DELETE FROM[dbo].PledgeLocation WHERE PledgeId = {pledgeId}; DELETE FROM [dbo].[Pledge] WHERE Id = {pledgeId};");
    }
}
