using System;

namespace ScheduleCinema.Models.Interfaces
{
    public interface ICinemaSession
    {
        int CinemaSessionId { get; set; }

        int CinemaId { get; set; }

        int MovieId { get; set; }
        
        DateTime CinemaSessionDate { get; set; }
    }
}
