﻿using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public string Brand { get; set; }

        public string ModelNumber { get; set; }
        [Required]
        [Range(1,10000)]
        public double Price { get; set; }
        [Required]
        [Range(0,10000)]
        public int InStockQuantity { get; set; }

        //public string ImageUrl { get; set; }

    }
}
