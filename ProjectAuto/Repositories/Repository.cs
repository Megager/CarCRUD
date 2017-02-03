using Ninject;
using ProjectAuto.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectAuto.Repositories
{
    public class Repository<Entity>:IRepository<Entity> where Entity:class
    {

        private DbContext Context;

        public Repository(IDBContext context) 
        {
            Context = context as DbContext;
        }


        public Entity get(int ID) 
        {
            return Context.Set<Entity>().Find(ID);
        }

        public IEnumerable<Entity> getAll() 
        {
            return Context.Set<Entity>().ToList();
        }

        public IEnumerable<Entity> find(Expression<Func<Entity, bool>> predicate) 
        {
            return Context.Set<Entity>().Where(predicate);
        }

        public void add(Entity entity) 
        {
            Context.Set<Entity>().Add(entity);
            Context.SaveChanges();
        }

        public void update(Entity entity, int ID) 
        {
            if (entity != null) 
            {
                Entity oldEntity = Context.Set<Entity>().Find(ID);
                if (oldEntity != null) 
                {
                    Context.Entry(oldEntity).CurrentValues.SetValues(entity);
                    Context.SaveChanges();
                }
            }
        }

        public void remove(Entity entity)
        {
            Context.Set<Entity>().Remove(entity);
            Context.SaveChanges();
        }



    }
}