using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace LocalizationComponent
{
    public class DictionaryLocalizer : IStringLocalizer
    {
        IDictionary<string, string> dictDictionary;

        private DictionaryLocalizer(IDictionary<string, string> dictDictionary)
        {
            this.dictDictionary = dictDictionary;
        }

        public LocalizedString this[string sName]
        {
            get
            {
                string? sValue = string.Empty;

                if (dictDictionary.TryGetValue(sName, out sValue) == true)
                    return new LocalizedString(sName, sValue, false);

                return new LocalizedString(sName, "LOCALIZATION_NOT_FOUND", true);
            }
        }

        public LocalizedString this[string sName, params object[] oArgs]
        {
            get
            {
                string? sValue = string.Empty;

                if (dictDictionary.TryGetValue(sName, out sValue) == true)
                    return new LocalizedString(sName, string.Format(sValue, oArgs), false);

                return new LocalizedString(sName, "LOCALIZATION_NOT_FOUND", true);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool bIncludeParentCultures)
        {
            foreach (KeyValuePair<string, string> kvpEntry in dictDictionary)
            {
                yield return new LocalizedString(kvpEntry.Key, kvpEntry.Value, false);
            }
        }

        public static DictionaryLocalizer? Initialize(IDictionary<string, string> dictDictionary)
        {
            if (dictDictionary is null)
                return null;

            return new DictionaryLocalizer(dictDictionary);
        }
    }
}
