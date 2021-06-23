using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic
{

    public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected IDictionary<ID, E> _entities = new Dictionary<ID, E>();

        public virtual IEnumerable<E> FindAll()
        {
            return _entities.Values;
        }

        public virtual E FindOne(ID id)
        {
            if (_entities.ContainsKey(id))
                return _entities[id];
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
            if (_entities.ContainsKey(entity.ID))
                return null;
            else _entities.Add(entity.ID, entity);
            return entity;
        }

        public int Size()
        {
            return _entities.Count;
        }

        public virtual E Edit(E newEntity)
        {
            if (newEntity == null)
                throw new ArgumentException("Entity cannot be null!");
            if (!_entities.ContainsKey(newEntity.ID))
                return null;
            else
            {
                _entities.Remove(newEntity.ID);
                _entities.Add(newEntity.ID, newEntity);
            }
            return newEntity;
        }
    }
}
