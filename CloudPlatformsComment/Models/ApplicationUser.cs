using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
