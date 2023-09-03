using System;
using PetStore;
using System.Text.Json.Serialization;
namespace PetStore
{

    // This declares the base or parent class of Product
    public class Product
    {
        [JsonInclude]
        public string Name {get; set;}
        [JsonInclude]
        public decimal Price { get; set; }
        [JsonInclude]
        public int Quantity { get; set; }
        [JsonInclude]
        public string Description { get; set; }

    }
}
