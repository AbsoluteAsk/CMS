using Microsoft.AspNetCore.Authorization;

namespace CMS.Policy1.Requirements
{
    public class ShouldBeAReaderRequirement
    : IAuthorizationRequirement
    {
    }
}