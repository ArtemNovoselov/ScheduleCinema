namespace ScheduleCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public class MetatDataCinema
    {
        [Display(Name = "Адрес кинотеатра")]
        public string CinemaAddress { get; set; }
        
        [Display(Name = "Название кинотеатра")]
        public string CinemaName { get; set; }
    }
}
