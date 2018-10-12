using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.IdentityServer4;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using AbpCoreMvcIdentiyServer.Authentication.External;
using AbpCoreMvcIdentiyServer.Authentication.JwtBearer;
using AbpCoreMvcIdentiyServer.Authorization;
using AbpCoreMvcIdentiyServer.Authorization.Users;
using AbpCoreMvcIdentiyServer.MultiTenancy;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AbpCoreMvcIdentiyServer.Web.Validator
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = context.Subject.Claims.ToList();
            context.IssuedClaims = claims.ToList();
        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }


    public class CustomResourceOwnerPasswordValidator<TUser> : AbpResourceOwnerPasswordValidator<TUser>
        where TUser : AbpUser<TUser>
    {
        public CustomResourceOwnerPasswordValidator(
            UserManager<TUser> userManager,
            SignInManager<TUser> signInManager,
            IEventService eventService,
            ILogger<ResourceOwnerPasswordValidator<TUser>> logger)
            : base(
                  userManager,
                  signInManager,
                  eventService,
                  logger)
        {
          
        }

        protected override IEnumerable<Claim> GetAdditionalClaimsOrNull(TUser user)
        {
            return new[] {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(AbpClaimTypes.TenantId, user.TenantId?.ToString()),
            };
        }

    }
}