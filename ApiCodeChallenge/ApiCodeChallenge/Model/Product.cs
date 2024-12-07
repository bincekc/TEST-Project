﻿namespace ApiCodeChallenge.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Category { get; set; }
        public int Price { get; set; }

        public int Stock { get; set; }
    }
}
