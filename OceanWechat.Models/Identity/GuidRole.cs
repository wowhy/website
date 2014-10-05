using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OceanWechat.Models.Identity
{
    public class GuidRole : IdentityRole<Guid, GuidUserRole>
    {
    }
}
