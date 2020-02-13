using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PeopleApi.Model
{
    public class Car
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int OwnderId { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public KnownColor Color { get; set; }
        public int ModelYear { get; set; }
    }
}
