﻿namespace MakeUpApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime OpenDate { get; set; }
        public int PAO { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public ProductType? ProductType { get; set; }
    }
}
