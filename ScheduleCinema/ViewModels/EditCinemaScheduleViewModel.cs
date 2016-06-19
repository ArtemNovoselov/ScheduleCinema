using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.ViewModels
{
    public class CinemaScheduleViewModel
    {
        [Key]
        public int CinemaScheduleId { get; set; }
    }
}