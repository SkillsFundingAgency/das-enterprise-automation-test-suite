using System;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using SFA.DAS.CosmosDb;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class CosmosConnectionHelper
    {

        public static DocumentRepository<TDocument> CreateCosmosDbRepoHelper<TDocument>(string uri, string authKey, string databaseName,
            string collectionName) where TDocument : class, IDocument
        {
            var documentClient = CreateDocumentClient(uri, authKey);
            return new DocumentRepository<TDocument>(documentClient, databaseName, collectionName);
        }

        public static IDocumentClient CreateDocumentClient(string uri, string authKey)
        {
            var connectionPolicy = new ConnectionPolicy
            {
                RetryOptions =
                {
                    MaxRetryAttemptsOnThrottledRequests = 4,
                    MaxRetryWaitTimeInSeconds = 10
                }
            };

            return new DocumentClient(new Uri(uri), authKey, connectionPolicy);
        }
    }

    public class Document : IDocument
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonIgnore]
        public string ETag { get; protected set; }

        [JsonProperty("_etag")]
        private string ReadOnlyETag { set => ETag = value; }

        protected Document()
        {
        }

    }


}