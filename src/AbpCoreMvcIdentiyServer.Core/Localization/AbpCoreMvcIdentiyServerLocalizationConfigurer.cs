using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AbpCoreMvcIdentiyServer.Localization
{
    public static class AbpCoreMvcIdentiyServerLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpCoreMvcIdentiyServerConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpCoreMvcIdentiyServerLocalizationConfigurer).GetAssembly(),
                        "AbpCoreMvcIdentiyServer.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
