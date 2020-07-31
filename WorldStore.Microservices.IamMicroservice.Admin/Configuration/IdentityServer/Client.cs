using System.Collections.Generic;
using WorldStore.Microservices.IamMicroservice.Admin.Configuration.Identity;

namespace WorldStore.Microservices.IamMicroservice.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






