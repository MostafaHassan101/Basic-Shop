//using Duende.IdentityServer.Services;
//using BasicShop.Application.Common.Behaviours;

//namespace BasicShop.Infrastructure.Identity;

//public class IdentityServerTokenValidator : ITokenValidator
//{
//    private readonly IIdentityServerInteractionService _interaction;

//    public IdentityServerTokenValidator(IIdentityServerInteractionService interaction)
//    {
//        _interaction = interaction;
//    }

//    //public bool ValidateToken(string token)
//    //{
//    //    var result = _interaction.GetAuthorizationContextAsync(token).Result;
//    //    return result != null;
//    //}

//    public async Task<bool> ValidateTokenAsync(string token)
//    {
//        var result = _interaction.GetAuthorizationContextAsync(token).Result;

//        return result != null;
//    }
//}
