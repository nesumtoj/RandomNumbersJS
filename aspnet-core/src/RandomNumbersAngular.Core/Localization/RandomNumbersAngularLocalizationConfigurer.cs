using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace RandomNumbersAngular.Localization
{
    public static class RandomNumbersAngularLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(RandomNumbersAngularConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(RandomNumbersAngularLocalizationConfigurer).GetAssembly(),
                        "RandomNumbersAngular.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
