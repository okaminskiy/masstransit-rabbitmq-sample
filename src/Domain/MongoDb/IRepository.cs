using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Documents;

namespace Domain.MongoDb
{
    public interface IRepository<TDocument> where TDocument: Document
    {
        TDocument Get(Guid id);
        void Add(TDocument document);
        void Drop();
    }
}
