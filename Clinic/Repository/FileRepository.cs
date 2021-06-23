using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Clinic
{
    public delegate E CreateEntity<E>(string entityData);

    public abstract class FileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
    {

        protected string _filename;
        protected CreateEntity<E> _createEntity;


        public FileRepository(String filename, CreateEntity<E> createEntity)
        {
            this._filename = filename;
            this._createEntity = createEntity;
        }

        protected virtual void LoadFromFile()
        {
            using (StreamReader sr = new StreamReader(_filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    E entity = _createEntity(line);
                    _entities[entity.ID] = entity;
                }
            }
        }

        protected virtual void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(_filename))
            {
                foreach (KeyValuePair<ID, E> entity in _entities)
                {
                    sw.WriteLine(entity.Key + "," + entity.Value);
                }
            }
        }

        public virtual void CleanFile()
        {
            using (StreamWriter sw = new StreamWriter(_filename))
            {
                sw.Write("");
            }
        }
    }
}
