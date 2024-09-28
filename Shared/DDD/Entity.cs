using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DDD
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime? CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? LastModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? LastModifiedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
