namespace OceanWechat.Models.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class GuidUser : 
        IdentityUser<Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>, IUser<Guid>
    {
    }
}