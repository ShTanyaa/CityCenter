using System;
using System.Collections.Generic;

namespace CityCenter.Models;

public partial class Пользователи
{
    public int IdПользователя { get; set; }

    public string Фио { get; set; } = null!;

    public string? Телефон { get; set; }

    public string Email { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public int IdРоли { get; set; }

    public virtual Роли IdРолиNavigation { get; set; } = null!;

    public virtual ICollection<Арендаторы> Арендаторыs { get; } = new List<Арендаторы>();
}
