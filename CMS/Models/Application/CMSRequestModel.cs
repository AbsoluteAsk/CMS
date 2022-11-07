using CMS.Models.User;

namespace CMS.Models.Application
{
    public class CMSRequestModel
    {
        public UserMain user { get; set; }
        public UserReq csr { get; set; }
        public object Id { get; internal set; }
    }
}
