
using Mapster;

namespace LangCommerce.Application.Mapping.User;

public class UserMapsterConfig : IMapsterConfig
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Domain.Entities.User, Domain.Entities.User>();
    }
}
