
using LangCommerce.Application.Mapping.Product;
using Mapster;

namespace LangCommerce.Application.Mapping;

public interface IMapsterConfig
{
    void Register(TypeAdapterConfig config);
}

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        var config = TypeAdapterConfig.GlobalSettings;

        var configs = new List<IMapsterConfig>
        {
            new ProductMapsterConfig()
        };
        foreach (var mapConfig in configs)
            mapConfig.Register(config);
    }
}
