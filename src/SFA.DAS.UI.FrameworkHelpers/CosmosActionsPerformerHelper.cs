using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using SFA.DAS.CosmosDb;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class CosmosActionsPerformerHelper
    {
        public static void RemoveProviderPermissionDoc(string url, string authKey, string dbName, string collectionName, long ukprn, object partitionKey)
        {
            var db = CosmosConnectionHelper.CreateCosmosDbRepoHelper<Aple>(url, authKey, dbName, collectionName);

            var docs = Query(db, (a) => a.Ukprn == ukprn);
            
            var requestOptions = new RequestOptions { PartitionKey = new PartitionKey(partitionKey) };

            RemoveDoc(db, docs, requestOptions);
        }

        private static void RemoveDoc(DocumentRepository<Aple> db, IQueryable<Aple> docs,  RequestOptions requestOptions)
        {
            foreach (var doc in docs)
            {
                db.Remove(doc.Id, requestOptions).Wait();
            }
        }

        private static IQueryable<Aple> Query(DocumentRepository<Aple> db, Expression<Func<Aple,bool>> expression) => db.CreateQuery(new FeedOptions { EnableCrossPartitionQuery = true }).Select(x => x).Where(expression);

        // Add more properties in Aple as required
        class Aple : Document
        {
            [JsonProperty("ukprn")]
            public long Ukprn { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

    }

}





