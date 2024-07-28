//using Duende.IdentityServer.Models;

//namespace BasicShop.Infrastructure.Identity;

//public static class Config
//{
//    public static IEnumerable<IdentityResource> IdentityResources =>
//        new IdentityResource[]
//        {
//            new IdentityResources.OpenId(),
//            new IdentityResources.Profile(),
//        };

//    public static IEnumerable<ApiScope> ApiScopes =>
//        new ApiScope[]
//        {
//            new ApiScope("api.scope", "API Scope"),
//        };

//    public static IEnumerable<Client> Clients =>
//        new Client[]
//        {
//            new Client
//            {
//                ClientId = "client",
//                ClientSecrets = { new Secret("secret".Sha256()) },
//                AllowedGrantTypes = GrantTypes.ClientCredentials,
//                AllowedScopes = { "api.scope" },

//            },
//        };
//}
