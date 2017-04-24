using HPlusSports.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSports.DAL
{
    public interface ITrackingRepository<T> where T : TrackedEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int Id);
        Task<List<T>> Get<T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T2>> order);
        void Save(T Item);
        void Add(T Item);
        void SaveAll(IEnumerable<T> Items);
        void AddAll(IEnumerable<T> Items);
        Task Delete(int PrimaryKey);

        Task SaveChanges();
        Task<IDbContextTransaction> StartTransaction();


    }
}
