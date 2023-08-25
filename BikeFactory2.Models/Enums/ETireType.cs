using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeFactory2.Models.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]

public enum ETireType
{
    Undefined,
    Regular,
    Commuter,
    Gravel
}
