﻿using castledice_game_data_logic.JSONConverters;
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
            new JsonConverter[] { new GeneratedContentDataConverter(), new PlaceableContentDataConverter() }
        };
        yield return new object[]
        {
            GetKnightData(),
            new JsonConverter[] { new PlaceableContentDataConverter() }
        };
        yield return new object[]
        {
            GetCastleData(),
            new JsonConverter[] { new GeneratedContentDataConverter() }
        };
        yield return new object[]
        {
            GetTreeData(),
            new JsonConverter[] { new GeneratedContentDataConverter() }
        };
    }
}