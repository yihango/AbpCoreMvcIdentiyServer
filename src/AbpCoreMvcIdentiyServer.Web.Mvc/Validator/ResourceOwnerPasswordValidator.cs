using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using AbpCoreMvcIdentiyServer.Authentication.External;
using AbpCoreMvcIdentiyServer.Authentication.JwtBearer;
using AbpCoreMvcIdentiyServer.Authorization;
using AbpCoreMvcIdentiyServer.Authorization.Users;
using AbpCoreMvcIdentiyServer.MultiTenancy;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AbpCoreMvcIdentiyServer.Web.Validator
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public IAbpSession AbpSession { get; set; }
        private readonly IConfiguration _appConfiguration;
        private readonly LogInManager _logInManager;
        private readonly ITenantCache _tenantCache;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly TokenAuthConfiguration _configuration;
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        private readonly IExternalAuthManager _externalAuthManager;
        private readonly UserRegistrationManager _userRegistrationManager;


        public ResourceOwnerPasswordValidator(
            IConfiguration appConfiguration,
            LogInManager logInManager,
            ITenantCache tenantCache,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            TokenAuthConfiguration configuration,
            IExternalAuthConfiguration externalAuthConfiguration,
            IExternalAuthManager externalAuthManager,
            UserRegistrationManager userRegistrationManager)
        {
            AbpSession = NullAbpSession.Instance;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var loginResult = await GetLoginResultAsync(
                         context.UserName,
                         context.Password,
                         GetTenancyNameOrNull()
                     );

                context.Result = new GrantValidationResult(
                    subject: context.UserName,
                    authenticationMethod: "custom",
                    claims: CreateJwtClaims(loginResult.Identity)
                    );
            }
            catch (Exception e)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, e.Message);
            }

            ////根据context.UserName和context.Password与数据库的数据做校验，判断是否合法
            //if (context.UserName == "admin" && context.Password == "123")
            //{
            //    context.Result = new GrantValidationResult(
            //        subject: context.UserName,
            //        authenticationMethod: "custom",
            //        claims: new Claim[]
            //        {
            //            new Claim("Name", context.UserName),

            //            new Claim("UserId", "1"),
            //            new Claim("RealName", "玩双截棍的熊猫"),
            //            new Claim("Email", "msmadaoe@msn.com")
            //        });
            //}
            //else
            //{
            //    //验证失败
            //    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            //}
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }


        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }
    }
}