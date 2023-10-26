using castledice_game_data_logic.Content.Placeable;
using castledice_game_logic.GameObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace castledice_game_data_logic.JSONConverters;

public class PlaceableConfigDataConverter : JsonConverter<PlaceableConfigData>
{
    public override void WriteJson(JsonWriter writer, PlaceableConfigData? value, JsonSerializer serializer)
    {
        var defaultSerializer = new JsonSerializer();
        defaultSerializer.Serialize(writer, value);
    }

    public override PlaceableConfigData? ReadJson(JsonReader reader, Type objectType, PlaceableConfigData? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        var jobj = JObject.ReadFrom(reader);
        var type = jobj["Type"].ToObject<PlacementType>();
        return type switch
        {
            PlacementType.Knight => jobj.ToObject<KnightConfigData>(),
            _ => throw new ArgumentException("Unfamiliar PlacementType: " + type)
        };
    }
}