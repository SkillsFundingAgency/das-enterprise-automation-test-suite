using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TransferMatchingSqlDataHelper : SqlDbHelper
    {
        public TransferMatchingSqlDataHelper(DbConfig dbConfig) : base(dbConfig.TMDbConnectionString) { }

        public void DeletePledge(List<Pledge> pledges)
        {
            foreach (var pledge in pledges)
            {
                var amount = pledge.Amount;

                var query = $"if (select count(*) from Pledge where Amount = {amount} and CreatedOn < GETDATE() and CreatedOn > '{pledge.CreatedOn}') = 1 " +
                            $"Begin " +
                            $"DECLARE @id int; " +
                            $"select @id = Id from Pledge where Amount = {amount};" +
                            $"DELETE FROM[dbo].PledgeLocation WHERE PledgeId = @id; " +
                            $"DELETE FROM [dbo].[Pledge] WHERE Id = @id; " +
                            $"End";

                ExecuteSqlCommand(query);
            }
        }
    }
}
