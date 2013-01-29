using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Documents;

namespace Domain.Repositories
{
    public interface IRepository<TDocument> where TDocument: Document
    {
        //TODO: - oleg add other queries
        TDocument Get(Guid id);
        void Add(TDocument document);
        void Drop();
        List<TDocument> GetAll();
        void Delete(TDocument document);
    }
}
