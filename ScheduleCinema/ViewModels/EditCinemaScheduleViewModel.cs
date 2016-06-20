using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.ViewModels
{
    public class EditCinemaScheduleViewModel
    {
        public int CinemaScheduleId { get; set; }
        
        public DateTime ScheduleDate { get; set; }
        
        public string ScheduleDescription { get; set; }

        public Cinema Cinema { get; set; }
        
        public ICollection<CinemaSession> CinemaSessions { get; set; }

        EditCinemaScheduleViewModel()
        {
            
        }

    }
}