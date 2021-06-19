using Clinic.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Clinic.Repository
{
    public delegate E CreateEntity<E>(string entityData);

    public abstract class FileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
    {

        protected string filename;
        protected CreateEntity<E> createEntity;


        public FileRepository(String filename, CreateEntity<E> createEntity)
        {
            this.filename = filename;
            this.createEntity = createEntity;
        }

        protected virtual void loadFromFile()
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    E entity = createEntity(line);
                    entities[entity.ID] = entity;
                }
            }
        }

        protected virtual void writeToFile()
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (KeyValuePair<ID, E> entity in entities)
                {
                    sw.WriteLine(entity.Key + "," + entity.Value);
                }
            }
        }

        public virtual void cleanFile()
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write("");
            }
        }
    }
}
