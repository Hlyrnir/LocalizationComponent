using Microsoft.Extensions.Localization;

namespace LocalizationComponent
{
    public sealed class LocalizationState
    {
        private readonly string sCultureName;
        private readonly IDictionary<string, string> dictLocalization;

        private LocalizationState(string sCultureName, IDictionary<string, string> dictLocalization)
        {
            this.sCultureName = sCultureName;
            this.dictLocalization = dictLocalization;
        }

        public string CultureName { get => sCultureName; }

        public IStringLocalizer? DictionaryLocalizer
        {
            get => LocalizationComponent.DictionaryLocalizer.Initialize(dictLocalization);
        }

        public static LocalizationState Initialize(string sCultureName, IDictionary<string, string> dictLocalization)
        {
            return new LocalizationState(sCultureName, dictLocalization);
        }
    }
}
