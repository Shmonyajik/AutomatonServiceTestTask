using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Store
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("keeperId")]
        public int KeeperId { get; set; }

        [JsonProperty("keeper")]
        public virtual Keeper? Keeper { get; set; }

        [JsonProperty("products")]
        public virtual ICollection<Product> Products { get; set; }


    }
}
