using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Application.Contracts
{
    public interface IRepository<T> where T : class
    {
        #region Methods
        Task<List<T>> Get();
        Task<T> GetById(long id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> DeleteById(long id);
        #endregion
    }
}
