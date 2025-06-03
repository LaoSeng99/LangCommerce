
using LangCommerce.Application.Context;
using LangCommerce.Application.Services.Interfaces.UserAccess;

namespace LangCommerce.Application.Services.UserAccess;

public class UserService(
    UserContext _userContext
    ) : IUserService
{
}
