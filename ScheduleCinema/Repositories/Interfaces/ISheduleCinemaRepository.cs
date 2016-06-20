using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleCinema.Models;

namespace ScheduleCinema.Repositories.Interfaces
{
    public interface ISheduleCinemaRepository
    {
        IEnumerable<Cinema> GetCinemas();
    }
}