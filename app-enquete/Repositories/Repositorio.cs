using app_enquete.contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace app_enquete.Repositories
{
    internal class Repositorio<T> : IRepositorio<T> where T : class
    {
        internal Contexto contexto;
        internal DbSet<T> dbSet;


        private Repositorio(Contexto contexto, bool lazyLoader)
        {
            this.contexto = contexto;
            this.dbSet = this.contexto.Set<T>();
            this.SetLazyLoader(lazyLoader);
        }

        public void SetLazyLoader(bool lazyLoader)
        {
            if (lazyLoader)
            {
                this.contexto.ChangeTracker.LazyLoadingEnabled = true;
                this.contexto.ChangeTracker.AutoDetectChangesEnabled = true;
            }
            else
            {
                this.contexto.ChangeTracker.LazyLoadingEnabled = false;
                this.contexto.ChangeTracker.AutoDetectChangesEnabled = false;
            }
        }

        internal static Repositorio<T> Create(Contexto contexto)
        {
            return new Repositorio<T>(contexto, false);
        }
        internal static Repositorio<T> CreateLazyLoad(Contexto contexto)
        {
            return new Repositorio<T>(contexto, true);
        }

        public virtual async Task Delete(int id)
        {
            T entityToDelete = await dbSet.FindAsync(id);
            await Delete(entityToDelete);
        }
        public virtual async Task Delete(T entityToDelete)
        {
            if (this.contexto.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            await Task.Run(() => dbSet.Remove(entityToDelete));
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Get(int id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }



        public virtual async Task<IEnumerable<T>> Gets()
        {
            return await this.dbSet.ToListAsync();
        }

        public virtual async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task<int> Save()
        {
            return await this.contexto.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            dbSet.Attach(entity);
            await Task.Run(() => this.contexto.Entry(entity).State = EntityState.Modified);
        }

        public virtual async Task<IEnumerable<T>> Gets(string includeProperties = "")
        {
            IQueryable<T> query = this.dbSet;


            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id, string includeProperties = "")
        {

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                this.dbSet.Include(includeProperty);
            }

            return await this.dbSet.FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

           
            return await query.CountAsync();
        }
    }
}
