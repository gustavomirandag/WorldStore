using WorldStore.Microservices.IamMicroservice.STS.Identity.Configuration.Interfaces;

namespace WorldStore.Microservices.IamMicroservice.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





