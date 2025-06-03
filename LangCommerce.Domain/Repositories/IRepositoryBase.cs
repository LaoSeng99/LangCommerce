
namespace LangCommerce.Domain.Repositories;

public interface IRepositoryBase<T> where T : class

{
    Task AddAsync(T entity);
    Task SaveAsync();
}
