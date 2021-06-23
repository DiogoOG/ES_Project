using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        E Save(E Entity);
        int Size();
        E Edit(E newEntity);
    }
}
