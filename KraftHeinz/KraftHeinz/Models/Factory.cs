using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace KraftHeinz.Models
{
    public class Factory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Region { get; set; }

        public List<Reservoir> Reservoirs { get; set; }
        public List<PowerPlant> PowerPlants { get; set; }
    }

    public class Reservoir
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int FactoryId { get; set; }

        public Factory Factory { get; set; }
    }

    public class PowerPlant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int FactoryId { get; set; }

        public Factory Factory { get; set; }
    }
}

