using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Documents;

namespace Domain.MongoDb
{
    public abstract class TestRepository<TDocument>:IRepository<TDocument> where TDocument: Document
    {
        protected static List<TDocument> Documents;


        public TDocument Get(Guid id)
        {
            try
            {
                return Documents.First(doc => doc.Id == id);
            }
            catch (NullReferenceException exception)
            {
                return null;
            }
        }

        public void Add(TDocument document)
        {
            Documents.Add(document);
        }

        public void Drop()
        {
            Documents.Clear();
        }
    }
}
