using AutoMapper;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Common.Models;
using E_Commerce.Application.UserMangment.UserRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace BasicShop.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;

    //private readonly IIdentityServerInteractionService _interactionService;


    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService,
        IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _mapper = mapper;
    }

    public async Task<string?> GetUserNameAsync(string userName)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userName);

        return user?.UserName;
    }
    public async Task<string?> GetUserIdAsync(string userName)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == userName);

        return user?.Id;
    }


    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password,
        string fName, string lName)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
            FirstName = fName,
            LastName = lName
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, SysRoles.Customer);
        }

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync<T>(T applicationUserDto, string password)
    {
        var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDto);

        var result = await _userManager.CreateAsync(applicationUser, password);
        if (result.Succeeded)
        {
            // Assign a role to the user (if needed)
            await _userManager.AddToRoleAsync(applicationUser, SysRoles.Customer);

        }

        return (result.ToApplicationResult(), applicationUser.Id);
    }

    public async Task<Result> UpdateUserAsync<T>(string userId, T updateUserDto)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            return Result.Failure(new List<string> { "User not found" });

        var updateUser = _mapper.Map(updateUserDto, user);

        var result = await _userManager.UpdateAsync(updateUser);

        return result.ToApplicationResult();
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
        //var user = _userManager.Users.SingleOrDefault(u => u.Email == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
        //var validatePassword = _userClaimsPrincipalFactory.
        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<bool> UserIsExist(string email)
    {
        return await _userManager.Users.AnyAsync(u => u.Email == email);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public Task<Result> SignInAsync(string email, string password, bool rememberMe)
    {
        var sign = _signInManager.PasswordSignInAsync(email, password, rememberMe, false).Result;

        return Task.FromResult(sign.Succeeded ? Result.Success() : Result.Failure(new List<string> { "Invalid login attempt." }));
    }

    public async Task<List<string>> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.Users.SingleAsync(u => u.Id == userId);
        var roles = await _userManager.GetRolesAsync(user);
        return user != null ? (await _userManager.GetRolesAsync(user)).ToList() : new List<string>();
    }

    // change password
    public async Task<Result> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
    {
        var user = await _userManager.Users.SingleAsync(u => u.Id == userId);
        var validPassword = await _userManager.CheckPasswordAsync(user, currentPassword);
        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return result.ToApplicationResult();
    }
}