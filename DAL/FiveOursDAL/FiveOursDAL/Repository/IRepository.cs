using System;
using FiveOursDAL.Entities;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FiveOursDAL.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();


        void Add(TEntity entity);

    }
}
