using System.Collections.Generic;

namespace AbpCoreMvcIdentiyServer.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
