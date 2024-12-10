using System.Text.Json;
using System.Text.Json.Serialization;

namespace LocalizationComponent
{
    public class DictionaryConverter : JsonConverter<string>
    {
        private readonly string sCultureName;
        private readonly string sFallbackCultureName;

        public DictionaryConverter(string sCultureName, string sFallbackCultureName = CultureName.Fallback)
        {
            this.sCultureName = sCultureName;
            this.sFallbackCultureName = sFallbackCultureName;
        }

        public override string? Read(ref Utf8JsonReader jsonReader, Type gTypeToConvert, JsonSerializerOptions jsonOption)
        {
            using (JsonDocument jsonDocument = JsonDocument.ParseValue(ref jsonReader))
            {
                JsonElement jsonElement;

                if (jsonDocument.RootElement.TryGetProperty(sCultureName, out jsonElement) == false)
                    jsonElement = jsonDocument.RootElement.GetProperty(sFallbackCultureName);

                return jsonElement.GetString();
            }
        }

        public override void Write(Utf8JsonWriter jsonWriter, string sValue, JsonSerializerOptions jsonOption)
        {
            throw new NotImplementedException();
        }
    }
}
