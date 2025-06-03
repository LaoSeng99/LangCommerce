
using LangCommerce.Domain.Entities;

namespace LangCommerce.Application.Services.Interfaces.AppSystem;

public interface ILanguageService
{
    Task<List<Language>> GetAllAsync();
}
