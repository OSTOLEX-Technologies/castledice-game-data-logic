using castledice_game_data_logic.Content.Generated;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace castledice_game_data_logic.JSONConverters;

public class GeneratedContentDataConverter : JsonConverter<GeneratedContentData>
{
    public override void WriteJson(JsonWriter writer, GeneratedContentData? value, JsonSerializer serializer)
    {
        var defaultSerializer = new JsonSerializer();
        defaultSerializer.Serialize(writer, value);
    }

    public override GeneratedContentData? ReadJson(JsonReader reader, Type objectType, GeneratedContentData? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        var jobj = JObject.ReadFrom(reader);
        var type = jobj["Type"].ToObject<GeneratedContentDataType>();
        return type switch
        {
            GeneratedContentDataType.Castle => jobj.ToObject<CastleData>(),
            GeneratedContentDataType.Tree => jobj.ToObject<TreeData>(),
            _ => throw new ArgumentException("Unfamiliar GeneratedContentDataType: " + type)
        };
    }
}