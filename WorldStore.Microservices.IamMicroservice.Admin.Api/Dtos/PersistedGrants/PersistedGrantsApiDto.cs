using System.Collections.Generic;

namespace WorldStore.Microservices.IamMicroservice.Admin.Api.Dtos.PersistedGrants
{
    public class PersistedGrantsApiDto
    {
        public PersistedGrantsApiDto()
        {
            PersistedGrants = new List<PersistedGrantApiDto>();
        }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<PersistedGrantApiDto> PersistedGrants { get; set; }
    }
}





