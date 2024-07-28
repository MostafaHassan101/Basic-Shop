using BasicShop.Application.Common.Interfaces;
using BasicShop.Domain.Entities;
using BasicShop.Infrastructure.Identity;
using E_Commerce.Application.UserMangment.UserRoles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BasicShop.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IIdentityService _identityService;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context
        , UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IIdentityService identityService)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _identityService = identityService;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        /// Default roles
        await SeedRolesAsync();

        /// Default users
        await SeedUsersAsync();

        /// Default products
        await SeedProductsAsync();

    }

    private async Task SeedRolesAsync()
    {
        var adminRole = new IdentityRole(SysRoles.Admin);
        var customerRole = new IdentityRole(SysRoles.Customer);

        if (_roleManager.Roles.All(r => r.Name != adminRole.Name))
        {
            await _roleManager.CreateAsync(adminRole);
        }

        if (_roleManager.Roles.All(r => r.Name != customerRole.Name))
        {
            await _roleManager.CreateAsync(customerRole);
        }
    }

    private async Task SeedUsersAsync()
    {
        string adminEmail = "admin@admin.com";
        var administrator = new ApplicationUser { FirstName = "admin", LastName = "admin", UserName = adminEmail, Email = adminEmail };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _identityService.CreateUserAsync(administrator.UserName, "Admin123!!!", administrator.FirstName, administrator.LastName);
        }
    }

    private async Task SeedProductsAsync()
    {
        if (!_context.Products.Any())
        {
            var products = new[]
            {
                new Product { Id = Guid.NewGuid(), Name = "Cash Money Gun", Price = (decimal) 43.0, Quantity = 38, IsVisible = true },
                new Product { Id = Guid.NewGuid(), Name = "Giant Inflatable Unicorn", Price = (decimal) 23.5, Quantity = 3, IsVisible = false },
                new Product { Id = Guid.NewGuid(), Name = "Deal With It Sunglasses", Price = (decimal) 11.2, Quantity = 17, IsVisible = true },
                new Product { Id = Guid.NewGuid(), Name = "Breaking Bad \"Lego\" Set", Price = (decimal) 699.5, Quantity = 0, IsVisible = true }
            };

            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
        }
    }
}
