using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using SFA.DAS.CosmosDb;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class CosmoDbInfo
    {
        public CosmoDbInfo(string url, string authKey, string dbName, string collectionName, bool isPartitionKey, object partitionKey)
        {
            Url = url;
            AuthKey = authKey;
            DbName = dbName;
            CollectionName = collectionName;
            IsPartitionKey = isPartitionKey;
            PartitionKey = partitionKey;
        }

        public string Url { get; private set; }
        public string AuthKey { get; private set; }
        public string DbName { get; private set; }
        public string CollectionName { get; private set; }
        public bool IsPartitionKey { get; private set; }
        public object PartitionKey { get; private set; }
    }

    public class CosmosActionsPerformerHelper
    {
        public static void RemoveProviderPermissionDoc(string url, string authKey, string dbName, string collectionName, long ukprn, object partitionKey)
        {
            var (docs, requestOptions, db) = QueryDb(new CosmoDbInfo(url, authKey, dbName, collectionName, true, partitionKey), (a) => a.Ukprn == ukprn);
            RemoveDoc(docs, requestOptions, db);
        }

        private static void RemoveDoc(IQueryable<Aple> docs, RequestOptions requestOptions, DocumentRepository<Aple> db)
        {
            foreach (var doc in docs)
            {
                db.Remove(doc.Id, requestOptions).Wait();
            }
        }

        private static (IQueryable<Aple> , RequestOptions, DocumentRepository<Aple>) QueryDb(CosmoDbInfo cosmoDbInfo, Expression<Func<Aple, bool>> expression)
        {
            var documentrepository = PermissionsDocumentRepository(cosmoDbInfo.Url, cosmoDbInfo.AuthKey, cosmoDbInfo.DbName, cosmoDbInfo.CollectionName);

            var docsfound = Query(documentrepository, expression);

            var queryrequestOptions = QueryRequestOptions(cosmoDbInfo.IsPartitionKey, cosmoDbInfo.PartitionKey);

            return (docsfound, queryrequestOptions, documentrepository);
        }

        private static DocumentRepository<Aple> PermissionsDocumentRepository(string url, string authKey, string dbName, string collectionName) => CosmosConnectionHelper.CreateCosmosDbRepoHelper<Aple>(url, authKey, dbName, collectionName);

        private static IQueryable<Aple> Query(DocumentRepository<Aple> db, Expression<Func<Aple,bool>> expression)
        {
            var option = new FeedOptions { EnableCrossPartitionQuery = true };

            return db.CreateQuery(option).Select(x => x).Where(expression);
        }

        private static RequestOptions QueryRequestOptions(bool isPartitionKey, object partitionKey)
        {
            var requestOptions = new RequestOptions();
            if (isPartitionKey)
            {
                requestOptions.PartitionKey = new PartitionKey(partitionKey);
            }
            return requestOptions;
        }

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





