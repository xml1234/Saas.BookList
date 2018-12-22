using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Yoyosoft.BookList.Localization
{
    public static class BookListLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BookListConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BookListLocalizationConfigurer).GetAssembly(),
                        "Yoyosoft.BookList.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
