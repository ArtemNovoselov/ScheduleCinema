using System.ComponentModel.DataAnnotations;

namespace ScheduleCinema.MetaDataModels
{
    public class MetatDataCinemaSession
    {
        [Display(Name = "Адрес кинотеатра")]
        public string CinemaAddress { get; set; }
        
        [Display(Name = "Название кинотеатра")]
        public string CinemaName { get; set; }
    }
}
