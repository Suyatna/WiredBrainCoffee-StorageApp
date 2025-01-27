﻿namespace WiredBrainCoffee_StorageApp.Entities
{
    public class Organization : EntityBase
    {      
        public string? Name { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}
