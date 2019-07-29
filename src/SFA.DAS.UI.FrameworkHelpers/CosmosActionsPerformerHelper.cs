using System;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using SFA.DAS.CosmosDb;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class InClassName
    {
        public InClassName(string url, string authKey, string dbName, string collectionName, string recordName, bool isPartitionKey, string partitionKey = "partitionKey")
        {
            Url = url;
            AuthKey = authKey;
            DbName = dbName;
            CollectionName = collectionName;
            RecordName = recordName;
            IsPartitionKey = isPartitionKey;
            PartitionKey = partitionKey;
        }

        public string Url { get; private set; }
        public string AuthKey { get; private set; }
        public string DbName { get; private set; }
        public string CollectionName { get; private set; }
        public string RecordName { get; private set; }
        public bool IsPartitionKey { get; private set; }
        public string PartitionKey { get; private set; }
    }

    public class CosmosActionsPerformerHelper
    {

        public static void RemoveDoc(string url, string authKey, string dbName, string collectionName, string recordName, string partitionKey, bool isPartitionKey = true)
        {
            var tuple = QueryDb(new InClassName(url, authKey, dbName, collectionName, recordName, isPartitionKey = true, partitionKey));
            var docs = tuple.Item1;
            var requestOptions = tuple.Item2;
            var db = tuple.Item3;
            RemoveDoc(docs, db, requestOptions);
        }


        public static void AddNewDoc(string url, string authKey, string dbName, string collectionName, string currentDocName, string newDocName, string guid)
        {
            var tuple = QueryDb(new InClassName(url, authKey, dbName, collectionName, currentDocName, false));
            var docs = tuple.Item1;
            var requestOptions = tuple.Item2;
            var db = tuple.Item3;
            var addAple = AddAple(newDocName, guid);
            AddDoc(docs, db, addAple, requestOptions);

        }

        public static void ModifyDoc(string url, string authKey, string dbName, string collectionName, string currentDocName, string newDocName, string guid)
        {
            var tuple = QueryDb(new InClassName(url, authKey, dbName, collectionName, currentDocName, false));
            var docs = tuple.Item1;
            var requestOptions = tuple.Item2;
            var db = tuple.Item3;
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


        private static Tuple<IQueryable<Aple>, RequestOptions, DocumentRepository<Aple>> QueryDb(InClassName inClassName)
        {
            var db = PermissionsDocumentRepository(inClassName.Url, inClassName.AuthKey, inClassName.DbName, inClassName.CollectionName);
            var option = new FeedOptions { EnableCrossPartitionQuery = true };
            var docs = db.CreateQuery(option).Select(x => x).Where(x => x.Name == inClassName.RecordName);
            var requestOptions = new RequestOptions();
            if (inClassName.IsPartitionKey)
            {
                requestOptions.PartitionKey = new PartitionKey(inClassName.PartitionKey);
            }
            return Tuple.Create(docs, requestOptions, db);
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





