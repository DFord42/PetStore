﻿using System;
using System.Text.Json.Serialization;

namespace PetStore.Data
{
	public class ProductEntity 
	{
       
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public decimal Price { get; set; }

       
        public int Quantity { get; set; }

        
        public string Description { get; set; }
       
	}
}

