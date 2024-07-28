using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
namespace BasicShop.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
