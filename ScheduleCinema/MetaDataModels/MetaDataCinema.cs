using System.ComponentModel.DataAnnotations;

namespace ScheduleCinema.MetaDataModels
{
    public class MetatDataCinema
    {
        [Display(Name = "Адрес кинотеатра")]
        public string CinemaAddress { get; set; }
        
        [Display(Name = "Название кинотеатра")]
        public string CinemaName { get; set; }
    }
}
