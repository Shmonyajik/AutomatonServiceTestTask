using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Keeper
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }


    }
}
