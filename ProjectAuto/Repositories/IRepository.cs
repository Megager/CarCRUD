using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAuto.Repositories
{
    public interface IRepository<Entity> where Entity:class
    {
        Entity get(int ID);
        IEnumerable<Entity> getAll();
        IEnumerable<Entity> find(Expression<Func<Entity,bool>> predicate);
        void add(Entity entity);
        void update(Entity entity, int ID);
        void remove(Entity entity);

    }
}
