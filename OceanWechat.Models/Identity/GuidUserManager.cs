namespace OceanWechat.Models.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    public class GuidUserManager<TUser> :
        UserManager<TUser, Guid>
        where TUser : class, IUser<Guid>
    {
        public GuidUserManager(IUserStore<TUser, Guid> store)
            : base(store)
        {
        }
    }
}