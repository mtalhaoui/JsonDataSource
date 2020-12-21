using System.Linq;

namespace JsonDataSource.Data
{
    public interface IDataContext<T>
    {
        IQueryable<T> Get();
        void Add(T model);
    }
}