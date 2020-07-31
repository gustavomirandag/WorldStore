using WorldStore.Microservices.IamMicroservice.Admin.Configuration.Identity;
using System.Collections.Generic;

namespace WorldStore.Microservices.IamMicroservice.Admin.Configuration
{
    public class IdentityDataConfiguration
    {
       public List<Role> Roles { get; set; }
       public List<User> Users { get; set; }
    }
}






