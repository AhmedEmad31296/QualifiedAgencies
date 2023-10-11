using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace QualifiedAgencies.Localization
{
    public static class QualifiedAgenciesLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(QualifiedAgenciesConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(QualifiedAgenciesLocalizationConfigurer).GetAssembly(),
                        "QualifiedAgencies.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
