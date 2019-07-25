using System;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using SFA.DAS.CosmosDb;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class CosmosActionsPerformerHelper
    {

        public static void RemoveDoc(string url, string authKey, string dbName, string collectionName, string name, bool partitionKey = true)
        {
            var db = QueryDb(url, authKey, dbName, collectionName, name, out var docs, out var requestOptions, partitionKey = true);
            RemoveDoc(docs, db, requestOptions);
        }


        public static void AddNewDoc(string url, string authKey, string dbName, string collectionName, string currentDocName, string newDocName, string guid)
        {

            var db = QueryDb(url, authKey, dbName, collectionName, currentDocName, out var docs, out var requestOptions, false);
            var addAple = AddAple(newDocName, guid);
            AddDoc(docs, db, addAple, requestOptions);

        }

        public static void ModifyDoc(string url, string authKey, string dbName, string collectionName, string currentDocName, string newDocName, string guid)
        {
            var db = QueryDb(url, authKey, dbName, collectionName, currentDocName, out var docs, out var requestOptions, false);
            var addAple = AddAple(newDocName, guid);
            UpdateDoc(docs, db, addAple, requestOptions);
        }

        private static void UpdateDoc(IQueryable<Aple> docs, DocumentRepository<Aple> db, Aple addAple, RequestOptions requestOptions)
        {
             int number = docs.Count();
            foreach (var doc in docs)
            {
                db.Update(addAple, requestOptions);
            }
        }

        private static Aple AddAple(string name, string guid)
        {
            Aple addAple = new Aple();
            addAple.Name = name;
            addAple.Id = new Guid(guid);
            return addAple;
        }


        private static DocumentRepository<Aple> PermissionsDocumentRepository(string url, string authKey, string dbName, string collectionName)
        {
            var db = CosmosConnectionHelper.CreateCosmosDbRepoHelper<Aple>(url, authKey, dbName, collectionName);
            return db;
        }


        private static DocumentRepository<Aple> QueryDb(string url, string authKey, string dbName, string collectionName, string name,
            out IQueryable<Aple> docs, out RequestOptions requestOptions, bool partitionKey)
        {
            var db = PermissionsDocumentRepository(url, authKey, dbName, collectionName);
            var option = new FeedOptions { EnableCrossPartitionQuery = true };
            docs = db.CreateQuery(option).Select(x => x).Where(x => x.Name == name);
            requestOptions = new RequestOptions();
            if (partitionKey)
            {
                requestOptions.PartitionKey = new PartitionKey(name);
            }
            return db;
        }



        private static void AddDoc(IQueryable<Aple> docs, DocumentRepository<Aple> db, Aple addAple, RequestOptions requestOptions)
        {
            foreach (var doc in docs)
            {
                db.Add(addAple, requestOptions);
            }
        }

        private static void RemoveDoc(IQueryable<Aple> docs, DocumentRepository<Aple> db, RequestOptions requestOptions)
        {
            foreach (var doc in docs)
            {
                db.Remove(doc.Id, requestOptions).Wait();
            }
        }

        // Add more properties in Aple as required
        class Aple : Document
        {

            [JsonProperty("name")]
            public string Name { get; set; }
        }

    }

}





