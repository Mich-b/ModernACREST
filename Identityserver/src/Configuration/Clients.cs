﻿using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // MoviesWebApp Client
                new Client
                {
                    ClientId = "movieswebapp",
                    ClientName = "The Movie App",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris =           { "http://movieswebapp:8081/signin-oidc" },
                    PostLogoutRedirectUris = { "http://movieswebapp:8081/signout-callback-oidc" },
                    AllowedCorsOrigins =     { "" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "role"
                     }
                },
                // Postman client credentials flow
                new Client
                {
                    ClientId = "postman",
                    ClientName = "postman",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        //Not useful to include identityscopes, as an identity token is not returned anyway: https://github.com/IdentityServer/IdentityServer3/issues/1782
                        //IdentityServerConstants.StandardScopes.OpenId,
                        //IdentityServerConstants.StandardScopes.Profile,
                        //IdentityServerConstants.StandardScopes.Email,
                        //IdentityServerConstants.StandardScopes.Address,
                        //"role",
                        "dummyapi.read"
                    }
                },

            };
        }
    }
}
