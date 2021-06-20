using Clinic.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Repository
{

    public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected IDictionary<ID, E> entities = new Dictionary<ID, E>();

        public virtual IEnumerable<E> FindAll()
        {
            return entities.Values;
        }

        public virtual E FindOne(ID id)
        {
            if (entities.ContainsKey(id))
                return entities[id];
            return default(E);
        }


        /*
         * input: an entity
         * return the given entity if saved, null otherwise
         */
        public virtual E Save(E entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity cannot be null!");
            if (entities.ContainsKey(entity.ID))
                return null;
            else entities.Add(entity.ID, entity);
            return entity;
        }

        public int Size()
        {
            return entities.Count;
        }
    }
}
