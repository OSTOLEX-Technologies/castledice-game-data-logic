using castledice_game_data_logic.Content;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace castledice_game_data_logic.JSONConverters;

public class ContentDataConverter : JsonConverter<ContentData>
{
    public override void WriteJson(JsonWriter writer, ContentData? value, JsonSerializer serializer)
    {
        var defaultSerializer = new JsonSerializer();
        defaultSerializer.Serialize(writer, value);
    }

    public override ContentData? ReadJson(JsonReader reader, Type objectType, ContentData? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        var jobj = JObject.ReadFrom(reader);
        var type = jobj["Type"].ToObject<ContentDataType>();
        return type switch
        {
            ContentDataType.Castle => jobj.ToObject<CastleData>(),
            ContentDataType.Tree => jobj.ToObject<TreeData>(),
            ContentDataType.Knight => jobj.ToObject<KnightData>(),
            _ => throw new ArgumentException("Unfamiliar ContentDataType: " + type)
        };
    }
}