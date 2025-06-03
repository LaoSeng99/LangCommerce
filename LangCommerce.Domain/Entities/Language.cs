

namespace LangCommerce.Domain.Entities;

public class Language
{
    public int Id { get; set; } 
    public string Code { get; set; }
    public string DisplayName { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsDefault { get; set; }  //Only one language can be set true
}
