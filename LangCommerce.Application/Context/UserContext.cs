
namespace LangCommerce.Application.Context;

public class UserContext
{
    public string LanguageCode { get; set; } = "en-US"; 

    public bool IsEnglish => LanguageCode == "en-US";
}
