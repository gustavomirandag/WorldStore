using System.Collections.Generic;

namespace WorldStore.Microservices.IamMicroservice.Admin.Api.Dtos.Users
{
    public class UserClaimsApiDto<TUserDtoKey>
    {
        public UserClaimsApiDto()
        {
            Claims = new List<UserClaimApiDto<TUserDtoKey>>();
        }

        public List<UserClaimApiDto<TUserDtoKey>> Claims { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}





