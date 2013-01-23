﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Domain.Documents;
using MongoDB.Driver;

namespace Domain.Repositories
{
    public abstract class MongoRepository <TDocument> : IRepository<TDocument> where TDocument: Document
    {
        private static MongoDatabase _database;
        protected static MongoCollection<TDocument> _collection;
	    
        private static string connectionString = ConfigurationManager.ConnectionStrings["Mongo"].ConnectionString;
        
        static MongoRepository()
        {
            string databaseName = "MasstransitSpike";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            _database = server.GetDatabase(databaseName);
        } 

        public MongoRepository(string entityName)
        {  
            _collection = _database.GetCollection<TDocument>(entityName);
        }


        public TDocument Get(Guid id)
        {
            return _collection.FindOneById(id);
        }

        public void Add(TDocument document)
        {
            var customersDetails = _database.GetCollection<TDocument>("Details");
            customersDetails.Insert(document);
        }

        public void Drop()
        {
            _database.GetCollection<CustomerDetails>("Details").Drop();
        }

        public abstract List<TDocument> GetAll();
    }
}