using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PeopleApi.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public HairColor HairColor { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HairColor
    {
        Brunette = 1,
        Blonde = 2,
        Ginger = 3,
        Other = 4
    }

}
