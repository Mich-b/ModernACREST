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

                // JavaScript Client
                new Client
                {
                    ClientId = "JSClient",
                    ClientName = "JSClient",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris =           { "/callback.html" },
                    PostLogoutRedirectUris = { "/index.html" },
                    AllowedCorsOrigins =     { "" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "product.read",
                        "product.readwrite",
                    }
                },
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
                // Postman resource owner flow
                new Client

                {
                    ClientId = "postman",
                    ClientName = "postman",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "product.read" }
                },

                // Postman client credentials
                new Client

                {
                    ClientId = "postmanclientgrant",
                    ClientName = "postmanclientgrant",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "product.read" }
                },
            };
        }
    }
}
