using System;

namespace ScheduleCinema.Models.Interfaces
{
    public interface IMovie
    {
        int MovieId { get; set; }

        string MovieName { get; set; }

        string MovieDirector { get; set; }

        TimeSpan MovieDuration { get; set; }
    }
}
