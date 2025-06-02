using System.ComponentModel.DataAnnotations;

namespace CityCenter.Models
{
    public class ЗаявкаНаАренду
    {
        [Key]
        public int ID_Заявки { get; set; }
        public int ID_Пользователя { get; set; }
        public int ID_Помещения { get; set; }
        public DateTime ДатаЗаявки { get; set; }
        public string? ФотоОплаты { get; set; }
        public string? Комментарий { get; set; }
        public string Статус { get; set; } = "В обработке";

        public Пользователи Пользователь { get; set; }
        public Помещения Помещение { get; set; }
    }

}
