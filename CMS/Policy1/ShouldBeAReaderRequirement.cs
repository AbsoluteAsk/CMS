using Microsoft.AspNetCore.Authorization;

namespace CMS.Policy1
{
    public class ShouldBeAReaderRequirement
    : IAuthorizationRequirement
    {
    }
}