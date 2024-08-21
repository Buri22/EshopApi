﻿namespace EshopApi.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string ImgUri { get; set; }
        public required decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
