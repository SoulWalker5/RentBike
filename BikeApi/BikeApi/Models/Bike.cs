using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BikeApi.Models
{
    public class Bike
    {
        [Required]
        public int BikeId { get; set; }
        [Required]
        public string BikeName { get; set; }
        [Required]
        public decimal BikePrice { get; set; }

        [Required]
        public int BikeTypeId { get; set; }
        [Required]
        public int RentStateId { get; set; }

        public IEnumerable<BikeType> BikeTypes { get; set; }
        public IEnumerable<RentState> RentStates { get; set; }
    }
}