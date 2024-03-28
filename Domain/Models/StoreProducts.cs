using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StoreProducts
    {

        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("storeId")]
        public int StoreId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("product")]
        public virtual Product Product { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

    }
}
