using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Messages;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Domain.MongoDb
{
    static class MongoRepository
    {
        public readonly static MongoDatabase Database;
	    static string connectionString = "mongodb://localhost";

        static MongoRepository()
        {
           BsonClassMap.RegisterClassMap<CustomerDetails>(cm => {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.Id));
           });
           string databaseName = "MasstransitSpike";
           var client = new MongoClient(connectionString);
	
           var server = client.GetServer();
	       Database = server.GetDatabase(databaseName);
       }
    }
}
