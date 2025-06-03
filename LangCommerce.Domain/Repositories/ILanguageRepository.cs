
using LangCommerce.Domain.Entities;

namespace LangCommerce.Domain.Repositories;

public interface ILanguageRepository
{
    Task<List<Language>> GetAllAsync();
}
