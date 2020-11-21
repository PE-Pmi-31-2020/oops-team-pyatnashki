using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FiveOursDAL.Configurations;
using FiveOursDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiveOursDAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ProjectDbContext Context;
        protected DbSet<TEntity> Entities;

        public Repository(ProjectDbContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

    }
}

