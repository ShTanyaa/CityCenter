namespace CityCenter.Models
{
    public class SvgRoom
    {
        public int Id { get; set; }

        public string StoreId { get; set; } = string.Empty; // внешний ключ на Помещения.Расположение
        public int Floor { get; set; }

        public string? IconUrl { get; set; }

        public string? Type { get; set; }

        // 🔗 Навигационное свойство
        public virtual Помещения? Помещение { get; set; }
    }

}
