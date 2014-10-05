namespace OceanWechat.Models.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class GuidDbContext<TUser> : 
        IdentityDbContext<TUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim> 
        where TUser : GuidUser
    {
        public GuidDbContext(){}
        public GuidDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public GuidDbContext(string nameOrConnectionString, bool throwIfV1Schema)
            : base(nameOrConnectionString)
        {
        }

        public GuidDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
    }
}