using System;
using System.Collections.Generic;

namespace CityCenter.Models;

public partial class Роли
{
    public int IdРоли { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Пользователи> Пользователиs { get; } = new List<Пользователи>();
}
