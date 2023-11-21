using castledice_game_data_logic.TurnSwitchConditions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace castledice_game_data_logic.JSONConverters;

public class TscDataConverter : JsonConverter<TscData>
{
    public override void WriteJson(JsonWriter writer, TscData? value, JsonSerializer serializer)
    {
        var defaultSerializer = new JsonSerializer();
        defaultSerializer.Serialize(writer, value);
    }

    public override TscData? ReadJson(JsonReader reader, Type objectType, TscData? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var jobj = JObject.ReadFrom(reader);
        var type = jobj["Type"].ToObject<TscType>();
        return type switch
        {
            TscType.Time => jobj.ToObject<TimeConditionData>(),
            TscType.ActionPoints => jobj.ToObject<ActionPointsConditionData>(),
            _ => throw new ArgumentException("Unfamiliar TscType: " + type)
        };
    }
}