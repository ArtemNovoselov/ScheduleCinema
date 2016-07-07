namespace ScheduleCinema.Models.Interfaces
{
    public interface ICinema
    {
        int CinemaId { get; set; }
        string CinemaAddress { get; set; }
        string CinemaName { get; set; }
    }
}
