using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ForumProject.Biz.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(IdentityUser user);
    }
}
