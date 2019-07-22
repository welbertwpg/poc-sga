// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[] 
            {
                new ApiResource("ativos", "Api de Ativos"),
                new ApiResource("monitoramento", "Api de Monitoriamento"),
                new ApiResource("processos", "Api de Processos Minerarios")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[] 
            {
                new Client
                {
                    ClientId = "api.gateway",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "ativos", "monitoramento", "processos" }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "joao",
                    Password = "silva123"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "maria",
                    Password = "silva123"
                }
            };
        }
    }
}