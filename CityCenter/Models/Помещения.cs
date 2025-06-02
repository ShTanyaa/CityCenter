using System;
using System.Collections.Generic;

namespace CityCenter.Models;

public partial class Помещения
{
    public int IdПомещения { get; set; }

    public string Название { get; set; } = null!;

    public string Расположение { get; set; } = null!;

    public int Этаж { get; set; }

    public decimal Площадь { get; set; }

    public decimal СтоимостьАренды { get; set; }

    public bool ДоступноДляАренды { get; set; }

    public string? Фото { get; set; }

    public string? Описание { get; set; }

    public int? IdНазначения { get; set; }

    public string? СсылкаНаМагазин { get; set; }

    public virtual НазначенияПомещений? IdНазначенияNavigation { get; set; }

    public virtual ICollection<Аренда> Арендаs { get; set; } = new List<Аренда>();

    public virtual ICollection<Мероприятия> Мероприятияs { get; set; } = new List<Мероприятия>();

    public virtual ICollection<SvgRoom> SvgRooms { get; set; } = new HashSet<SvgRoom>();
}
