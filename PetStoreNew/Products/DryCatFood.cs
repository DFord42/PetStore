using System;
using System.Text.Json.Serialization;
namespace PetStore
{
	public class DryCatFood : CatFood
	{
			[JsonInclude]
            public double WeightPounds { get; set; }
    }
}

