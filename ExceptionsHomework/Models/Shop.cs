﻿using System.Collections.Generic;

namespace ExceptionsHomework.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Phone> Phones { get; set; }

        public override string ToString()
        {
            return $"{Name}({Id}) - {Description}";
        }
    }
}