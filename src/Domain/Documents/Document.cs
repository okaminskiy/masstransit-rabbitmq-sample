using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Documents
{
    public abstract class Document
    {
        public Guid Id { get; set; }
    }
}
