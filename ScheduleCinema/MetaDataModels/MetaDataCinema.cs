using System.ComponentModel.DataAnnotations;

namespace ScheduleCinema.MetaDataModels
{
    public class MetatDataCinema
    {
        [Display(Name = "����� ����������")]
        public string CinemaAddress { get; set; }
        
        [Display(Name = "�������� ����������")]
        public string CinemaName { get; set; }
    }
}
