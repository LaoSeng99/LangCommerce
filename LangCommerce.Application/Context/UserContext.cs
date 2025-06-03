
namespace LangCommerce.Application.Context;

public class UserContext
{
    public string LanguageCode { get; set; } = "zh-CN"; 

    public bool IsEnglish => LanguageCode == "en-US";
}
