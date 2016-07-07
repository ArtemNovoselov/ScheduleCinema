using System;

namespace ScheduleCinema.Models.Interfaces
{
    public interface ICinemaSessionSpec
    {
        int CinemaSessionSpecId { get; set; }

        TimeSpan CinemaSessionSpecTime { get; set; }
        
        decimal? CinemaSessionSpecPrice { get; set; }

        int CinemaSessionId { get; set; }
    }
}
