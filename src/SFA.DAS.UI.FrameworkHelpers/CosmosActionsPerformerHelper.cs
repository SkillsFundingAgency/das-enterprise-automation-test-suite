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
        public static void RemoveProviderPermissionDoc(string url, string authKey, string dbName, string collectionName, long ukprn)
        {
            var db = CosmosConnectionHelper.CreateCosmosDbRepoHelper<ProviderPermissionDocument>(url, authKey, dbName, collectionName);

            var docs = Query(db, (a) => a.Ukprn == ukprn);
            
            var requestOptions = new RequestOptions { PartitionKey = new PartitionKey(ukprn) };

            RemoveDoc(db, docs, requestOptions);
        }
        private static IQueryable<TDocument> Query<TDocument>(DocumentRepository<TDocument> db, Expression<Func<TDocument, bool>> expression) where TDocument : class, IDocument
        {
            return db.CreateQuery().Select(x => x).Where(expression);
        }

        private static void RemoveDoc<TDocument>(DocumentRepository<TDocument> db, IQueryable<TDocument> docs,  RequestOptions requestOptions) where TDocument : class, IDocument
        {
            foreach (var doc in docs)
            {
                db.Remove(doc.Id, requestOptions).Wait();
            }
        }

        // Add more properties in ProviderPermissionDocument as required
        class ProviderPermissionDocument : Document
        {
            [JsonProperty("ukprn")]
            public long Ukprn { get; set; }
        }
    }
}
