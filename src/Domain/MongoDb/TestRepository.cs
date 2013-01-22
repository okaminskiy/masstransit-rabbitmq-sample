using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Documents;

namespace Domain.MongoDb
{
    public abstract class TestRepository<TDocument>:IRepository<TDocument> where TDocument: Document
    {
        private List<TDocument> _documents;
 
        public TestRepository(List<TDocument> documents)
        {
            _documents = documents;
        } 

        public TDocument Get(Guid id)
        {
            try
            {
                return _documents.First(doc => doc.Id == id);
            }
            catch (NullReferenceException exception)
            {
                return null;
            }
        }

        public void Add(TDocument document)
        {
            _documents.Add(document);
        }

        public void Drop()
        {
            _documents.Clear();
        }
    }
}
