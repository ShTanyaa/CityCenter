namespace CityCenter.Models
{
    public class ДеятельностьАрендатора
    {
        public int ID_Арендатора { get; set; }
        public int ID_Деятельности { get; set; }

        // Навигационные свойства (по желанию)
        public Арендаторы Арендатор { get; set; }
        public ВидДеятельности ВидДеятельности { get; set; }
    }
}
