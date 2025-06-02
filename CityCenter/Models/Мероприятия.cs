using System;
using System.Collections.Generic;

namespace CityCenter.Models;

public partial class Мероприятия
{
    public int IdМероприятия { get; set; }

    public string Название { get; set; } = null!;

    public string? Описание { get; set; }

    public DateTime ДатаМероприятия { get; set; }

    public int IdПомещения { get; set; }

    public virtual Помещения IdПомещенияNavigation { get; set; } = null!;
}
