using castledice_game_data_logic.JSONConverters;
using Newtonsoft.Json;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests;

public class JSONSerializationTests
{
    [Theory]
    [MemberData(nameof(SerializationTestCases))]
    public void SerializeObject_ShouldReturnCorrectJSONRepresentationOfAnObject(object toSerialize, params JsonConverter[] converters)
    {
        var json = JsonConvert.SerializeObject(toSerialize,  converters);
        var deserializedObject = JsonConvert.DeserializeObject(json, toSerialize.GetType(), converters);
        
        Assert.Equal(toSerialize, deserializedObject);
    }

    public static IEnumerable<object[]> SerializationTestCases()
    {
        yield return new object[]
        {
            GetGameStartData(),
            new JsonConverter[] { new ContentDataConverter() }
        };
        yield return new object[]
        {
            GetCastleData(),
            new JsonConverter[] { new ContentDataConverter() }
        };
        yield return new object[]
        {
            GetTreeData(),
            new JsonConverter[] { new ContentDataConverter() }
        };
    }
}