using System.Text.Json.Serialization;


namespace BikeFactory2.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum EBikeCriteria
{
    All,
    Front,
    Rear,
    Dual
}
